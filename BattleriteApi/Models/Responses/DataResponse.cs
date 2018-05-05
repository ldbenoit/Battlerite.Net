using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Rocket.Battlerite
{
    public abstract class DataResponse<T> : IResponse
    {
        [JsonProperty("data")]
        public virtual IList<T> Data { get; set; }

        [JsonProperty("errors")]
        public List<Error> Errors { get; set; }

        [JsonIgnore]
        public bool IsSuccess { get; set; }

        [OnDeserialized]
        internal void OnDeserializedBase(StreamingContext context)
        {
            if (Errors != null)
            {
                IsSuccess = false;

            }
            else if (Data == null || Data.Count <= 0)
            {
                IsSuccess = false;
                Errors = new List<Error>{new Error{Title = "No Data", Detail = "Unable to find any results."}};
            }
            else
            {
                IsSuccess = true;
            }
            
        }
    }
}