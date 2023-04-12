using Agenda.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agenda.Infra.DataMap
{
    public class TurmaMap : IEntityTypeConfiguration<Turma>
    {
        public void Configure(EntityTypeBuilder<Turma> builder)
        {
            builder.ToTable("Turma");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).HasMaxLength(20).IsRequired();
            builder.Property(x => x.Descricao).HasMaxLength(255).IsRequired(false);
            builder.Property(x => x.Periodo).HasMaxLength(20).IsRequired();

            builder.HasMany(x => x.Alunos).WithOne().HasForeignKey(x => x.TurmaId);
        }
    }
}
