using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System.Net;

namespace TestTaskCrawler
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
        
        //public static void Main(string[] args) =>
        //    BuildWebHost(args).Run();

        //public static IWebHost BuildWebHost(string[] args) =>
        //WebHost.CreateDefaultBuilder(args)
        //    .UseStartup<Startup>()
        //    .UseHttpSys(options =>
        //    {
        //        options.Authentication.Schemes =
        //            AuthenticationSchemes.Ntlm | AuthenticationSchemes.Negotiate;
        //        options.Authentication.AllowAnonymous = false;
        //    })
        //    .Build();
    }
}
