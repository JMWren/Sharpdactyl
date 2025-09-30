using Newtonsoft.Json;
using System;

namespace SharpdactylLib.Models
{
    /// <summary>
    /// Represents the attributes of all users
    /// </summary>
    public abstract class User
    {
        /// <summary>The user's unique identifier</summary>
        [JsonProperty("uuid", Required = Required.Always)]
        public Guid Uuid { get; set; }
        /// <summary>The user's username</summary>
        [JsonProperty("username", Required = Required.Always)]
        public string Username { get; set; }
        /// <summary>The user's email</summary>
        [JsonProperty("email", Required = Required.Always)]
        public string Email { get; set; }
        /// <summary>The user's creation time</summary>
        [JsonProperty("created_at", Required = Required.Always)]
        public DateTime CreatedAt { get; set; }
        /// <summary>The user's server permissions</summary>
        [JsonProperty("permissions", Required = Required.Always)]
        public string[] Permissions { get; set; }
    }
}
