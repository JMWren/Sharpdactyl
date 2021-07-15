using Newtonsoft.Json;

namespace SharpdactylLib.Models.Client.Account
{
    /// <summary>
    /// Represents all the data inside the client account http request
    /// </summary>
    public class AccountContainer
    {
        /// <summary>The account attributes</summary>
        public Account Attributes { get; set; }
    }

    /// <summary>
    /// Represents a client user account
    /// </summary>
    public class Account
    {
        /// <summary>The account id</summary>
        [JsonProperty("id")]
        public int Id { get; set; }
        /// <summary>Whether the account has admin privileges</summary>
        [JsonProperty("admin")]
        public bool Admin { get; set; }
        /// <summary>The account username</summary>
        [JsonProperty("username")]
        public string Username { get; set; }
        /// <summary>The account email</summary>
        [JsonProperty("email")]
        public string Email { get; set; }
        /// <summary>The account's first name</summary>
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        /// <summary>The account's last name</summary>
        [JsonProperty("last_name")]
        public string LastName { get; set; }
        /// <summary>The account's preferred language</summary>
        [JsonProperty("language")]
        public string Language { get; set; }
    }

}
