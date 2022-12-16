using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebVendas.Models
{
    public class Cliente
    {
                [Key]
                public int Id { get; set; }
                 [Required]
                public string Name { get; set; }
            
                public string Email { get; set; }   

                public string Fone { get; set; }    

                public string Endereco { get; set; }  

                public bool Admin { get; set; }

        
    }
    
}