using System.Collections.Specialized;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;

namespace Sharpdactyl.Helpers
{
    /// <summary>
    /// Class represents the web helper for api calls
    /// </summary>
    internal class WebHelper
    {
        private readonly string _hostname;
        private readonly string _apiKey;

        /// <summary>
        /// Constructor for the webhelper class
        /// </summary>
        /// <param name="hostname">the hostname</param>
        /// <param name="apiKey">the api key</param>
        public WebHelper(string hostname, string apiKey)
        {
            _hostname = hostname;
            _apiKey = apiKey;
        }

        /// <summary>
        /// Send a delete instruction
        /// </summary>
        /// <param name="query">the query</param>
        /// <returns></returns>
        public async Task Delete(string query)
        {
            Url url = new Url(_hostname + $"/api/{query}");
            await url
                .WithHeader("Accept","Application/vnd.pterodactyl.v1+json")
                .WithHeader("Content-type","application/json")
                .WithOAuthBearerToken(_apiKey)
                .DeleteAsync();
        }

        /// <summary>
        /// Send a patch instruction
        /// </summary>
        /// <param name="query">the query</param>
        /// <param name="data">the data</param>
        /// <returns>the result of the instruction</returns>
        public async Task<string> Patch(string query, NameValueCollection data)
        {
            Url url = new Url(_hostname + $"/api/{query}");
            var result = await url
                .WithHeader("Accept", "Application/vnd.pterodactyl.v1+json")
                .WithHeader("Content-type", "application/json")
                .WithOAuthBearerToken(_apiKey)
                .PatchJsonAsync(data)
                .ReceiveString();

            return result;
        }

        /// <summary>
        /// Send a post instruction
        /// </summary>
        /// <param name="query">the query</param>
        /// <param name="data">the data</param>
        /// <returns>the result of the instruction</returns>
        public async Task<string> Post(string query, NameValueCollection data)
        {
            Url url = new Url(_hostname + $"/api/{query}");
            var result = await url
                .WithHeader("Accept", "Application/vnd.pterodactyl.v1+json")
                .WithHeader("Content-type", "application/json")
                .WithOAuthBearerToken(_apiKey)
                .PostJsonAsync(data)
                .ReceiveString();

            return result;
        }

        /// <summary>
        /// Send a json with the post instruction
        /// </summary>
        /// <param name="query">the query</param>
        /// <param name="json">the json</param>
        /// <returns>the result of the instruction</returns>
        public async Task<string> PostJSON(string query, string json)
        {
            Url url = new Url(_hostname + $"/api/{query}");
            var result = await url
                .WithHeader("Accept", "Application/vnd.pterodactyl.v1+json")
                .WithHeader("Content-type", "application/json")
                .WithOAuthBearerToken(_apiKey)
                .PostJsonAsync(json)
                .ReceiveString();

            return result;            
        }

        /// <summary>
        /// Send a get instruction
        /// </summary>
        /// <param name="query">the query</param>
        /// <returns>the result of the instruction</returns>
        public async Task<string> Get(string query)
        {
            Url url = new Url(_hostname + $"/api/{query}");
            var result = await url
                .WithHeader("Accept", "Application/vnd.pterodactyl.v1+json")
                .WithHeader("Content-type", "application/json")
                .WithOAuthBearerToken(_apiKey)
                .GetAsync()
                .ReceiveString();

            return result;
        }
    }
}
