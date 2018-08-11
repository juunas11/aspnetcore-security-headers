namespace Joonasw.AspNetCore.SecurityHeaders
{
    public class XXssProtectionOptions
    {
        /// <summary>
        /// Defines the parameters for the X-Xss-Protection header with protection and block enabled
        /// </summary>
        public XXssProtectionOptions()
            : this(true, true)
        {

        }

        /// <summary>
        /// Defines the parameters for the X-Xss-Protection header sent in response to clients
        /// </summary>
        /// <param name="enableProtection">Enable protection for this host</param>
        /// <param name="enableAttackBlock">Block the response if it detects an attack rather than sanitising the script</param>
        public XXssProtectionOptions(bool enableProtection, bool enableAttackBlock)
        {
            EnableProtection = enableProtection;
            EnableAttackBlock = enableAttackBlock;
        }

        /// <summary>
        /// Get the Enable Protection value for enabling or disabling Protection
        /// Enabled by default.
        /// </summary>
        public bool EnableProtection { get; set; }

        /// <summary>
        /// Gets the Enable Block value to block the response if it detects an attack rather than sanitising the script
        /// Enabled by default.
        /// </summary>
        public bool EnableAttackBlock { get; set; }

        public string BuildHeaderValue()
        {
            var headerValue = EnableProtection ? "1" : "0";
            if (EnableAttackBlock)
            {
                headerValue += "; mode=block";
            }

            return headerValue;
        }
    }
}
