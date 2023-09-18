namespace Cadastro.Domain.Models
{
    public class Localizacao : BaseEntity
    {
        public Localizacao(string cep, string logradouro, string numero, string bairro, string localidade, string uf)
        {
            Cep = cep;
            Logradouro = logradouro;
            Numero = numero;
            Bairro = bairro;
            Localidade = localidade;
            Uf = uf;
        }

        public string Cep { get; private set; }
        public string Logradouro { get; private set; }
        public string Numero { get; private set; }
        public string Bairro { get; private set; }
        public string Localidade { get; private set; }
        public string Uf { get; private set; }
    }
}
