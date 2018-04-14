using GineSys.Models;
using System.Data.Entity.ModelConfiguration;

namespace GineSys.EntityConfigurations
{
    public class UsuarioConfiguration : EntityTypeConfiguration<Usuarios>
    {
        public UsuarioConfiguration()
        {
            ToTable("Usuarios");
            HasKey(u => u.UsuarioId);

            Property(u => u.Usuario)
                .IsRequired()
                .HasMaxLength(50);

            Property(u => u.Nombre)
                .IsRequired()
                .HasMaxLength(500);

            Property(u => u.Contrasena)
                .IsRequired()
                .HasMaxLength(100);

            Property(u => u.FechaCreacion)
                .IsRequired();

            Property(u => u.FechaModificacion)
                .IsOptional();

            Property(u => u.UsuarioCreacion)
                .IsRequired()
                .HasMaxLength(50);

            Property(u => u.UsuarioModificacion)
                .HasMaxLength(50)
                .IsOptional();
        }
    }
}