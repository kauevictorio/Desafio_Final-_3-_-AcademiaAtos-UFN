using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebVendas.Data
{
    public class WebVendasContext : DbContext
    {
          
        public WebVendasContext() : base("name=WebVendasContext")
        {
        }

        public System.Data.Entity.DbSet<WebVendas.Models.Cliente> Clientes { get; set; }

        public System.Data.Entity.DbSet<WebVendas.Models.Produto> Produtoes { get; set; }

        public System.Data.Entity.DbSet<WebVendas.Models.Venda> Vendaes { get; set; }
        public IEnumerable AppDataApplicationTypes { get; internal set; }
    }
}
