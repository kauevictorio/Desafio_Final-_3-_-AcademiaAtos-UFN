using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebVendas.Models
{
    public class Produto
    {
        //ScaffoldColumn avisa o entity para dar skip na propriedade id na hora de gerar o editor
        [Key]
        public int Id { get; set; }

        [Required]
        public string NomeProduto { get; set; }

        public decimal Preco { get; set; }

        public int Estoque { get; set; } 

        public string Categoria { get; set; }    

        public bool Disponivel { get; set; }    

      

    }
}