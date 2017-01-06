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
                return context.Response.WriteAsync("VERSION 1.0 -- the HOST running this program is named: " + hostname);
            });
        }
    }
}
