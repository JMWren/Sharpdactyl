using System;
using Newtonsoft.Json;

namespace SharpdactylLib.Models.Client.Account
{
    /// <summary>
    /// Represents the full results of an api key http request
    /// </summary>
    public class ApiKeyContainerResult
    {
        /// <summary>Api key request data</summary>
        public ApiKeyContainer[] Data { get; set; }
    }

    /// <summary>
    /// Represents the data inside of an api key http request
    /// </summary>
    public class ApiKeyContainer
    {
        /// <summary>Api key attributes</summary>
        public ApiKey Attributes { get; set; }
    }

    /// <summary>
    /// Represents a client api key properties
    /// </summary>
    public class ApiKey
    {
        /// <summary>The api key string identifier<summary>
        [JsonProperty("identifier")]
        public string Identifier { get; set; }
        /// <summary>The api key description<summary>
        [JsonProperty("description")]
        public string Description { get; set; }
        /// <summary>Ips authorized to use api key<summary>
        [JsonProperty("allowed_ips")]
        public string[] AllowedIps { get; set; }
        /// <summary>Api key's last used time<summary>
        [JsonProperty("last_used_at")]
        public DateTimeOffset LastUsedAt { get; set; }
        /// <summary>Api key's creation time<summary>
        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }
    }

}
