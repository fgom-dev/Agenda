using Agenda.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agenda.Infra.DataMap
{
    public class PessoaMap : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.ToTable("Pessoa");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.PessoaTipoId).IsRequired(false);
            builder.Property(x => x.DocumentoTipoId).IsRequired(false);
            builder.Property(x => x.DataNascimento).IsRequired();
            builder.Property(x => x.Sexo).HasMaxLength(20).IsRequired();
            builder.Property(x => x.Nome).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Sobrenome).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Documento).HasMaxLength(20).IsRequired();

            builder.HasOne(x => x.PessoaTipo).WithMany().HasForeignKey(x => x.PessoaTipoId);
            builder.HasOne(x => x.DocumentoTipo).WithMany().HasForeignKey(x => x.DocumentoTipoId);
        }
    }
}
