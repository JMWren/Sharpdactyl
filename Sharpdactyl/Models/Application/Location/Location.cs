using Newtonsoft.Json;
using System;

namespace SharpdactylLib.Models.Application.Location
{
    /// <summary>Location data about the host panel</summary>
    public class Location
    {
        public LocationDatum[] Data { get; set; }
    }

    /// <summary>The location data</summary>
    public class LocationDatum
    {
        public Attributes Attributes { get; set; }
    }

    /// <summary>The location attributes</summary>
    public class Attributes
    {
        /// <summary>The location id</summary>
        [JsonProperty("id", Required = Required.Always)]
        public int Id { get; set; }
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
