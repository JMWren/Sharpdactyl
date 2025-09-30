using Newtonsoft.Json;

namespace SharpdactylLib.Models.Client.Servers
{
    /// <summary>
    /// Represents the full results of a client user http request
    /// </summary>
    public class ClientUserContainerResult
    {
        public ClientUserContainer[] Data { get; set; }
    }

    /// <summary>
    /// Represents all the data inside of a client user http request
    /// </summary>
    public class ClientUserContainer
    {
        public ClientUser Attributes { get; set; }
    }

    /// <summary>
    /// Represents the attributes of a client user
    /// </summary>
    public class ClientUser : User
    {
        /// <summary>The user's profile picture</summary>
        [JsonProperty("image", Required = Required.Always)]
        public string Image { get; set; }
        /// <summary>Whether two-factor auth is enabled</summary>
        [JsonProperty("2fa_enabled", Required = Required.Always)]
        public bool Is2faEnabled { get; set; }
    }

}
