using Agenda.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agenda.Infra.DataMap
{
    public class InvalidTokenMap : IEntityTypeConfiguration<InvalidToken>
    {
        public void Configure(EntityTypeBuilder<InvalidToken> builder)
        {
            builder.ToTable("InvalidToken");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Token).IsRequired();
            builder.HasIndex(x => x.Token).IsUnique();
        }
    }
}
