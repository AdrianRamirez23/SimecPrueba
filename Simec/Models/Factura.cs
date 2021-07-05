using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Simec.Models
{
    public class Factura
    {

        [Key]
        public int IdFactura { get; set; }
        public string IdCliente { get; set; }
        public DateTime Fecha { get; set; }
        public float Total { get; set; }
    }
}
