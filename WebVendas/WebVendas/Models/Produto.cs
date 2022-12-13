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
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required]
        public string NomeProduto { get; set; }

        public decimal PrecoDeVenda { get; set; }

        public decimal PrecoDeCompra { get; set; }

        public int Quantidade { get; set; } 

      

    }
}