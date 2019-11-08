using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace MiddlewareDemo
{
    public class SampleMiddleware
    {
        private RequestDelegate _next;

        public SampleMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task Invoke(HttpContext contex)
        {
            await contex.Response.WriteAsync("<br/> <h2> From Sample Middleware - Request</h2>");
            await _next.Invoke(contex);
            await contex.Response.WriteAsync("<br/> <h2> From Sample Middleware - Response</h2>");
        }
    }


    public static class MiddlewareExtensionssdf
    {
        public static void UseSample(this IApplicationBuilder app)
        {
            app.UseMiddleware<SampleMiddleware>();
        }
    }
}
