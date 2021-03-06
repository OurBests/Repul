﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using web.Interfaces;
using web.Middlewares;
using web.Models;
using web.Services;

namespace web
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.Configure<ServiceConfiguration>(Configuration.GetSection("ServiceConfiguration"));

            services.AddSingleton<IRequestManagerService, RequestManagerService>();
            services.AddTransient<ITwoStepVerificationService, TwoStepVerificationService>();
            services.AddTransient<IBankAccountService, BankAccountService>();
            services.AddTransient<IPersonalPortalService, PersonalPortalService>();
            services.AddTransient<IPaymentService, PaymentService>();
            services.AddTransient<IDestinationPortalService, DestinationPortalService>();
            services.AddTransient<IReportService, ReportService>();
            services.AddTransient<IProfileService, ProfileService>();
            services.AddTransient<IFileService, FileService>();

            services.AddDataProtection()
            .PersistKeysToFileSystem(new DirectoryInfo("keys"))
            .SetApplicationName("web")
            .SetDefaultKeyLifetime(TimeSpan.FromDays(7));


            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(config=> {
                config.LoginPath = "/Login";
                config.SlidingExpiration = true;
                config.ExpireTimeSpan = TimeSpan.FromDays(1);
            });
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }


            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();
            ///app.UseMiddleware(typeof(ExceptionCustomHandlerMiddleware));
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
