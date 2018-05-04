# Battlerite.net

An asynchronous API wrapper for the official [Battlerite Api](http://battlerite-docs.readthedocs.io/en/master/introduction.html).

## Installation

Install latest release from NuGet or download latest version and run from github.

- [Battlerite.Net](https://www.nuget.org/packages/Battlerite.Net/)
- [Github](https://github.com/ldbenoit/Battlerite.Net)

`dotnet add package Battlerite.Net --version 1.0.0`

## Usage

Create a new instance of the api and retrieve a list of matches.

```c#
using (var br = new BattleriteApi("Api Key"))
{
    var result = await br.GetMatchesAsync();
    if (result.IsSuccess)
        Console.WriteLine(result.Matches.Count);
}
```

### Matches

Getting a collection of matches by playerId

```c#
var result = await br.GetMatchesAsync("Player Id");
var matches = result.Matches;
```

Getting a single match by Id

```c#
var result = await br.GetMatchAsync("Match Id");
var match = result.Match;
```

The same can be done by player names.

```c#
var result = await br.GetMatchByPlayerAsync(playerName);
var result = await br.GetMatchesByPlayerAsync(nameEnumerable);
```

### Players

Getting a collection of players

```c#
var playerIds = new string[]{"id1", "id2"};
var result = await br.GetPlayersAsync(playerIds);
var Players = result.Players;
```

Getting a single player by Id

```c#
var result = await br.GetPlayerAsync("Player Id");
var match = result.Match;
```

You can also get a collection of players or single player by steamid or player name.

`var result = await br.GetPlayerByNameAsync(playerName);`

`var result = await br.GetPlayersByNameAsync(nameEnumerable);`

`var result = await br.GetPlayerBySteamIdAsync(steamId);`

`var result = await br.GetPlayersBySteamIdAsync(steamIdEnumerable);`

### Using Requests

Match and player get methods can be used with a MatchRequest or PlayerRequest for additional parameters.

```c#
var request = new MatchRequest
{
    Limit = 5,
    Sort = "-createdAt",
    ServerType = ServerType.Quick3v3
};
var result = await br.GetMatchesAsync(request);
```

### Additional Match Data

By default the api doesn't include player/team/telemetry data, and requires additional queries to retreive.

```c#
var result = await br.GetMatchAsync("matchId");
await br.GetMatchTelemetryAsync(result.match);
await br.GetMatchPlayersAsync(result.match);
await br.GetMatchTeamsAsync(result.match);
await br.GetMatchChampionsAsync(result.match);
```

### Using ResponseDetails

To aid in retreiving additional data from your responses you can use a ResponseDetails object.

```c#
using (var br = new BattleriteApi("Api Key"))
{
    br.ResponseDetails.WithPlayers().WithTelemetry();
    var result = await br.GetMatchesAsync();
}
```

Or for individual requests.

```c#
var details = new ResponseDetails().WithPlayers().WithTeams();
var result = await br.GetMatchAsync("matchId", details);
```

## Libraries

- Newtonsoft.Json

## Authors

**Levi Benoit** - *Initial work* - [ldbenoit](https://github.com/ldbenoit)

### Notes

I am a hobbyist programmer and made this because I couldn't find a decent alternative. I'm sorry if it is a mess.
If you have any problems or advice for me let me know. Thanks, I hope this is useful.
