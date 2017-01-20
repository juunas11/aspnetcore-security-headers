using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.IO;
using Joonasw.AspNetCore.SecurityHeaders;
using Microsoft.Extensions.FileProviders;

namespace WebApplication1
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

            services.AddCsp(nonceByteAmount: 32);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug(LogLevel.Debug);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseHsts(new HstsOptions
                {
                    Seconds = 30 * 24 * 60 * 60,
                    IncludeSubDomains = false,
                    Preload = false
                });

                //app.UseHpkp(hpkp =>
                //{
                //    hpkp.UseMaxAgeSeconds(30 * 24 * 60 * 60)
                //        .AddSha256Pin("abc")
                //        .AddSha256Pin("bcd")
                //        .IncludeSubDomains()
                //        .SetReportOnly()
                //        .ReportViolationsTo("/hpkp-report");
                //});
            }
            
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "static"))
            });

            app.UseCsp(csp =>
            {
                csp.AllowScripts
                    .FromSelf()
                    .From("www.google.com")
                    .AllowUnsafeInline()
                    .AllowUnsafeEval()
                    .AddNonce();

                csp.AllowStyles
                    .FromSelf()
                    .From("www.google.com")
                    .AddNonce();

                csp.SetReportOnly();
                csp.ReportViolationsTo("/csp-report");
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "csp-report",
                    template: "csp-report",
                    defaults: new {controller = "Report", action = "Csp"});

                routes.MapRoute(
                    name: "hpkp-report",
                    template: "hpkp-report",
                    defaults: new { controller = "Report", action = "Hpkp" });

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
