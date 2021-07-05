using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Simec.Models
{
    public class Cliente
    {
        [Key]
        public string IdCliente { get; set; }
        public string NombreCompleto { get; set; }
        public bool Estado { get; set; }
    }
}
