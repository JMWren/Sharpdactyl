using Newtonsoft.Json;
using System;

namespace SharpdactylLib.Models.Application.Locations
{
    /// <summary>
    /// Represents the full results of a location http request
    /// </summary>
    public class LocationContainerResult
    {
        /// <summary>The location data return</summary>
        [JsonProperty("data")]
        public LocationContainer[] Data { get; set; }
    }

    /// <summary>
    /// Represents the data inside of a location http request
    /// </summary>
    public class LocationContainer
    {
        /// <summary>The location attributes</summary>
        [JsonProperty("attributes")]
        public Location Attributes { get; set; }
    }

    /// <summary>
    /// Represents the attributes of a location
    /// </summary>
    public class Location
    {
        /// <summary>The location id</summary>
        [JsonProperty("id", Required = Required.Always)]
        public long Id { get; set; }
        /// <summary>The location short string identifier</summary>
        [JsonProperty("short", Required = Required.AllowNull)]
        public string Short { get; set; }
        /// <summary>The location long string identifier</summary>
        [JsonProperty("long", Required = Required.AllowNull)]
        public string Long { get; set; }
        /// <summary>Last location update time</summary>
        [JsonProperty("updated_at", Required = Required.Always)]
        public DateTimeOffset UpdatedAt { get; set; }
        /// <summary>Location creation time</summary>
        [JsonProperty("created_at", Required = Required.Always)]
        public DateTimeOffset CreatedAt { get; set; }
    }
}
