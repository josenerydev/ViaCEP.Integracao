namespace ViaCEP.Api;

public record EnderecoDto(
    long Id,
    string Cep,
    string Logradouro,
    string Complemento,
    string Bairro,
    string Localidade,
    string Uf,
    string Ddd);