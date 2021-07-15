using Newtonsoft.Json;

namespace SharpdactylLib.Models.Client.Servers
{
    /// <summary>
    /// Represents the data inside the server state http request
    /// </summary>
    public class ServerStateContainer
    {
        /// <summary>Server attributes</summary>
        public ServerState Attributes { get; set; }
    }

    /// <summary>
    /// Represents the current state the server is in
    /// </summary>
    public class ServerState
    {
        /// <summary>Current working state of server</summary>
        [JsonProperty("current_state")]
        public string CurrentState { get; set; }
        /// <summary>Whether the server is in suspended mode</summary>
        [JsonProperty("is_suspended")]
        public bool IsSuspended { get; set; }
        /// <summary>Server resources</summary>
        [JsonProperty("resources")]
        public Resources Resources { get; set; }
    }

    /// <summary>
    /// Represents the current resource usage of the server
    /// </summary>
    public class Resources
    {
        /// <summary>Server memory usage in bytes</summary>
        [JsonProperty("memory_bytes")]
        public int MemoryBytes { get; set; }
        /// <summary>Server cpu usage (percentile)</summary>
        [JsonProperty("cpu_absolute")]
        public int CpuAbsolute { get; set; }
        /// <summary>Server disk usage in bytes</summary>
        [JsonProperty("disk_bytes")]
        public int DiskBytes { get; set; }
        /// <summary>Server network receive usage in bytes</summary>
        [JsonProperty("network_rx_bytes")]
        public int NetworkRxBytes { get; set; }
        /// <summary>Server network transmit usage in bytes</summary>
        [JsonProperty("network_tx_bytes")]
        public int NetworkTxBytes { get; set; }
    }

}
