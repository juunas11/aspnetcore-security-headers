using Joonasw.AspNetCore.SecurityHeaders.Csp;
using Microsoft.Extensions.DependencyInjection;

namespace Joonasw.AspNetCore.SecurityHeaders
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCsp(this IServiceCollection services, int nonceByteAmount = 32)
        {
            return services.AddScoped<CspNonceService>(svcProvider => new CspNonceService(nonceByteAmount));
        }
    }
}
