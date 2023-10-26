using Marketplace.Domain.Models.Dto;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Marketplace.Domain.Models
{
    public class Restaurante : BaseEntity
    {
        public Restaurante(string nome)
        {
            Nome = nome;
            ListaPratos = new List<Prato>();
        }
        public string Nome { get; set; }

        [ForeignKey("Localizacao")]
        public int? LocalizacaoId { get; set; }
        public Localizacao? Localizacao { get; set; }

        [InverseProperty("Restaurante")]
        public ICollection<Prato>? ListaPratos { get; set; }


    }
}
