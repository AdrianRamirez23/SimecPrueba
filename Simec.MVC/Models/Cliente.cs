using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Simec.MVC.Models
{
    public class Cliente
    {
        [Required]
        public string IdCliente { get; set; }
        [Required]
        public string NombreCompleto { get; set; }
        [Required]
        public bool Estado { get; set; }
    }
}
