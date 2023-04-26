using Agenda.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Infra.DataMap
{
    public class RecadoStatusMap : IEntityTypeConfiguration<RecadoStatus>
    {
        public void Configure(EntityTypeBuilder<RecadoStatus> builder)
        {
            builder.ToTable("RecadoStatus");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).HasMaxLength(50).IsRequired();
            builder.HasIndex(x => x.Nome).IsUnique();
            builder.Property(x => x.Descricao).HasMaxLength(255);
        }
    }
}
