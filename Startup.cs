using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;

namespace HelloWeb
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            String hostname = Dns.GetHostName();
            // Console.WriteLine("Host" + hostname);            
            app.Run(context =>
            {
                return context.Response.WriteAsync("Hello C# .NET " + hostname);
            });
        }
    }
}
