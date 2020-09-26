using Newtonsoft.Json;
using System;

namespace Sharpdactyl.Models.Node
{
    /// <summary>Represents the node Data</summary>
    public class NodeDatum
    {
        /// <summary>Object</summary>
        [JsonProperty("object", Required = Required.Always)]
        public string Object { get; set; }

        /// <summary>The attributes</summary>
        [JsonProperty("attributes", Required = Required.Always)]
        public Attributes Attributes { get; set; }
    }

    /// <summary>Represents the attributes</summary>
    public class Attributes
    {
        /// <summary>The id</summary>
        [JsonProperty("id", Required = Required.Always)]
        public long Id { get; set; }

        /// <summary>Public</summary>
        [JsonProperty("public", Required = Required.Always)]
        public bool Public { get; set; }

        /// <summary>The name</summary>
        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }

        /// <summary>The description</summary>
        [JsonProperty("description", Required = Required.Always)]
        public string Description { get; set; }

        /// <summary>The location id</summary>
        [JsonProperty("location_id", Required = Required.Always)]
        public long LocationId { get; set; }

        /// <summary>the FQDN</summary>
        [JsonProperty("fqdn", Required = Required.Always)]
        public string Fqdn { get; set; }

        /// <summary>The scheme</summary>
        [JsonProperty("scheme", Required = Required.Always)]
        public string Scheme { get; set; }

        /// <summary>Is it behind a proxy</summary>
        [JsonProperty("behind_proxy", Required = Required.Always)]
        public bool BehindProxy { get; set; }

        /// <summary>The maintenance mode</summary>
        [JsonProperty("maintenance_mode", Required = Required.Always)]
        public bool MaintenanceMode { get; set; }

        /// <summary>Total total usable memory (MB)</summary>
        [JsonProperty("memory", Required = Required.Always)]
        public long Memory { get; set; }

        /// <summary>Max memory overallocate</summary>
        [JsonProperty("memory_overallocate", Required = Required.Always)]
        public long MemoryOverallocate { get; set; }

        /// <summary>The total usable storage (MB)</summary>
        [JsonProperty("disk", Required = Required.Always)]
        public long Disk { get; set; }

        /// <summary>Max storage overallocate</summary>
        [JsonProperty("disk_overallocate", Required = Required.Always)]
        public long DiskOverallocate { get; set; }

        /// <summary>The upload size</summary>
        [JsonProperty("upload_size", Required = Required.Always)]
        public long UploadSize { get; set; }

        /// <summary>Deamon port</summary>
        [JsonProperty("daemon_listen", Required = Required.Always)]
        public long DaemonListen { get; set; }

        /// <summary>Deamon sftp port</summary>
        [JsonProperty("daemon_sftp", Required = Required.Always)]
        public long DaemonSftp { get; set; }

        /// <summary>Daemon sftp url</summary>
        [JsonProperty("daemon_base", Required = Required.Always)]
        public string DaemonBase { get; set; }

        /// <summary>Date of creation</summary>
        [JsonProperty("created_at", Required = Required.Always)]
        public DateTimeOffset CreatedAt { get; set; }

        /// <summary>Date of update</summary>
        [JsonProperty("updated_at", Required = Required.Always)]
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
