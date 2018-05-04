using System.Collections.Generic;

namespace Rocket.Battlerite
{
    public class IncludeContainer
    {
        public List<AssetInclude> Assets { get; set; } = new List<AssetInclude>();
        public List<ParticipantInclude> Participants { get; set; } = new List<ParticipantInclude>();
        public List<PlayerInclude> Players { get; set; } = new List<PlayerInclude>();
        public List<RosterInclude> Rosters { get; set; } = new List<RosterInclude>();
        public List<RoundInclude> Rounds { get; set; } = new List<RoundInclude>();
        public List<TeamInclude> Teams { get; set; } = new List<TeamInclude>();
    }
}