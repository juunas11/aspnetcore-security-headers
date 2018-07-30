namespace Joonasw.AspNetCore.SecurityHeaders.XXssProtection
{
    public class XXssProtectionOptions
    {
        public XXssProtectionOptions()
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
        public bool EnableProtection { get; set; } = true;

        /// <summary>
        /// Gets the Enable Block value to block the response if it detects an attack rather than sanitising the script
        /// Enabled by default.
        /// </summary>
        public bool EnableAttackBlock { get; set; } = true;
    }
}
