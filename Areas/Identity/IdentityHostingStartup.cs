using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestTaskCrawler.Areas.Identity.Data;

[assembly: HostingStartup(typeof(TestTaskCrawler.Areas.Identity.IdentityHostingStartup))]
namespace TestTaskCrawler.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.AddDbContext<TestTaskCrawlerIdentityDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("TestTaskCrawlerIdentityDbContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(config =>
                {
                    config.SignIn.RequireConfirmedEmail = true;
                })
                    .AddEntityFrameworkStores<TestTaskCrawlerIdentityDbContext>();

            });
        }
    }
}