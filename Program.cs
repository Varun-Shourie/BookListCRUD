using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookListRazor
{
    public class Program
    {
        // At this point, this becomes an ASP.NET core application.
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }


        // Returns IHostBuilder
        // CreateDefaultBuilder -- deals with web server configuration files, routing, etc. 
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
