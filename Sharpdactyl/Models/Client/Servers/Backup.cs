using Newtonsoft.Json;
using System;

namespace SharpdactylLib.Models.Client.Servers
{
    /// <summary>
    /// Represents the full results of a backup http request
    /// </summary>
    public class BackupContainerResult
    {
        public BackupContainer[] Data { get; set; }
    }

    /// <summary>
    /// Represents all the data inside of a client backup http request
    /// </summary>
    public class BackupContainer
    {
        public Backup Attributes { get; set; }
    }

    /// <summary>
    /// Represents the attributes of a server backup
    /// </summary>
    public class Backup
    {
        /// <summary>The backup uuid</summary>
        [JsonProperty("uuid")]
        public string Uuid { get; set; }
        /// <summary>The backup name</summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>Files that the backup ignores</summary>
        [JsonProperty("ignored_files")]
        public string[] IgnoredFiles { get; set; }
        /// <summary>The backup's sha256 hash</summary>
        [JsonProperty("sha256_hash")]
        public string Sha256Hash { get; set; }
        /// <summary>The backup byte size</summary>
        [JsonProperty("bytes")]
        public int Bytes { get; set; }
        /// <summary>The backup creation time</summary>
        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }
        /// <summary>The backup completion time</summary>
        [JsonProperty("completed_at")]
        public DateTimeOffset CompletedAt { get; set; }
    }

}
