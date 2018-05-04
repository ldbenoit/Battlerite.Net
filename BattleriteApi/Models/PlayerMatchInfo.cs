using System;
using System.Collections.Generic;

namespace Rocket.Battlerite
{
    public partial class PlayerMatchInfo
    {
        public string Id { get; set; }
        public string ActorId { get; set; }

        public Champion Champion { get; set; }
        public PlayerAttributes Attributes { get; set; }
        public ParticipantStats Stats { get; set; }

        public override string ToString()
        {
            return (!String.IsNullOrWhiteSpace(Attributes.Name)) ? Attributes.Name : Id;
        }
    }
}