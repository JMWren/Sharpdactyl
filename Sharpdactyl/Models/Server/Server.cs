using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SharpdactylLib.Models.Server
{
    /// <summary>Represents the hard limits for the server</summary>
    public class Limits
    {
        /// <summary>The memory (MB)</summary>
        [JsonProperty("memory", Required = Required.Always)]
        public int Memory { get; set; }
        /// <summary>The swap (MB)</summary>
        [JsonProperty("swap", Required = Required.Always)]
        public int Swap { get; set; }
        /// <summary>The disk size (MB)</summary>
        [JsonProperty("disk", Required = Required.Always)]
        public int Disk { get; set; }
        /// <summary>the IO</summary>
        [JsonProperty("io", Required = Required.Always)]
        public int Io { get; set; }
        /// <summary>The cpu (%)</summary>
        [JsonProperty("cpu", Required = Required.Always)]
        public int Cpu { get; set; }
        /// <summary>The threads</summary>
        [JsonProperty("threads", Required = Required.AllowNull)]
        public object Threads { get; set; }
    }

    /// <summary>Represents the limits of features</summary>
    public class FeatureLimits
    {
        /// <summary>Max databases</summary>
        [JsonProperty("databases", Required = Required.Always)]
        public int Databases { get; set; }
        /// <summary>Max allocations</summary>
        [JsonProperty("allocations", Required = Required.Always)]
        public int Allocations { get; set; }
        /// <summary>Max backups</summary>
        [JsonProperty("backups", Required = Required.Always)]
        public int Backups { get; set; }
    }

    /// <summary>Represents the container</summary>
    public class Container
    {
        /// <summary>The startup command</summary>
        public string Startup_command { get; set; }
        /// <summary>The docker image used</summary>
        public string Image { get; set; }
        /// <summary>The installation status</summary>
        public bool Installed { get; set; }
        /// <summary>Environment settings</summary>
        public Dictionary<string,string> Environment { get; set; }
    }

    /// <summary>Represents the database attributes</summary>
    public class DatabaseAttributes
    {
        /// <summary>The id</summary>
        public long Id { get; set; }
        /// <summary>The server</summary>
        public int Server { get; set; }
        /// <summary>The host</summary>
        public int Host { get; set; }
        /// <summary>The database</summary>
        public string Database { get; set; }
        /// <summary>The database username</summary>
        public string Username { get; set; }
        /// <summary>The remote</summary>
        public string Remote { get; set; }
        /// <summary>The max connections</summary>
        public int MaxConnections { get; set; }
        /// <summary>The creation date</summary>
        public DateTimeOffset CreatedAt { get; set; }
        /// <summary>The last updated date</summary>
        public DateTimeOffset UpdatedAt { get; set; }
    }

    /// <summary>Represents the databases datum</summary>
    public class DatabaseDatum
    {
        /// <summary>Object</summary>
        public string Object { get; set; }
        /// <summary>The data</summary>
        public DatabaseAttributes Attributes { get; set; }
    }

    /// <summary>Represents the databases</summary>
    public class Database
    {
        /// <summary>Object</summary>
        public string Object { get; set; }
        /// <summary>The data</summary>
        public List<DatabaseDatum> Data { get; set; }
    }

    /// <summary>Represents the relationships</summary>
    public class Relationships
    { 
        public Database Databases { get; set; }
    }

    /// <summary>Represents the Attributes</summary>
    public class Attributes
    {
        /// <summary>The id</summary>
        [JsonProperty("id")]
        public long Id { get; set; }
        /// <summary>The external id</summary>
        [JsonProperty("external_id")]
        public string ExternalId { get; set; }
        /// <summary>The uuid</summary>
        [JsonProperty("uuid")]
        public Guid Uuid { get; set; }
        /// <summary>The identifier</summary>
        [JsonProperty("identifier")]
        public string Identifier { get; set; }
        /// <summary>The name</summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>The description</summary>
        [JsonProperty("description")]
        public string Description { get; set; }
        /// <summary>The suspended status</summary>
        [JsonProperty("suspended")]
        public bool Suspended { get; set; }
        /// <summary>The droplet limits</summary>
        [JsonProperty("limits")]
        public Limits Limits { get; set; }
        /// <summary>The limits of features</summary>
        [JsonProperty("feature_limits")]
        public FeatureLimits FeatureLimits { get; set; }
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
        /// <summary>Th egg id</summary>
        [JsonProperty("egg")]
        public int Egg { get; set; }
        /// <summary>The pack id</summary>
        [JsonProperty("pack")]
        public int? Pack { get; set; }
        /// <summary>The docker container info</summary>
        [JsonProperty("container")]
        public Container Container { get; set; }
        /// <summary>The environment settings</summary>
        [JsonProperty("environment")]
        public Dictionary<string, string> Environment { get; set; }
        /// <summary>The last updated date</summary>
        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }
        /// <summary>The creation date</summary>
        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }
    }

    /// <summary>Represent the api return data</summary>
    public class ServerDatum
    {
        /// <summary>Attributes</summary>
        [JsonProperty("attributes", Required = Required.Always)]
        public Attributes Attributes { get; set; }
    }

    /// <summary>Represent the api return data as a list</summary>
    public class Server
    {
        /// <summary>All servers</summary>
        public List<ServerDatum> Data { get; set; }
    }
}