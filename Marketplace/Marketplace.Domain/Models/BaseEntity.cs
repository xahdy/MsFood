﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Marketplace.Domain.Models
{
    public class BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
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
