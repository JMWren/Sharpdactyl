
namespace SharpdactylLib.Models.Client.Account
{
    /// <summary>
    /// Represents the data inside of a two factor http request
    /// </summary>
    public class TwoFactorContainer
    {
        /// <summary>2fa data</summary>
        public TwoFactor Data { get; set; }
    }

    /// <summary>
    /// Represents the two factor secret properties
    /// </summary>
    public class TwoFactor
    {
        /// <summary>Link to TOTP QR code to set up 2fa</summary>
        public string ImageUrlData { get; set; }
    }

    /// <summary>
    /// Represents the data inside of a 2fa enable http request
    /// </summary>
    public class RecoveryTokensContainer
    {
        public RecoveryTokens Attributes { get; set; }
    }

    /// <summary>
    /// Represents the collection of recovery tokens for 2fa
    /// </summary>
    public class RecoveryTokens
    {
        /// <summary>The array of account recovery tokens</summary>
        public string[] Tokens { get; set; }
    }

}
