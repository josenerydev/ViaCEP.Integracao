using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using WireMock.Server;

namespace ViaCep.Api.IntegrationTests;

public class CustomWebApplicationFactory<TProgram>
: WebApplicationFactory<TProgram> where TProgram : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        var wireMockServer = WireMockServer.Start();
        builder.ConfigureAppConfiguration(configurantionBuilder =>
        {
            configurantionBuilder.AddInMemoryCollection(
            [
                new("ViaCep:BaseAddress",wireMockServer.Urls[0])
            ]);
        }).ConfigureServices(collection => collection.AddSingleton(wireMockServer));
    }
}