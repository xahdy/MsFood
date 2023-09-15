using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Cadastro.Domain.Models
{
    public class BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; private set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DataCriacao { get; private set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime DataUltimaAtualizacao { get; private set; }
        public bool Deletado { get; private set; }

        public void MarcarDeletado() 
        {
            Deletado = true;
        }
        public void DesmarcarDeletado() 
        {
            Deletado = false;
        }
    }
}
