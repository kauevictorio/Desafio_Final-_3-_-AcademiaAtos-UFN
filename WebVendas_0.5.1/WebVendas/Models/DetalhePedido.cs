using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebVendas.Models
{
    public class DetalhePedido
    {
        public int Id { get; set; }
        public int Quantidade { get; set; }
        [Key]
        public int IdPedido { get; set; }
        public int IdProduto { get; set; }

        [Required]
        public Produto Produto { get; set; }

        public Pedido Pedido { get; set; }

        public decimal TotalPedido
        {
            get
            {
                return Quantidade * (Produto.PrecoDeVenda);
            }
        }
    }
}