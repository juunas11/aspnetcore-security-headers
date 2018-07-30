using System;
using System.ComponentModel;
using System.Reflection;
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

        /// <summary>
        /// Gets the string value associated with the the corresponding enum option
        /// </summary>
        /// <param name="enum">Any Enum where DefaultValue attribute is defined.</param>
        /// <returns></returns>
        internal static string DefaultValue(this Enum @enum)
        {
            var lFieldInfo = @enum.GetType().GetField(@enum.ToString());

            var lDefaultValueAttribute =
                (DefaultValueAttribute[])lFieldInfo.GetCustomAttributes(
                    typeof(DefaultValueAttribute),
                    false);

            return lDefaultValueAttribute.Length > 0 ? lDefaultValueAttribute[0].Value.ToString() : @enum.ToString();
        }
    }
}
