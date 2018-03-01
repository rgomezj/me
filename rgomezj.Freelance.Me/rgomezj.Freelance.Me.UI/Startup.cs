using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using rgomezj.Freelance.Me.Core;
using rgomezj.Freelance.Me.Data.Abstract;
using rgomezj.Freelance.Me.Data.Implementation.JSON;
using rgomezj.Freelance.Me.Data.Implementation.JSON.Config;

namespace rgomezj.Freelance.Me.UI
{
    public class Startup
    {
     

        public Startup(IHostingEnvironment env)
        {
            // Set up configuration sources.
            var filePath = env.ContentRootPath  + Path.DirectorySeparatorChar.ToString() + "App_Data" + Path.DirectorySeparatorChar.ToString() + "rgomez.Freelance.me.json";
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddOptions();
            services.AddTransient<IGeneralInfoRepository>(s => new JSONGeneralInfoRepository(Configuration.GetSection("JSONDatabase").Get<JSONDatabaseConfig>()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });
        }
    }
}
