namespace Cadastro.Domain.Models.Dto
{
    public class LocalizacaoDto
    {
        public LocalizacaoDto(string cep, string? logradouro, string numero, string? bairro, string? localidade, string? uf)
        {
            Cep = cep;
            Logradouro = logradouro;
            Numero = numero;
            Bairro = bairro;
            Localidade = localidade;
            Uf = uf;
        }

        public string? Cep { get; private set; }
        public string? Logradouro { get; private set; }
        public string Numero { get; private set; }
        public string? Bairro { get; private set; }
        public string? Localidade { get; private set; }
        public string? Uf { get; private set; }

        public void CompletarLocalizacao(EnderecoEncontrado endereco) 
        {
            Logradouro = endereco.logradouro;
            Bairro = endereco.bairro;
            Localidade = endereco.localidade;
            Uf = endereco.uf;
        }
    }

    public class EnderecoEncontrado 
    {
        public string cep { get; set; }
        public string logradouro { get; set; }
        public string complemento { get; set; }
        public string bairro { get; set; }
        public string localidade { get; set; }
        public string uf { get; set; }
        public string ibge { get; set; }
        public string gia { get; set; }
        public string ddd { get; set; }
        public string siafi { get; set; }
    }
}