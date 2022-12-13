using System;
using System.Linq;
using System.Web;

namespace WebVendas.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Pedido
    {
        public int Id { get; set; }
        [Required]
        public string Cliente { get; set; }

        public ICollection<DetalhePedido> DetalhePedido { get; set; }
    }
}
