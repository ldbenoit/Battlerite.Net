using System.Collections.Generic;
using Newtonsoft.Json;

namespace Rocket.Battlerite
{
    public interface IResponse
    {
        List<Error> Errors { get; set; }
        bool IsSuccess {get;set;}

    }
}