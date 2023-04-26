using Agenda.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agenda.Infra.DataMap
{
    public class PessoaRecadoMap : IEntityTypeConfiguration<PessoaRecado>
    {
        public void Configure(EntityTypeBuilder<PessoaRecado> builder)
        {
            builder.ToTable("PessoaRecado");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.PessoaId).IsRequired();
            builder.Property(x => x.RecadoId).IsRequired();
            builder.Property(x => x.RecadoStatusId).IsRequired();

            builder.HasOne(x => x.Recado).WithMany().HasForeignKey(x => x.RecadoId);
            builder.HasOne(x => x.Pessoa).WithMany().HasForeignKey(x => x.PessoaId);
            builder.HasOne(x => x.RecadoStatus).WithMany().HasForeignKey(x => x.RecadoStatusId);

            builder.Navigation(x => x.Recado).AutoInclude();
            builder.Navigation(x => x.Pessoa).AutoInclude();
            builder.Navigation(x => x.RecadoStatus).AutoInclude();
        }
    }
}
