using GineSys.Models;
using System.Data.Entity.ModelConfiguration;

namespace GineSys.EntityConfigurations
{
    public class OcupacionConfiguration : EntityTypeConfiguration<Ocupacion>
    {
        public OcupacionConfiguration()
        {
            ToTable("Ocupaciones");
            HasKey(o => o.OcupacionId);

            Property(o => o.Descripcion)
                .IsRequired()
                .HasMaxLength(500);

            Property(o => o.FechaCreacion)
                .IsRequired();

            Property(o => o.FechaModificacion)
                .IsOptional();

            Property(o => o.UsuarioCreacion)
                .IsRequired()
                .HasMaxLength(50);

            Property(o => o.UsuarioModificacion)
                .HasMaxLength(50)
                .IsOptional();
        }
    }
}