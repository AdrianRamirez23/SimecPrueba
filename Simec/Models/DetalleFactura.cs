using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Simec.Models
{
    public class DetalleFactura
    {
        [Key]
        public int IdDetalle { get; set; }
        public int IdProducto { get; set; }
        public string IdCliente { get; set; }
        public int IdFactura { get; set; }
        public int Cantidad { get; set; }
        public float Subtotal { get; set; }
    }
}
