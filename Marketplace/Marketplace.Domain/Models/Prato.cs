using Marketplace.Domain.Models.Dto;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplace.Domain.Models
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
        public int? RestauranteId { get; set; }
        public Restaurante? Restaurante { get; set;}
        public decimal Preco { get; private set; }
    }
}
