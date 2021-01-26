using System.Net.Http;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;

namespace Paymentsense.Coding.Challenge.Api.Tests
{
    public abstract class HttpBaseTests
    {
        protected readonly HttpClient Client;

        protected HttpBaseTests()
        {
            var builder = new WebHostBuilder().UseStartup<Startup>()
                .ConfigureTestServices(ConfigureTestServices);
            var testServer = new TestServer(builder);
            Client = testServer.CreateClient();
        }

        protected virtual void ConfigureTestServices(IServiceCollection services)
        {
        }
    }
}