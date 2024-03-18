namespace ViaCEP.Api;

public interface IEnderecoService
{
    Task<EnderecoDto?> ObterEndereco(string cep);
}