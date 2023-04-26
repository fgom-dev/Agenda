using Agenda.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agenda.Infra.DataMap
{
    public class RecadoTipoMap : IEntityTypeConfiguration<RecadoTipo>
    {
        public void Configure(EntityTypeBuilder<RecadoTipo> builder)
        {
            builder.ToTable("RecadoTipo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).HasMaxLength(50).IsRequired();
            builder.HasIndex(x => x.Nome).IsUnique();
            builder.Property(x => x.Descricao).HasMaxLength(255);
        }
    }
}
