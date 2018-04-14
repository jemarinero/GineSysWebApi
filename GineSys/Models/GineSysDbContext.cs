using GineSys.EntityConfigurations;
using System.Data.Entity;

namespace GineSys.Models
{
    public class GineSysDbContext : DbContext
    {
        public GineSysDbContext() : base("name=GineSysContext")
        {
        }

        public virtual DbSet<Ocupacion> Ocupaciones { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new OcupacionConfiguration());
            modelBuilder.Configurations.Add(new UsuarioConfiguration());
        }
    }
}