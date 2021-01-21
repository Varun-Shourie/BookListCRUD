using BookListRazor.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
// Not derived from any class
// 
/// </summary>

namespace BookListRazor
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // ApplicationDbContext has been added to the pipeline. Now we can use it through dependency injection. 
            services.AddDbContext<ApplicationDbContext>(option 
                => option.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            // Add API calls with controllers.
            services.AddControllersWithViews();
            services.AddRazorPages().AddRazorRuntimeCompilation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // Middleware
            app.UseHttpsRedirection();
            // CSS, JS files, etc.
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            // Endpoint routing - you can configure multiple routes. You can configure more than one endpoint for technologies. 
            app.UseEndpoints(endpoints =>
            {
                // Ensure Controller APIs are called.
                endpoints.MapControllers();
                endpoints.MapRazorPages();
            });
        }
    }
}
