using Newtonsoft.Json;

namespace SharpdactylLib.Models.Client.Servers
{
    /// <summary>
    /// Represents the full results of a client server http request
    /// </summary>
    public class ClientServerContainerResult
    {
        public ClientServerContainer[] Data { get; set; }
    }

    /// <summary>
    /// Represents all the data inside of a client server http request
    /// </summary>
    public class ClientServerContainer
    {
        public ClientServer Attributes { get; set; }
    }

    /// <summary>
    /// Represents all the attributes of a client server
    /// </summary>
    public class ClientServer : Server
    {
        /// <summary>True when server is owned by account that generated the client key</summary>
        [JsonProperty("server_owner")]
        public bool ServerOwner { get; set; }
        /// <summary>The name of the node the server is on</summary>
        [JsonProperty("node")]
        public string Node { get; set; }
        /// <summary>The secure file-transfer protocol details</summary>
        [JsonProperty("sftp_details")]
        public SftpDetails SftpDetails { get; set; }
        /// <summary>The suspended status</summary>
        [JsonProperty("is_suspended")]
        public bool IsSuspended { get; set; }
        /// <summary>The install status</summary>
        [JsonProperty("is_installing")]
        public bool IsInstalling { get; set; }
    }

    public class SftpDetails
    {
        public string Ip { get; set; }
        public int Port { get; set; }
    }
}
