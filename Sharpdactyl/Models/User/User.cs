using Newtonsoft.Json;

namespace Sharpdactyl.Models.User
{
    /// <summary>Represent the user</summary>
    public class User
    {
        /// <summary>Object</summary>
        [JsonProperty("object", Required = Required.Always)]
        public string Object { get; set; }

        /// <summary>Data</summary>
        [JsonProperty("data", Required = Required.Always)]
        public UserDatum[] Data { get; set; }
    }
    
}
