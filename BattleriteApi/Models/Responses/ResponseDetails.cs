namespace Rocket.Battlerite
{
    public class ResponseDetails
    {
        public bool IncludePlayers { get; set; }
        public bool IncludeTeams { get; set; }
        public bool IncludeChampions { get; set; }
        public bool IncludeTelemetry { get; set; }

        public ResponseDetails WithPlayers(bool value = true)
        {
            IncludePlayers = value;
            return this;
        }

        public ResponseDetails WithTeams(bool value = true)
        {
            IncludeTeams = value;
            return this;
        }

        public ResponseDetails WithChampions(bool value = true)
        {
            IncludeChampions = value;
            return this;
        }

        public ResponseDetails WithTelemetry(bool value = true)
        {
            IncludeTelemetry = value;
            return this;
        }

        public ResponseDetails WithAll(bool value = true)
        {
            IncludePlayers = value;
            IncludeTeams = value;
            IncludeChampions = value;
            IncludeTelemetry = value;
            return this;
        }
    }
}