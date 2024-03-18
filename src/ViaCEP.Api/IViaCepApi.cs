using Refit;

namespace ViaCEP.Api;

public interface IViaCepApi
{
    [Get("/ws/{cep}/json")]
    Task<ApiResponse<EnderecoResponse>> ObterEndereco(string cep);
}