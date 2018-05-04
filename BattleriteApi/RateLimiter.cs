using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Rocket.Battlerite
{
    public static class RateLimiter
    {
        private static HttpClient _client;
        private static SemaphoreSlim _ss = new SemaphoreSlim(5, 5);

        public static RateLimitInfo RateLimit { get; set; }
        public static IList<RateLimitedRequest> Requests { get; set; } =  new List<RateLimitedRequest>();

        public static bool IsActive { get; set; }

        public static async Task<HttpResponseMessage> Request(HttpRequestMessage request)
        {
            if (_client == null)
                _client = new HttpClient();
            await _ss.WaitAsync();
            var limited = new RateLimitedRequest(request);

            if (Requests.Count != 0 || (RateLimit?.Remaining != null && RateLimit.Remaining <= 5))
            {
                Requests.Add(limited);
                Start();
            }
            else 
            {
                limited.Response = await _client.SendAsync(limited.Request);
                if (limited.Response.StatusCode.ToString() == "429")
                {
                    Requests.Add(limited);
                    Start();
                }
                else 
                {
                    limited.IsFinished.SetResult(true);
                    RateLimit = new RateLimitInfo(limited.Response.Headers);
                }
            }
            _ss.Release(1);
            // Requests.Add(limited);
            // GetResponse(limited);
            await limited.IsFinished.Task;
            return limited.Response;
        }

        public static void Start()
        {
            if (IsActive)
                return;
            IsActive = true;
            ProcessRequests();
        }

        public static void Stop()
        {
            IsActive = false;
        }
        public static async void ProcessRequests()
        {
            await Task.Yield();
            while (IsActive)
            {
                if (Requests.Count == 0)
                    continue;
                if (RateLimit?.Remaining != null && RateLimit.Remaining <= 1)
                    await Task.Delay((60 / RateLimit.Limit.Value) * 1000 + 200);
                var limited = Requests.First();
                limited.Response = await _client.SendAsync(limited.Request);

                limited.IsFinished.SetResult(true);
                RateLimit = new RateLimitInfo(limited.Response.Headers);
                Requests.Remove(limited);
            }
        }

        public static async void Dispose()
        {
            await Task.Yield();
            _client = null;
            while(Requests.Count > 0) {}
            Stop();
        }
    }

    public class RateLimitedRequest
    {
        public RateLimitedRequest(HttpRequestMessage request)
        {
            Request = request;
            IsFinished = new TaskCompletionSource<bool>();
        }
        public TaskCompletionSource<bool> IsFinished { get; set; }
        public HttpResponseMessage Response { get; set; }
        public HttpRequestMessage Request { get; set; }
    }
}