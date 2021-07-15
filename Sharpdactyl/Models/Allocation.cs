using Newtonsoft.Json;

namespace SharpdactylLib.Models
{
    /// <summary>
    /// Represents the attributes of an allocation
    /// </summary>
    public abstract class Allocation
    {
        /// <summary>The allocation id</summary>
        [JsonProperty("id")]
        public long Id { get; set; }
        /// <summary>The allocation ip</summary>
        [JsonProperty("ip")]
        public string Ip { get; set; }
        /// <summary>The allocation port</summary>
        [JsonProperty("port")]
        public int Port { get; set; }
        /// <summary>The allocation notes</summary>
        [JsonProperty("notes")]
        public string Notes { get; set; }
    }
}
