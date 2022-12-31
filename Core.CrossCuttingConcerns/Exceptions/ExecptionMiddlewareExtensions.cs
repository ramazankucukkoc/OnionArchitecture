using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Exceptions
{
    public static class ExecptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomExcepitonMiddleware(this IApplicationBuilder application)
        {
           return application.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
