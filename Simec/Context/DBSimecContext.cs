using Microsoft.EntityFrameworkCore;
using Simec.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simec.Context
{
    public class DBSimecContext: DbContext
    {
        public DBSimecContext(DbContextOptions<DBSimecContext> options) : base(options)
        {

        }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<DetalleFactura> DetalleFactura { get; set; }
        public DbSet<Factura> Factura { get; set; }
        public DbSet<Producto> Producto { get; set; }
    }
}
