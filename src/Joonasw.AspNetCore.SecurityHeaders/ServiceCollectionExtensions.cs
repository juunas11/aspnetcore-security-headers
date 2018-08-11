using Joonasw.AspNetCore.SecurityHeaders.Csp;
using Microsoft.Extensions.DependencyInjection;

namespace Joonasw.AspNetCore.SecurityHeaders
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds dependencies required for adding
        /// nonces to Content Security Policy headers
        /// and inline scripts and styles.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="nonceByteAmount">Length of the nonces to generate in bytes.</param>
        /// <returns>The <see cref="IServiceCollection"/></returns>
        public static IServiceCollection AddCsp(this IServiceCollection services, int nonceByteAmount = 32)
        {
            return services.AddScoped<ICspNonceService>(svcProvider => new CspNonceService(nonceByteAmount));
        }
    }
}
