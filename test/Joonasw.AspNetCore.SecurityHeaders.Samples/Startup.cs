﻿using Joonasw.AspNetCore.SecurityHeaders.Samples.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace Joonasw.AspNetCore.SecurityHeaders.Samples
{
    // ReSharper disable once ClassNeverInstantiated.Global
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
            services.Configure<HstsOptions>(Configuration.GetSection("Hsts"));
            services.Configure<CspOptions>(Configuration.GetSection("Csp"));
            services.Configure<HpkpOptions>(Configuration.GetSection("Hpkp"));

            // Add framework services.
            services.AddMvc();

            services.AddCsp(nonceByteAmount: 32);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseHttpsEnforcement();
                app.UseHsts(new HstsOptions(TimeSpan.FromDays(30), includeSubDomains: false, preload: false));

                // Replace previous call to use injected options loaded from the appsettings.json file
                // app.UseHsts();

                app.UseHpkp(hpkp =>
                {
                    hpkp.UseMaxAgeSeconds(30 * 24 * 60 * 60)
                        .AddSha256Pin("nrmpk4ZI3wbRBmUZIT5aKAgP0LlKHRgfA2Snjzeg9iY=")
                        .SetReportOnly()
                        .ReportViolationsTo("/hpkp-report");
                });

                // Replace previous call to use injected options loaded from the appsettings.json file
                // app.UseHpkp();
            }

            app.UseStaticFiles();

            app.UseCsp(csp =>
            {
                //csp.EnableSandbox()
                //    .AllowScripts();
                csp.AllowScripts
                    .FromSelf()
                    .From("localhost:1591")
                    .From("ajax.aspnetcdn.com")
                    .AddNonce();

                csp.AllowStyles
                    .FromSelf()
                    .From("ajax.aspnetcdn.com")
                    .AddNonce();

                csp.AllowImages
                    .FromSelf();

                csp.AllowConnections
                    .ToSelf();

                csp.AllowAudioAndVideo
                    .FromNowhere();

                csp.AllowChildren
                    .FromNowhere();

                csp.AllowConnections
                    .To("ws://localhost:1591")
                    .To("http://localhost:1591")
                    .ToSelf();

                csp.AllowFonts
                    .FromSelf()
                    .From("ajax.aspnetcdn.com");

                csp.AllowPlugins
                    .FromNowhere();

                csp.AllowFraming
                    .FromNowhere();

                csp.SetReportOnly();
                csp.ReportViolationsTo("/csp-report");
            });

            // Replace previous call to use injected options loaded from the appsettings.json file
            // app.UseCsp();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "csp-report",
                    template: "csp-report",
                    defaults: new { controller = "Report", action = "Csp" });

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
