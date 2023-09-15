using System.ComponentModel.DataAnnotations.Schema;

namespace Cadastro.Domain.Models
{
    public class Prato : BaseEntity
    {
        public Prato(string nome, string descricao, int restauranteId, decimal preco)
        {
            Nome = nome;
            Descricao = descricao;
            RestauranteId = restauranteId;
            Preco = preco;
        }

        public string Nome { get; private set; }
        public string Descricao { get; private set; }

        [ForeignKey("Restaurante")]
        public int RestauranteId { get; private set; }
        public Restaurante? Restaurante { get; private set;}
        public decimal Preco { get; private set; }
    }
}
