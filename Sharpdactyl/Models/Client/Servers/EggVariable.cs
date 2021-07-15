using Newtonsoft.Json;

namespace SharpdactylLib.Models.Client.Servers
{
    /// <summary>
    /// Represents the full results of an egg variable http request
    /// </summary>
    public class EggVariableContainerResult
    {
        /// <summary>The resultant data</summary>
        public EggVariableContainer[] Data { get; set; }
    }

    /// <summary>
    /// Represents all the data inside of an egg variable http request
    /// </summary>
    public class EggVariableContainer
    {
        /// <summary>The container attributes</summary>
        public EggVariable Attributes { get; set; }
    }

    /// <summary>
    /// Represents the attributes of an egg variable
    /// </summary>
    public class EggVariable
    {
        /// <summary>Egg variable name</summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>Egg variable description</summary>
        [JsonProperty("description")]
        public string Description { get; set; }
        /// <summary>Egg variable</summary>
        [JsonProperty("variable")]
        public string Variable { get; set; }
        /// <summary>Egg variable default value</summary>
        [JsonProperty("default_value")]
        public string DefaultValue { get; set; }
        /// <summary>Egg variable server value</summary>
        [JsonProperty("server_value")]
        public string ServerValue { get; set; }
        /// <summary>Whether the variable is editable</summary>
        [JsonProperty("is_editable")]
        public bool IsEditable { get; set; }
        /// <summary>Variable value rules</summary>
        [JsonProperty("rules")]
        public string Rules { get; set; }
    }
}
