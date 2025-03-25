using Microsoft.EntityFrameworkCore;
using crud2.OrdenCompra.Domain.Entidades; 

namespace crud2.OrdenCompra.Infrastructure.Data
{
    public class OrdenCompraContext : DbContext
    {
        public OrdenCompraContext(DbContextOptions<OrdenCompraContext> options)
            : base(options)
        {
        }

        
        public DbSet<OrdenCompra.Domain.Entidades.OrdenCompra> OrdenesCompra { get; set; }

        public DbSet<Proveedor> Proveedores { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
        }
    }
}
