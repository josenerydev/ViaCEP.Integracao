namespace ViaCEP.Api;

public class EnderecoService : IEnderecoService
{
    private readonly ILogger<EnderecoService> _logger;
    private readonly IViaCepApi _viaCepApi;

    public EnderecoService(ILogger<EnderecoService> logger, IViaCepApi viaCepApi)
    {
        _logger = logger;
        _viaCepApi = viaCepApi;
    }

    public async Task<EnderecoDto?> ObterEndereco(string cep)
    {
        var response = await _viaCepApi.ObterEndereco(cep);

        if (response == null)
            return null;

        var content = response.Content;

        if (content == null)
            return null;

        return new EnderecoDto(
            default,
            content.Cep,
            content.Logradouro,
            content.Complemento,
            content.Bairro,
            content.Localidade,
            content.Uf,
            content.Ddd);
    }
}