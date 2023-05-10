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
            builder.Property(x => x.RecadoTipo).IsRequired();
            builder.Property(x => x.UsuarioId).IsRequired();
            
            builder.HasOne<Usuario>().WithMany().HasForeignKey(x => x.UsuarioId);
        }
    }
}
