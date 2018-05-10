using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Rocket.Battlerite
{
    public class BattleriteApi : IDisposable
    {
        private readonly string _apiKey;
        private HttpClient _client;
        private const string baseUrl =  "https://api.developer.battlerite.com/shards/global";
        private const string statusUrl =  "https://api.developer.battlerite.com/status";
        private const string playersUrl =  "https://api.developer.battlerite.com/shards/global/players";
        private const string teamsUrl =  "https://api.developer.battlerite.com/shards/global/teams";
        private const string matchesUrl =  "https://api.developer.battlerite.com/shards/global/matches";
        private JObject _gameplay;
        private JObject _stackable;

        public BattleriteApi(string apiKey)
        {
            _apiKey = apiKey;
            _client = new HttpClient();
        }

        public ResponseDetails ResponseDetails { get; set; } = new ResponseDetails();

        public async Task<StatusResponse> GetStatusAsync()
            => await CallApiAsync<StatusResponse>(statusUrl);

        public async Task<bool> IsOnline()
        {
            var response = await GetStatusAsync();
            if (response == null || response.Errors != null)
                return false;
            return true;
            
        }


        public async Task<MatchResponse> GetMatchAsync(string id, ResponseDetails details = null)
        {
            var response = await CallApiAsync<MatchResponse>($"{matchesUrl}/{id}");
             return await GetResponseDetailsAsync(response, details);
        }

        public async Task<MatchResponse> GetMatchByPlayerAsync(string playerId, ResponseDetails details = null)
            => await GetMatchesInternal<MatchResponse>(new MatchRequest{Players = new string[]{playerId}, Limit = 1}, details);

        public async Task<MatchesResponse> GetMatchesByPlayerAsync(string playerId, ResponseDetails details = null)
            => await GetMatchesInternal<MatchesResponse>(new MatchRequest{Players = new string[]{playerId}}, details);


        public async Task<MatchesResponse> GetMatchesAsync(ResponseDetails details = null)
            => await GetMatchesAsync(new MatchRequest(), details) as MatchesResponse;

        public async Task<MatchesResponse> GetMatchesAsync(string playerId, ResponseDetails details = null)
            => await GetMatchesAsync(new MatchRequest{Players = new string[]{playerId}}, details) as MatchesResponse;

        public async Task<MatchesResponse> GetMatchesAsync(IEnumerable<string> playerIds, ResponseDetails details = null)
            => await GetMatchesAsync(new MatchRequest{Players = playerIds}, details) as MatchesResponse;

        public async Task<MatchesResponse> GetMatchesAsync(MatchRequest request, ResponseDetails details = null)
            => await GetMatchesInternal<MatchesResponse>(request, details);


        private async Task<T> GetMatchesInternal<T>(MatchRequest request, ResponseDetails details = null)
            where T : MatchResponseBase , new()
        {
            request.Sort = request.Sort ?? "-createdAt";
            var response = await CallApiAsync<T>(matchesUrl + GetRequestQuery(request));
            return await GetResponseDetailsAsync(response, details);
        }


        public async Task<PlayerResponse> GetPlayerAsync(string id)
            => await CallApiAsync<PlayerResponse>($"{playersUrl}/{id}");

        public async Task<PlayerResponse> GetPlayerByNameAsync(string playerName)
            => await GetPlayerAsync(new PlayerRequest{PlayerNames = new string[]{playerName}});
        
        public async Task<PlayerResponse> GetPlayerBySteamIdAsync(string steamId)
            => await GetPlayerAsync(new PlayerRequest{SteamIds = new string[]{steamId}});

        public async Task<PlayerResponse> GetPlayerAsync(PlayerRequest request)
            => await GetPlayersInternal<PlayerResponse>(request);

        public async Task<PlayersResponse> GetPlayersAsync(IEnumerable<string> playerIds)
            => await GetPlayersAsync(new PlayerRequest{PlayerIds = playerIds});

        public async Task<PlayersResponse> GetPlayersByNameAsync(IEnumerable<string> playerNames)
            => await GetPlayersAsync(new PlayerRequest{PlayerNames = playerNames});

        public async Task<PlayersResponse> GetPlayersBySteamIdAsync(IEnumerable<string> steamIds)
            => await GetPlayersAsync(new PlayerRequest{SteamIds = steamIds});

        public async Task<PlayersResponse> GetPlayersAsync(PlayerRequest request)
            => await GetPlayersInternal<PlayersResponse>(request);


        private async Task<T> GetPlayersInternal<T>(PlayerRequest request)
            where T : PlayerResponseBase , new()
        {
            return await CallApiAsync<T>(playersUrl + GetRequestQuery(request));
        }


        public async Task<TeamsResponse> GetTeamsAsync(IEnumerable<string> players, int season)
            => await GetTeamsAsync(new TeamsRequest{PlayerIds = players, Season = season});

        public async Task<TeamsResponse> GetTeamsAsync(TeamsRequest request)
        {
            return await CallApiAsync<TeamsResponse>(teamsUrl + GetRequestQuery(request));
        }


        public async Task<TelemetryResponse> GetTelemetryAsync(string url)
            => await CallApiAsync<TelemetryResponse>(url);

        public async Task<TelemetryResponse> GetTelemetryAsync(MatchData match)
            => await CallApiAsync<TelemetryResponse>(match.TelemetryUrl);


        private async Task<T> CallApiAsync<T>(string url)
            where T : IResponse , new()
        {
            var request = new HttpRequestMessage();
            request.Method = HttpMethod.Get;

            request.Headers.Add("Authorization", _apiKey);
            request.Headers.Add("Accept", "application/vnd.api+json");

            request.RequestUri = new Uri(url);
            // var response = await _client.SendAsync(request);
            var response = await RateLimiter.Request(request);
            
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<T>(json);
                return result;
            }
            else
            {
                var error = new Error{Title = response.StatusCode.ToString(), Detail = response.ReasonPhrase};
                return new T{IsSuccess = false, Errors = new List<Error>{error}};
            }
        }

        private string GetRequestQuery<T>(T requestData)
            where T : IRequest
        {
            string query = "";
            var paramList = new List<string>();
            foreach (PropertyInfo property in requestData.GetType().GetProperties())
            {
                var value = property.GetValue(requestData);
                if(value == null)
                    continue;
                var queryAttr = ((QueryAttribute)property.GetCustomAttribute(typeof(QueryAttribute), false));
                string name = queryAttr?.Name ?? property.Name;

                if (value is IEnumerable<string> valList)
                {                    
                    value = String.Join(",", valList);
                }
                paramList.Add($"{name}={value.ToString()}");
            }
            if (paramList.Count > 0)
                query += "?" + String.Join("&", paramList);
            return query;
        } 

        public async Task<PlayersResponse> GetMatchPlayersAsync<T>(T match)
            where T : MatchData
        {
            var players = await GetPlayersAsync(match.Players.Select(x => x.Id).ToArray());
            if (players != null && players.Errors == null)
            {
                foreach (var player in match.Players)
                {
                    player.Attributes = players.Data.FirstOrDefault(x => x.Id == player.Id).Attributes;

                }
            }
            return players;
        }

        public async Task<TeamsResponse> GetMatchTeamsAsync<T>(T match)
            where T : MatchData
        {
            var season = match.Teams.First().Stats.Season;
            var teams = await GetTeamsAsync(match.Players.Select(x => x.Id).ToArray(), season);
            if (teams == null || teams.Errors != null)
                return null;
            foreach (var team in match.Teams)
            {
                var teamInfo = teams.Data.FirstOrDefault(x => x.Id == team.Id);
                if (teamInfo == null)
                    continue;
                team.Name = teamInfo.Attributes.Name;
                team.Avatar = teamInfo.Attributes.Stats.Avatar;
            }
            return teams;
        }

        public async Task<TelemetryResponse> GetMatchTelemetryAsync<T>(T match)
            where T : MatchData
        {
            var telemetry = await GetTelemetryAsync(match.TelemetryUrl);
            match.Telemetry = telemetry;
            return telemetry;
        }

        public async Task<IList<Champion>> GetMatchChampionsAsync<T>(T match)
            where T : MatchData
        {
            await Task.Yield();
            if (_gameplay == null || _stackable == null)
                await GetJsonObjects();

            foreach (var player in match.Players)
            {
                var character = _gameplay["characters"].FirstOrDefault(x => (string)x["typeID"] == player.ActorId);
                var stack = _stackable["Mappings"].FirstOrDefault(x => (string)x["LocalizedName"] == (string)character["name"]);
                player.Champion = new Champion{
                    ActorId = player.ActorId,
                    Name =( string)stack["EnglishLocalizedName"],
                    LocalName = (string)stack["LocalizedName"],
                    Icon = (string)character["icon"],
                    WideIcon = (string)character["wideIcon"]};
            }

            return match.Players.Select(x =>x.Champion).ToList();
            
        }

        private async Task GetJsonObjects()
        {
            var assembly = Assembly.GetExecutingAssembly();
            StreamReader gp = new StreamReader( assembly.GetManifestResourceStream("BattleriteApi.Assets.gameplay.json"));
            StreamReader st = new StreamReader( assembly.GetManifestResourceStream("BattleriteApi.Assets.stackables.json"));
            _gameplay = JObject.Parse( await gp.ReadToEndAsync());
            _stackable = JObject.Parse(await st.ReadToEndAsync());
        }

        public async Task<MatchData> GetMatchDetailsAsync(MatchData match, ResponseDetails details = null)
        {
            details = details ?? ResponseDetails;
            if (match == null)
                throw new ArgumentNullException("match");

            var tasks = new List<Task>();

            if (details.IncludeTelemetry)
                tasks.Add(GetMatchTelemetryAsync(match));

            if (details.IncludePlayers)
                      tasks.Add(GetMatchPlayersAsync(match));

            if (details.IncludeChampions)
                     tasks.Add(GetMatchChampionsAsync(match));

            if (details.IncludeTeams)
                     tasks.Add(GetMatchTeamsAsync(match));

            await Task.WhenAll(tasks);
            return match;
            
        }

        public async Task<T> GetResponseDetailsAsync<T>(T response, ResponseDetails details = null)
            where T : MatchResponseBase
        {
            details = details ?? ResponseDetails;
            if (response == null || response.Errors != null)
                return response;
            var tasks = new List<Task>();
            foreach( var match in response.Data)
                tasks.Add(GetMatchDetailsAsync(match));
            
            await Task.WhenAll(tasks);


            return response;
        }

        public void Dispose()
        {
            _gameplay = null;
            _stackable = null;
            RateLimiter.Dispose();
        }
    }
}

