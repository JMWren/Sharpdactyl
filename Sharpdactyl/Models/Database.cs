using Newtonsoft.Json;

namespace SharpdactylLib.Models
{
    /// <summary>
    /// Represents the attributes of a database
    /// </summary>
    public abstract class Database
    {
        /// <summary>The database username</summary>
        [JsonProperty("username")]
        public string Username { get; set; }
        /// <summary>The max connections</summary>
        [JsonProperty("max_connections")]
        public int MaxConnections { get; set; }
    }
}
