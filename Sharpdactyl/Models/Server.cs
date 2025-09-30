using Newtonsoft.Json;
using System;

namespace SharpdactylLib.Models
{
    /// <summary>
    /// Represents attributes of all servers
    /// </summary>
    public abstract class Server
    {
        /// <summary>The string identifier</summary>
        [JsonProperty("identifier")]
        public string Identifier { get; set; }
        /// <summary>The server unique identifier</summary>
        [JsonProperty("uuid")]
        public Guid Uuid { get; set; }
        /// <summary>The server name</summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>The server description</summary>
        [JsonProperty("description")]
        public string Description { get; set; }
        /// <summary>The server resource limits</summary>
        [JsonProperty("limits")]
        public Limits Limits { get; set; }
        /// <summary>The server feature maximums</summary>
        [JsonProperty("feature_limits")]
        public FeatureLimits FeatureLimits { get; set; }
        /// <summary>The server relationships</summary>
        [JsonProperty("relationships")]
        public Relationships Relationships { get; set; }
    }

    /// <summary>
    /// Represents the hard resource limits for the server
    /// </summary>
    public class Limits
    {
        /// <summary>The memory (MB)</summary>
        [JsonProperty("memory", Required = Required.Always)]
        public int Memory { get; set; }
        /// <summary>The swap (MB)</summary>
        [JsonProperty("swap", Required = Required.Always)]
        public int Swap { get; set; }
        /// <summary>The disk size (MB)</summary>
        [JsonProperty("disk", Required = Required.Always)]
        public int Disk { get; set; }
        /// <summary>the IO</summary>
        [JsonProperty("io", Required = Required.Always)]
        public int Io { get; set; }
        /// <summary>The cpu (%)</summary>
        [JsonProperty("cpu", Required = Required.Always)]
        public int Cpu { get; set; }
        /// <summary>The threads</summary>
        [JsonProperty("threads", Required = Required.AllowNull)]
        public object Threads { get; set; }
    }

    /// <summary>
    /// Represents the limits of server features
    /// </summary>
    public class FeatureLimits
    {
        /// <summary>Max databases</summary>
        [JsonProperty("databases", Required = Required.Always)]
        public int Databases { get; set; }
        /// <summary>Max allocations</summary>
        [JsonProperty("allocations", Required = Required.Always)]
        public int Allocations { get; set; }
        /// <summary>Max backups</summary>
        [JsonProperty("backups", Required = Required.Always)]
        public int Backups { get; set; }
    }

    public class Relationships
    {
        public Allocation Allocations { get; set; }
    }
}
