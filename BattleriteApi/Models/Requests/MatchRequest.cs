using System;
using System.Collections.Generic;

namespace Rocket.Battlerite
{
    public class MatchRequest : IRequest
    {
        [Query("page[offset]")]
        public int? Offset {get;set;}

        [Query("page[limit]")]
        public int? Limit {get;set;}


        [Query("sort")]
        public string Sort {get;set;}


        [Query("filter[createdAt-start]")]
        public DateTime? CreatedStart { get; set;}

        [Query("filter[createdAt-end]")]
        public DateTime? CreatedEnd { get; set;}


        [Query("filter[playerIds]")]
        public IEnumerable<string> Players { get; set;}

        [Query("filter[patchVersion]")]
        public string PatchVer { get; set;}

        [Query("filter[serverType]")]
        public ServerType? ServerType { get; set;}

        [Query("filter[rankingType]")]
        public RankingType? RankingType { get; set;}

    }
}