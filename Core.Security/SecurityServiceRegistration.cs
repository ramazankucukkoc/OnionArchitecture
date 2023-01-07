using Core.Security.JWT;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
