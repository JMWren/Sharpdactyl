using Newtonsoft.Json;
using System;

namespace SharpdactylLib.Models.User
{
    /// <summary>Represents the user data</summary>
    public class UserDatum
    {
        /// <summary>Attributes</summary>
        [JsonProperty("attributes", Required = Required.Always)]
        public Attributes Attributes
        {
            get;
            set;
        }
    }

    /// <summary>Represents the user attributes</summary>
    public class Attributes
    {
        /// <summary>The user id</summary>
        [JsonProperty("id", Required = Required.Always)]
        public long Id
        {
            get;
            set;
        }

        /// <summary>The external id</summary>
        [JsonProperty("external_id", Required = Required.AllowNull)]
        public object ExternalId
        {
            get;
            set;
        }

        /// <summary>The uuid</summary>
        [JsonProperty("uuid", Required = Required.Always)]
        public Guid Uuid
        {
            get;
            set;
        }

        /// <summary>The username</summary>
        [JsonProperty("username", Required = Required.Always)]
        public string Username
        {
            get;
            set;
        }

        /// <summary>The email</summary>
        [JsonProperty("email", Required = Required.Always)]
        public string Email
        {
            get;
            set;
        }

        /// <summary>The first name</summary>
        [JsonProperty("first_name", Required = Required.Always)]
        public string FirstName
        {
            get;
            set;
        }

        /// <summary>The last name</summary>
        [JsonProperty("last_name", Required = Required.Always)]
        public string LastName
        {
            get;
            set;
        }

        /// <summary>The language</summary>
        [JsonProperty("language", Required = Required.Always)]
        public string Language
        {
            get;
            set;
        }

        /// <summary>Is Admin</summary>
        [JsonProperty("root_admin", Required = Required.Always)]
        public bool RootAdmin
        {
            get;
            set;
        }

        /// <summary>The 2fa status</summary>
        [JsonProperty("2fa", Required = Required.Always)]
        public bool The2Fa
        {
            get;
            set;
        }

        /// <summary>The created on date</summary>
        [JsonProperty("created_at", Required = Required.Always)]
        public DateTimeOffset CreatedAt
        {
            get;
            set;
        }

        /// <summary>The update on date</summary>
        [JsonProperty("updated_at", Required = Required.Always)]
        public DateTimeOffset UpdatedAt
        {
            get;
            set;
        }
    }
}
