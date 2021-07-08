using Newtonsoft.Json;

namespace SharpdactylLib.Models.Client.Node
{
    /// <summary>Represents the node</summary>
    public class Node
    {
        /// <summary>The nodes</summary>
        [JsonProperty("data", Required = Required.Always)]
        public NodeDatum[] Data { get; set; }

        /// <summary>Meta</summary>
        [JsonProperty("meta", Required = Required.Always)]
        public Meta Meta { get; set; }
    }

    /// <summary>Represents the meta</summary>
    public class Meta
    {
        /// <summary>The pagination</summary>
        [JsonProperty("pagination", Required = Required.Always)]
        public Pagination Pagination { get; set; }
    }

    /// <summary>Represents the pagination</summary>
    public class Pagination
    {
        /// <summary>Total</summary>
        [JsonProperty("total", Required = Required.Always)]
        public string Total { get; set; }

        /// <summary>Count</summary>
        [JsonProperty("count", Required = Required.Always)]
        public int Count { get; set; }

        /// <summary>Per page</summary>
        [JsonProperty("per_page", Required = Required.Always)]
        public int Per_page { get; set; }

        /// <summary>The current page</summary>
        [JsonProperty("current_page", Required = Required.Always)]
        public int Current_page { get; set; }

        /// <summary>The total pages</summary>
        [JsonProperty("total_pages", Required = Required.Always)]
        public int Total_pages { get; set; }

    }
}
