using Newtonsoft.Json;

namespace SharpdactylLib.Models.Application.User
{
    /// <summary>Represent the user</summary>
    public class User
    {
        /// <summary>Data</summary>
        [JsonProperty("data", Required = Required.Always)]
        public UserDatum[] Data { get; set; }
    }
    
}
