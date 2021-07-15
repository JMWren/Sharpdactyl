using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SharpdactylLib.Models.Application.Servers
{
    /// <summary>
    /// Represents the full results of an application server http request
    /// </summary>
    public class ApplicationServerContainerResult
    {
        [JsonProperty("Data", Required = Required.Always)]
        public ApplicationServerContainer[] Data { get; set; }
    }

    /// <summary>
    /// Represents all the data inside an application server http request
    /// </summary>
    public class ApplicationServerContainer
    {
        /// <summary>Attributes</summary>
        [JsonProperty("attributes", Required = Required.Always)]
        public ApplicationServer Attributes { get; set; }
    }

    /// <summary>
    /// Represents the application server attributes
    /// </summary>
    public class ApplicationServer : Server
    {
        /// <summary>The id</summary>
        [JsonProperty("id")]
        public long Id { get; set; }
        /// <summary>The external id</summary>
        [JsonProperty("external_id")]
        public string ExternalId { get; set; }
        /// <summary>The suspended status</summary>
        [JsonProperty("suspended")]
        public bool IsSuspended { get; set; }
        /// <summary>The user id of the owner</summary>
        [JsonProperty("user")]
        public int User { get; set; }
        /// <summary>The node id where the droplet is hosted</summary>
        [JsonProperty("node")]
        public int Node { get; set; }
        /// <summary>The allocation id</summary>
        [JsonProperty("allocation")]
        public int Allocation { get; set; }
        /// <summary>The nest id</summary>
        [JsonProperty("nest")]
        public int Nest { get; set; }
        /// <summary>The egg id</summary>
        [JsonProperty("egg")]
        public int Egg { get; set; }
        /// <summary>The pack id</summary>
        [JsonProperty("pack")]
        public int? Pack { get; set; }
        /// <summary>The docker container info</summary>
        [JsonProperty("container")]
        public Container Container { get; set; }
        /// <summary>The last updated date</summary>
        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }
        /// <summary>The creation date</summary>
        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }
    }

    /// <summary>Represents the container</summary>
    public class Container
    {
        /// <summary>The startup command</summary>
        public string StartupCommand { get; set; }
        /// <summary>The docker image used</summary>
        public string Image { get; set; }
        /// <summary>The installation status</summary>
        public bool Installed { get; set; }
        /// <summary>Environment settings</summary>
        public Dictionary<string,string> Environment { get; set; }
    }

    /// <summary>Represents the relationships</summary>
    public class Relationships
    { 
        public ApplicationDatabaseContainerResult Databases { get; set; }
    }
}