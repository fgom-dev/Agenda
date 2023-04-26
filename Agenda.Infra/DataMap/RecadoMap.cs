using Agenda.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agenda.Infra.DataMap
{
    public class RecadoMap : IEntityTypeConfiguration<Recado>
    {
        public void Configure(EntityTypeBuilder<Recado> builder)
        {
            builder.ToTable("Recado");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Mensagem).HasColumnType("text");
            builder.Property(x => x.RecadoTipoId).IsRequired();
            builder.Property(x => x.UsuarioId).IsRequired();
            
            builder.HasOne(x => x.RecadoTipo).WithMany().HasForeignKey(x => x.RecadoTipoId);
            builder.HasOne<Usuario>().WithMany().HasForeignKey(x => x.UsuarioId);

            builder.Navigation(x => x.RecadoTipo).AutoInclude();
        }
    }
}
