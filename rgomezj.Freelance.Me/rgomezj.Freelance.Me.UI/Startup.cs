using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using rgomezj.Freelance.Me.Core;
using rgomezj.Freelance.Me.Core.Settings;
using rgomezj.Freelance.Me.Data.Abstract;
using rgomezj.Freelance.Me.Data.Implementation.JSON;
using rgomezj.Freelance.Me.Data.Implementation.JSON.Config;
using rgomezj.Freelance.Me.Services.Abstract;
using rgomezj.Freelance.Me.Services.Implementation;

namespace rgomezj.Freelance.Me.UI
{
    public class Startup
    {

        IHostingEnvironment _environment;

        public Startup(IHostingEnvironment env)
        {
            string pathOfCommonSettingsFile = Path.Combine(env.ContentRootPath, "..", "Common");

            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .AddJsonFile("mysettings.json")
                .AddJsonFile($"mysettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
            _environment = env;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddAntiforgery(o => o.HeaderName = "XSRF-TOKEN");
            services.AddOptions();
            var JSONDatabaseConfiguration = Configuration.GetSection("JSONDatabase").Get<JSONDatabaseConfig>();
            var emailSettings = Configuration.GetSection("emailSettings").Get<EmailSettings>();
            var captchaSettings = Configuration.GetSection("captchaSettings").Get<CaptchaSettings>();

            JSONDatabaseConfiguration.BasePath = _environment.ContentRootPath + Path.DirectorySeparatorChar.ToString() + "App_Data" + Path.DirectorySeparatorChar.ToString() + "me" + Path.DirectorySeparatorChar.ToString();
            services.AddTransient<IGeneralInfoRepository>(s => new JSONGeneralInfoRepository(JSONDatabaseConfiguration));
            services.AddTransient<ISkillRepository>(s => new JSONSkillRepository(JSONDatabaseConfiguration));
            services.AddTransient<ICompanyRepository>(s => new JSONCompanyRepository(JSONDatabaseConfiguration));
            services.AddTransient<IReferenceRepository>(s => new JSONReferenceRepository(JSONDatabaseConfiguration));
            services.AddTransient<ITechnologyRepository>(s => new JSONTechnologyRepository(JSONDatabaseConfiguration));
            services.AddTransient<IAptitudeRepository>(s => new JSONAptitudeRepository(JSONDatabaseConfiguration));
            services.AddTransient<IEmailService>(s => new SendGridEmailService(emailSettings));
            services.AddTransient<ICaptchaValidationService>(s => new CaptchaValidationService(captchaSettings));
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
