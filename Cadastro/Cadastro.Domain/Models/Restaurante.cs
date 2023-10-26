using Cadastro.Domain.Models.Dto;
using Cadastro.Domain.ValueObject;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Cadastro.Domain.Models
{
    public class Restaurante : BaseEntity
    {
        public Restaurante(string proprietario, string nome, string cnpj)
        {
            Proprietario = proprietario;
            Nome = nome;
            Cnpj = cnpj;
        }

        public string Proprietario { get; private set; }
        public string Nome { get; private set; }
        public string Cnpj { get; private set; }

        [ForeignKey("Localizacao")]
        public int? LocalizacaoId { get; private set; }
        public Localizacao? Localizacao { get; set; }

        [InverseProperty("Restaurante")]
        public  ICollection<Prato> ListaPratos { get; private set; }

        public void AtualizarRestaurante(RestauranteDto restaurante)
        {
            Proprietario = restaurante.Proprietario;
            Nome = restaurante.Nome;
        }

    }
}
