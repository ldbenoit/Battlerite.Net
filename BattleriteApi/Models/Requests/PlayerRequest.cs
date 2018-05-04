using System;
using System.Collections.Generic;

namespace Rocket.Battlerite
{
    public class PlayerRequest : IRequest
    {
        [Query("filter[playerIds]")]
        public IEnumerable<string> PlayerIds { get; set;}

        [Query("filter[steamIds]")]
        public IEnumerable<string> SteamIds { get; set;}

        [Query("filter[playerNames]")]
        public IEnumerable<string> PlayerNames { get; set;}

    }
}