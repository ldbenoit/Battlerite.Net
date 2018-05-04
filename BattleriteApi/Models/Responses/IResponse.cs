using System.Collections.Generic;
using Newtonsoft.Json;

namespace Rocket.Battlerite
{
    public interface IResponse
    {
        bool IsSuccess {get;set;}
        List<Error> Errors { get; set; }
    }
}