using Newtonsoft.Json;
using System;

namespace SharpdactylLib.Models.Application.Node
{
    /// <summary>The allocation on the node</summary>
    public class Allocation
    {
        /// <summary>The allocation data</summary>
        [JsonProperty("data", Required = Required.Always)]
        public AllocationDatum[] Data { get; set; }
    }

    public class AllocationDatum
    {
        /// <summary>The attributes</summary>
        [JsonProperty("attributes", Required = Required.Always)]
        public Attributes Attributes { get; set; }
    }

    public class Attributes
    {
        /// <summary>The allocation id</summary>
        [JsonProperty("id", Required = Required.Always)]
        public int Id { get; set; }
        /// <summary>The allocation ip</summary>
        [JsonProperty("ip", Required = Required.Always)]
        public string Ip { get; set; }
        /// <summary>The allocation alias</summary>
        [JsonProperty("alias", Required = Required.AllowNull)]
        public string Alias { get; set; }
        /// <summary>The allocation port</summary>
        [JsonProperty("port", Required = Required.Always)]
        public int Port { get; set; }
        /// <summary>The allocation notes</summary>
        [JsonProperty("notes", Required = Required.AllowNull)]
        public string Notes { get; set; }
        /// <summary>Allocation assigned state</summary>
        [JsonProperty("assigned", Required = Required.Always)]
        public bool IsAssigned { get; set; }
    }
}
