using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebVendas.Data
{
    public class WebVendasContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public WebVendasContext() : base("name=WebVendasContext")
        {
        }

        public System.Data.Entity.DbSet<WebVendas.Models.Cliente> Clientes { get; set; }

        public System.Data.Entity.DbSet<WebVendas.Models.Produto> Produtoes { get; set; }

        public System.Data.Entity.DbSet<WebVendas.Models.Pedido> Pedidoes { get; set; }

        public System.Data.Entity.DbSet<WebVendas.Models.DetalhePedido> DetalhePedidoes { get; set; }
    }
}
