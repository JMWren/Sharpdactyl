using Newtonsoft.Json;
using System;

namespace SharpdactylLib.Models.Application.Nodes
{
    /// <summary>
    /// Represents the full results of a node http request
    /// </summary>
    public class NodeContainerResult
    {
        /// <summary>The nodes</summary>
        [JsonProperty("data")]
        public NodeContainer[] Data { get; set; }
    }

    /// <summary>
    /// Represents the data of a node http request
    /// </summary>
    public class NodeContainer
    {
        /// <summary>The attributes</summary>
        [JsonProperty("attributes")]
        public Node Attributes { get; set; }
    }

    /// <summary>
    /// Represents the attributes of a node
    /// </summary>
    public class Node
    {
        /// <summary>The id</summary>
        [JsonProperty("id")]
        public long Id { get; set; }
        /// <summary>The uuid</summary>
        [JsonProperty("uuid")]
        public Guid Uuid { get; set; }
        /// <summary>Public</summary>
        [JsonProperty("public")]
        public bool Public { get; set; }
        /// <summary>The name</summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>The description</summary>
        [JsonProperty("description")]
        public string Description { get; set; }
        /// <summary>The location id</summary>
        [JsonProperty("location_id")]
        public long LocationId { get; set; }
        /// <summary>the FQDN</summary>
        [JsonProperty("fqdn")]
        public string Fqdn { get; set; }
        /// <summary>The scheme</summary>
        [JsonProperty("scheme")]
        public string Scheme { get; set; }
        /// <summary>Is it behind a proxy</summary>
        [JsonProperty("behind_proxy")]
        public bool BehindProxy { get; set; }
        /// <summary>Whether server is in maintenance mode</summary>
        [JsonProperty("maintenance_mode")]
        public bool MaintenanceMode { get; set; }
        /// <summary>Total total usable memory (MB)</summary>
        [JsonProperty("memory")]
        public long Memory { get; set; }
        /// <summary>Max memory overallocate</summary>
        [JsonProperty("memory_overallocate")]
        public long MemoryOverallocate { get; set; }
        /// <summary>The total usable storage (MB)</summary>
        [JsonProperty("disk")]
        public long Disk { get; set; }
        /// <summary>Max storage overallocate</summary>
        [JsonProperty("disk_overallocate")]
        public long DiskOverallocate { get; set; }
        /// <summary>The upload size</summary>
        [JsonProperty("upload_size")]
        public long UploadSize { get; set; }
        /// <summary>Deamon port</summary>
        [JsonProperty("daemon_listen")]
        public long DaemonListen { get; set; }
        /// <summary>Deamon sftp port</summary>
        [JsonProperty("daemon_sftp")]
        public long DaemonSftp { get; set; }
        /// <summary>Daemon sftp url</summary>
        [JsonProperty("daemon_base")]
        public string DaemonBase { get; set; }
        /// <summary>Date of creation</summary>
        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }
        /// <summary>Date of update</summary>
        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
