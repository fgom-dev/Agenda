using Agenda.Domain.Models;
using Agenda.Infra.DataMap;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Infra.Context
{
    public class AgendaContext : DbContext
    {
        public AgendaContext(DbContextOptions<AgendaContext> options)
            : base(options)
        {
        }

        public DbSet<PessoaTipo> PessoaTipos { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<DocumentoTipo> DocumentoTipos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PessoaTipoMap());
            modelBuilder.ApplyConfiguration(new PessoaMap());
            modelBuilder.ApplyConfiguration(new DocumentoTipoMap());
        }
    }
}
