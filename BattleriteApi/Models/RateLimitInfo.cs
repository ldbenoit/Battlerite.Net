using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;

namespace Rocket.Battlerite
{
    public class RateLimitInfo
    {
        public RateLimitInfo(Dictionary<string, string> headers)
        {
            Limit = headers.TryGetValue("X-Ratelimit-Limit", out var limitString) &&
                int.TryParse(limitString, out var limit) ? limit : (int?)null;

            Remaining = headers.TryGetValue("X-Ratelimit-Remaining", out var remainString) &&
                int.TryParse(remainString, out var remaining) ? remaining : (int?)null;

            Reset = headers.TryGetValue("X-Ratelimit-Reset", out var resetString) &&
                ulong.TryParse(resetString, out var reset) ? reset : (ulong?)null;
        }

        public RateLimitInfo(HttpResponseHeaders headers)
            : this( headers.ToDictionary(x => x.Key, y => y.Value.FirstOrDefault())) {}

        public int? Limit { get; set; }
        public int? Remaining { get; set; }
        public ulong? Reset { get; set; }
        
    }
}