using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Paymentsense.Coding.Challenge.Api
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}