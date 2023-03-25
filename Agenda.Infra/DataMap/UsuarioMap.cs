using Agenda.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agenda.Infra.DataMap
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Email).HasMaxLength(255).IsRequired();
            builder.HasIndex(x => x.Email).IsUnique();
            builder.Property(x => x.IsAdmin).HasDefaultValue(false);
            builder.Property(x => x.PessoaId).IsRequired(false);

            builder.HasOne(x => x.Pessoa).WithOne().HasForeignKey<Usuario>(x => x.PessoaId);
        }
    }
}
