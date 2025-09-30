using Newtonsoft.Json;
using System;

namespace SharpdactylLib.Models.Application.Servers
{
    /// <summary>
    /// Represents the full results of an application database http request
    /// </summary>
    public class ApplicationDatabaseContainerResult
    {
        /// <summary>The data</summary>
        [JsonProperty("data", Required = Required.Always)]
        public ApplicationDatabaseContainer[] Data { get; set; }
    }

    /// <summary>
    /// Represents all the data inside an application database http request
    /// </summary>
    public class ApplicationDatabaseContainer
    {
        /// <summary>The database data</summary>
        [JsonProperty("attributes", Required = Required.Always)]
        public ApplicationDatabase Attributes { get; set; }
    }

    /// <summary>
    /// Represents the application database attributes
    /// </summary>
    public class ApplicationDatabase : Database
    {
        /// <summary>The database id</summary>
        [JsonProperty("id")]
        public long Id { get; set; }
        /// <summary>The database's assigned server</summary>
        [JsonProperty("server")]
        public int Server { get; set; }
        /// <summary>The database host</summary>
        [JsonProperty("host")]
        public int Host { get; set; }
        /// <summary>The database name</summary>
        [JsonProperty("database")]
        public string DatabaseName { get; set; }
        /// <summary>The database remote</summary>
        [JsonProperty("remote")]
        public string Remote { get; set; }
        /// <summary>The database creation date</summary>
        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }
        /// <summary>The database's last updated date</summary>
        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
