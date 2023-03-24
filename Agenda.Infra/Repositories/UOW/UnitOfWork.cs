using Agenda.Domain.Repositories;
using Agenda.Domain.Repositories.UOW;
using Agenda.Infra.Context;

namespace Agenda.Infra.Repositories.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private PessoaRepository _pessoaRepo;
        private DocumentoTipoRepository _documentoTipoRepo;
        private PessoaTipoRepository _pessoaTipoRepo;
        public AgendaContext _context;
        public UnitOfWork(AgendaContext context)
        {
            _context = context;
        }
        public IPessoaRepository PessoaRepository
        {
            get { return _pessoaRepo ??= new PessoaRepository(_context); }
        }

        public IDocumentoTipoRepository DocumentoTipoRepository
        {
            get { return _documentoTipoRepo ??= new DocumentoTipoRepository(_context); }
        }

        public IPessoaTipoRepository PessoaTipoRepository
        {
            get { return _pessoaTipoRepo ??= new PessoaTipoRepository(_context); }
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }
    }
}
