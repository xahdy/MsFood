using Cadastro.Domain.ValueObject;
using System.ComponentModel.DataAnnotations;

namespace Cadastro.Domain.Models.Dto
{
    public class RestauranteDto
    {
        public RestauranteDto(string proprietario, string nome, string cnpj, LocalizacaoDto localizacao)
        {
            Proprietario = proprietario;
            Nome = nome;
            Cnpj = cnpj;
            Localizacao = localizacao;
        }

        [Required(ErrorMessage = "É necessário informar o o nome do proprietário do restaurante")]
        public string Proprietario { get; private set; }

        [Required(ErrorMessage = "É necessário informar o Nome do restaurante")]
        public string Nome { get; private set; }

        [Required(ErrorMessage = "É necessário informar o Cnpj do restaurante")]
        public string Cnpj { get; private set; }
        public LocalizacaoDto? Localizacao { get; private set; }
    }
}
