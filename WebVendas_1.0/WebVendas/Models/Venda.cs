using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace WebVendas.Models
{
    public class Venda
    {
        [Key]
        public int Id { get; set; }
        
        public string cliente { get; set; }    
        
        public  string produto { get; set; } 

        public int Quantidade { get; set; } 

        public decimal ValorTotalPedido { get; set;}

        public string EnderecoEnvio { get; set; }   
        
        
    }

    

}
