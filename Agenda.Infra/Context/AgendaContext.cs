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
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<Recado> Recados { get; set; }
        public DbSet<PessoaRecado> PessoasRecados { get; set; }
        public DbSet<RecadoTipo> RecadoTipos { get; set; }
        public DbSet<RecadoStatus> RecadoStatus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PessoaTipoMap());
            modelBuilder.ApplyConfiguration(new PessoaMap());
            modelBuilder.ApplyConfiguration(new DocumentoTipoMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new TurmaMap());
            modelBuilder.ApplyConfiguration(new RecadoMap());
            modelBuilder.ApplyConfiguration(new PessoaRecadoMap());
            modelBuilder.ApplyConfiguration(new RecadoTipoMap());
            modelBuilder.ApplyConfiguration(new RecadoStatusMap());
        }
    }
}
