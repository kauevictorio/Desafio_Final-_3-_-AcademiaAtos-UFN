using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebVendas.Models
{
    public class Cliente
    {
            
            public int Id { get; set; }
            [Required]
            public string FirstName { get; set; }
            [Required]
            public string LastName { get; set; }
            public string FullName
            {
                get
                {
                    return FirstName + " " + LastName;
                }
            }
        public string email { get; set; }   

        public string cidade { get; set; }  

        public string pais { get; set; }

        public string enderecoCompleto
        {
            get
            {
                return cidade+ "/" + pais;
            }
        }
    }
    
}