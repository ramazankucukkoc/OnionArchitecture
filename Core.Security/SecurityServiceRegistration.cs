using Core.Security.JWT;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Security
{
    public static class SecurityServiceRegistration
    {
        public static IServiceCollection AddSecurityService(this IServiceCollection services)
        {
            services.AddTransient<ITokenHelper, JwtHelper>();
            return services;
        }
    }
}
