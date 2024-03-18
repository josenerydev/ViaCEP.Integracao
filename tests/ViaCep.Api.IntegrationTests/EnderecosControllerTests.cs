using FluentAssertions;

using Microsoft.Extensions.DependencyInjection;

using System.Net;
using System.Net.Http.Json;

using ViaCEP.Api;

using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;

namespace ViaCep.Api.IntegrationTests;

public class EnderecosControllerTests
    : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly CustomWebApplicationFactory<Program> _factory;
    private readonly WireMockServer _wireMockServer;

    public EnderecosControllerTests(CustomWebApplicationFactory<Program> factory)
    {
        _factory = factory;
        _wireMockServer = _factory.Services.GetRequiredService<WireMockServer>();
    }

    [Fact]
    public async Task ObterEndereco_PorCep_RetornaDetalhesDoEndereco()
    {
        // Arrange
        var expectedEndereco = new EnderecoDto(
            default,
            "36090-702",
            "Rua Maria Soares da Silva",
            "(Vl Esperança II)",
            "Benfica",
            "Juiz de Fora",
            "MG",
            "32");

        var cep = "36090702";

        _wireMockServer.Given(
            Request.Create().WithPath($"/ws/{cep}/json"))
            .RespondWith(Response.Create().WithBodyFromFile(GetResponseFilePath("36090702.json")));

        var httpClient = _factory.CreateClient();

        // Act
        var response = await httpClient.GetAsync($"/api/Enderecos/{cep}");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var responseObject = await response.Content.ReadFromJsonAsync<EnderecoDto>();
        responseObject.Should().BeEquivalentTo(expectedEndereco);
    }

    private string GetResponseFilePath(string fileName)
    {
        return Path.Combine(Directory.GetCurrentDirectory(), "ResponseMocks", fileName);
    }
}