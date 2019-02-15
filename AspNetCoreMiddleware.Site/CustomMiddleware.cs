using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace AspNetCoreMiddleware.Site
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate _requestDelegate;

        public CustomMiddleware(RequestDelegate next)
        {
            _requestDelegate = next;
        }

        public async Task Invoke(HttpContext context)
        {
            // ... work with HttpContext in handling the incoming request ... 

            await _requestDelegate.Invoke(context);

            // ... work with HttpContext in handling the outgoing response ... 
        }
    }

    public static class IApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<CustomMiddleware>();
        }
    }
}
