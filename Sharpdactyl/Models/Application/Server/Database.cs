using Newtonsoft.Json;
using System;


namespace SharpdactylLib.Models.Application.Server
{
    /// <summary>Represents the databases</summary>
    public class Database
    {
        /// <summary>The data</summary>
        [JsonProperty("data", Required = Required.Always)]
        public DatabaseDatum[] Data { get; set; }
    }

    /// <summary>Represents the databases datum</summary>
    public class DatabaseDatum
    {
        /// <summary>The database data</summary>
        [JsonProperty("attributes", Required = Required.Always)]
        public Attributes Attributes { get; set; }
    }

    /// <summary>Represents the database attributes</summary>
    public class Attributes
    {
        /// <summary>The database id</summary>
        public long Id { get; set; }
        /// <summary>The database's assigned server</summary>
        public int Server { get; set; }
        /// <summary>The database host</summary>
        public int Host { get; set; }
        /// <summary>The database name</summary>
        public string Database { get; set; }
        /// <summary>The database username</summary>
        public string Username { get; set; }
        /// <summary>The database remote</summary>
        public string Remote { get; set; }
        /// <summary>The max connections</summary>
        public int MaxConnections { get; set; }
        /// <summary>The database creation date</summary>
        public DateTimeOffset CreatedAt { get; set; }
        /// <summary>The database's last updated date</summary>
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
