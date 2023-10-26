using Cadastro.Domain.Models.Dto;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cadastro.Domain.Models
{
    public class Prato : BaseEntity
    {
        public Prato(string nome, string descricao, decimal preco)
        {
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
        }

        public string Nome { get; private set; }
        public string Descricao { get; private set; }

        [ForeignKey("Restaurante")]
        public int RestauranteId { get; private set; }
        public Restaurante? Restaurante { get; private set;}
        public decimal Preco { get; private set; }

        public void DefinirRestaurante(Restaurante restaurante) 
        {
            RestauranteId = restaurante.Id;
            Restaurante = restaurante;
        }
        public void AtualizarPrato(PratoDto pratoDto)
        {
            Nome = pratoDto.Nome;
            Descricao = pratoDto.Descricao;
            Preco = pratoDto.Preco;
        }
    }
}
