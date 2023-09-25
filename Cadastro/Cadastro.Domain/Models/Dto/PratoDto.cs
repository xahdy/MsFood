using System.ComponentModel.DataAnnotations;

namespace Cadastro.Domain.Models.Dto
{
    public class PratoDto
    {
        public PratoDto(string nome, string descricao, decimal preco)
        {
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
        }
        [Required(ErrorMessage = "É necessário informar o nome do prato")]
        public string Nome { get; private set; }

        [Required(ErrorMessage = "É necessário informar a descrição do prato")]
        public string Descricao { get; private set; }
        public RestauranteDto? Restaurante { get; private set; }

        [Required(ErrorMessage = "É necessário informar o preço do prato")]
        public decimal Preco { get; private set; }
    }
}
