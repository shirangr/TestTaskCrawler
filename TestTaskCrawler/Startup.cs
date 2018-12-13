using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using TestTaskCrawler.DAL;
using Microsoft.Extensions.Logging;

namespace TestTaskCrawler
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


            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //services.AddDbContext<ApiContext>(opt => opt.UseInMemoryDatabase());

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else if (env.IsProduction() || env.IsStaging() || env.IsEnvironment("Staging_2"))
            {
                app.UseExceptionHandler("Home/Error");
                app.UseHsts();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseMvc();


            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "Default",
                    template: "{controller=Home}/{action=Login}/{id?}");

                //routes.MapRoute(
                //    name: "ForgotPassword",
                //    template: "{controller=ForgotPassword}/{action=ResetPassword}/{id?}");

                routes.MapRoute(
                    name: "ResetPassword",
                    template: "{controller=Home}/{action=ResetPassword}/{id?}");

                routes.MapRoute(
                    name: "SearchProduct",
                    template: "{controller=Home}/{action=SearchProduct}/{id?}");

                routes.MapRoute(
                    name: "Signup",
                    template: "{controller=Home}/{action=Signup}/{id?}");

            });

            ///**********for entity framework**************///
            //var context = serviceProvider.GetService<ApiContext>();
            //AddTestData(context);

            ///************************///
        }


    }
}
