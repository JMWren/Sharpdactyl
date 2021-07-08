using Newtonsoft.Json;
using System;

namespace SharpdactylLib.Models.Application.Nests.Eggs
{
    /// <summary>Represents the eggs installed inside a nest</summary>
    public class Egg
    {
        public EggDatum[] Data { get; set; }
    }

    /// <summary>The egg data</summary>
    public class EggDatum
    { 
        public Attributes Attributes { get; set; }
    }

    /// <summary>The egg attributes</summary>
    public class Attributes
    { 
        /// <summary>The egg id</summary>
        [JsonProperty("id", Required = Required.Always)]
        public long Id { get; set; }
        /// <summary>The egg uuid</summary>
        [JsonProperty("uuid", Required = Required.Always)]
        public Guid Uuid { get; set; }
        /// <summary>The egg name</summary>
        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }
        /// <summary>The egg nest</summary>
        [JsonProperty("nest", Required = Required.Always)]
        public int Nest { get; set; }
        /// <summary>The egg author</summary>
        [JsonProperty("author", Required = Required.Always)]
        public string Author { get; set; }
        /// <summary>The egg description</summary>
        [JsonProperty("description", Required = Required.Always)]
        public string Description { get; set; }
        /// <summary>The egg docker image</summary>
        [JsonProperty("docker_image", Required = Required.Always)]
        public string DockerImage { get; set; }
        /// <summary>The egg startup command</summary>
        [JsonProperty("startup", Required = Required.Always)]
        public string Startup { get; set; }
        /// <summary>The egg creation time</summary>
        [JsonProperty("created_at", Required = Required.Always)]
        public DateTimeOffset CreatedAt { get; set; }
        /// <summary>The egg last updated time</summary>
        [JsonProperty("updated_at", Required = Required.Always)]
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
