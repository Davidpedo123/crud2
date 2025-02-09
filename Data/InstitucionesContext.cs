using Microsoft.EntityFrameworkCore;
using crud2.Models;

namespace crud2.Data
{
    public class InstitucionesContext : DbContext
    {
        public InstitucionesContext(DbContextOptions<InstitucionesContext> options)
            : base(options)
        {
        }

        public DbSet<Institucion> Instituciones { get; set; }
    }
}
