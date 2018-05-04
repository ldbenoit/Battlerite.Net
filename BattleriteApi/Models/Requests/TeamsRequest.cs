using System;
using System.Collections.Generic;

namespace Rocket.Battlerite
{
    public class TeamsRequest : IRequest
    {
        [Query("tag[season]")]
        public int Season { get; set;}
        
        [Query("tag[playerIds]")]
        public IEnumerable<string> PlayerIds { get; set;}

    }
}