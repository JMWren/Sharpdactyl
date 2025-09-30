using Newtonsoft.Json;
using System;

namespace SharpdactylLib.Models.Application.Users
{
    /// <summary>
    /// Represents the full results of an application user http request
    /// </summary>
    public class ApplicationUserContainerResult
    {
        /// <summary>Application User data</summary>
        [JsonProperty("data", Required = Required.Always)]
        public ApplicationUserContainer[] Data { get; set; }
    }

    /// <summary>
    /// Represents the data inside an application user http request
    /// </summary>
    public class ApplicationUserContainer
    {
        /// <summary>Application user attributes</summary>
        [JsonProperty("attributes", Required = Required.Always)]
        public ApplicationUser Attributes { get; set; }
    }

    /// <summary>
    /// Represents an application user's attributes
    /// </summary>
    public class ApplicationUser : User
    {
        /// <summary>The user id</summary>
        [JsonProperty("id", Required = Required.Always)]
        public long Id { get; set; }
        /// <summary>The user's external id</summary>
        [JsonProperty("external_id", Required = Required.AllowNull)]
        public string ExternalId { get; set; }
        /// <summary>The user's first name</summary>
        [JsonProperty("first_name", Required = Required.Always)]
        public string FirstName { get; set; }
        /// <summary>The user's last name</summary>
        [JsonProperty("last_name", Required = Required.Always)]
        public string LastName { get; set; }
        /// <summary>The user's language</summary>
        [JsonProperty("language", Required = Required.Always)]
        public string Language { get; set; }
        /// <summary>Whether user is an admin</summary>
        [JsonProperty("root_admin", Required = Required.Always)]
        public bool RootAdmin { get; set; }
        /// <summary>Whether two-factor auth is enabled</summary>
        [JsonProperty("2fa", Required = Required.Always)]
        public bool Is2faEnabled { get; set; }
        /// <summary>The user's last updated time</summary>
        [JsonProperty("updated_at", Required = Required.Always)]
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
