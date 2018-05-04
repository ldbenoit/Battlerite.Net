using System.Collections.Generic;

namespace Rocket.Battlerite
{
    public partial class TeamMatchInfo
    {
        public string Id { get; set; }

        public string Name { get; set; }
        public long Avatar { get; set; }

        public bool IsWinner { get; set; }
        public IEnumerable<PlayerMatchInfo> Players { get; set; }
        public RosterStats Stats { get; set; }
    }
}