using Newtonsoft.Json;

namespace SharpdactylLib.Models.Application.Nodes.Allocations
{
    /// <summary>
    /// Represents the full results of an application allocation http request
    /// </summary>
    public class ApplicationAllocationContainerResult
    {
        /// <summary>The allocation request data</summary>
        [JsonProperty("data", Required = Required.Always)]
        public ApplicationAllocationContainer[] Data { get; set; }
    }

    /// <summary>
    /// Represents all the data inside of an allocation http request
    /// </summary>
    public class ApplicationAllocationContainer
    {
        /// <summary>The allocation attribute</summary>
        [JsonProperty("attributes", Required = Required.Always)]
        public ApplicationAllocation Attributes { get; set; }
    }

    /// <summary>
    /// Represents all the attributes of an application allocation
    /// </summary>
    public class ApplicationAllocation : Allocation
    {
        /// <summary>The allocation alias</summary>
        [JsonProperty("alias", Required = Required.AllowNull)]
        public string Alias { get; set; }
        /// <summary>Whether the allocation is assigned</summary>
        [JsonProperty("assigned", Required = Required.Always)]
        public bool IsAssigned { get; set; }
    }
}
