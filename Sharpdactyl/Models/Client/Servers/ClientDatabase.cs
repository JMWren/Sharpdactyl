using Newtonsoft.Json;

namespace SharpdactylLib.Models.Client.Servers
{
    /// <summary>
    /// Represents the full results of a client database http request
    /// </summary>
    public class ClientDatabaseContainerResult
    {
        public ClientDatabaseContainer[] Data { get; set; }
    }

    /// <summary>
    /// Represents all the data inside a client database http request
    /// </summary>
    public class ClientDatabaseContainer
    {
        public ClientDatabase Attributes { get; set; }
    }

    /// <summary>
    /// Represents the attributes of a client database
    /// </summary>
    public class ClientDatabase : Database
    {
        /// <summary>The database string id</summary>
        [JsonProperty("id")]
        public string Id { get; set; }
        /// <summary>The host information</summary>
        [JsonProperty("host")]
        public Host Host { get; set; }
        /// <summary>The database name</summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>The database connections</summary>
        [JsonProperty("connections_from")]
        public string ConnectionsFrom { get; set; }
    }

    /// <summary>
    /// Represents the host info for a database
    /// </summary>
    public class Host
    {
        /// <summary>The database host address</summary>
        [JsonProperty("address")]
        public string Address { get; set; }
        /// <summary>The database open port</summary>
        [JsonProperty("port")]
        public int Port { get; set; }
    }
}
