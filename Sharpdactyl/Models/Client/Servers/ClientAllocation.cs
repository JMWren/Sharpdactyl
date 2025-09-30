using Newtonsoft.Json;

namespace SharpdactylLib.Models.Client.Servers
{
    /// <summary>
    /// Represents the full results of a client allocation http request
    /// </summary>
    public class ClientAllocationContainerResult
    {
        /// <summary>The allocation request data</summary>
        [JsonProperty("data", Required = Required.Always)]
        public ClientAllocationContainer[] Data { get; set; }
    }

    /// <summary>
    /// Represents all the data inside of a client allocation http request
    /// </summary>
    public class ClientAllocationContainer
    {
        /// <summary>The client allocation</summary>
        [JsonProperty("attributes", Required = Required.Always)]
        public ClientAllocation Attributes { get; set; }
    }

    /// <summary>
    /// Represents all the attributes of a client allocation
    /// </summary>
    public class ClientAllocation : Allocation
    {
        /// <summary>The allocation ip alias</summary>
        [JsonProperty("ip_alias")]
        public string IpAlias { get; set; }
        /// <summary>Whether the allocation is default</summary>
        [JsonProperty("is_default")]
        public bool IsDefault { get; set; }
    }

}
