namespace Cadastro.Domain.Models.Dto
{
    public class LocalizacaoDto
    {
        public LocalizacaoDto(string cep, string endereco)
        {
            Cep = cep;
            Endereco = endereco;
        }

        public string Cep { get; private set; }
        public string Endereco { get; private set; }
    }
}