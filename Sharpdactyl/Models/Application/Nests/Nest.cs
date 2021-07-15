using Newtonsoft.Json;
using System;

namespace SharpdactylLib.Models.Application.Nests
{
    /// <summary>
    /// Represents the full results of an application nest http request
    /// summary>
    public class NestContainerResult
    {
        /// <summary>Nest request data</summary>
        public NestContainer[] Data { get; set; }
    }

    /// <summary>
    /// Represents the data inside the application nest http request
    /// </summary>
    public class NestContainer
    {
        /// <summary>Nest attributes</summary>
        public Nest Attributes { get; set; }
    }

    /// <summary>
    /// Represents the nest attributes
    /// </summary>
    public class Nest
    {
        /// <summary>The nest id</summary>
        [JsonProperty("id", Required = Required.Always)]
        public long Id { get; set; }
        /// <summary>The nest uuid</summary>
        [JsonProperty("uuid", Required = Required.Always)]
        public Guid Uuid { get; set; }
        /// <summary>The nest author</summary>
        [JsonProperty("author", Required = Required.Always)]
        public string Author { get; set; }
        /// <summary>The nest name</summary>
        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }
        /// <summary>The nest description</summary>
        [JsonProperty("description", Required = Required.Always)]
        public string Description { get; set; }
        /// <summary>The nest creation time</summary>
        [JsonProperty("created_at", Required = Required.Always)]
        public DateTimeOffset CreatedAt { get; set; }
        /// <summary>The nest last updated time</summary>
        [JsonProperty("updated_at", Required = Required.Always)]
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
