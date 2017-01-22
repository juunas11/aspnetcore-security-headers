namespace Joonasw.AspNetCore.SecurityHeaders.Csp
{
    public interface ICspNonceService
    {
        /// <summary>
        /// Gets the generated nonce.
        /// </summary>
        /// <returns>Nonce generated when the service was initialized.
        /// Must be attached to CSP header and any inline style or script
        /// you want to use.</returns>
        string GetNonce();
    }
}