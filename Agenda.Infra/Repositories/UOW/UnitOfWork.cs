using Agenda.Domain.Repositories;
using Agenda.Domain.Repositories.UOW;
using Agenda.Infra.Context;
using AutoMapper;

namespace Agenda.Infra.Repositories.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private PessoaRepository _pessoaRepo;
        private DocumentoTipoRepository _documentoTipoRepo;
        private PessoaTipoRepository _pessoaTipoRepo;
        private UsuarioRepository _usuarioRepo;
        private TurmaRepository _turmaRepo;
        private RecadoTipoRepository _recadoTipoRepo;
        private RecadoStatusRepository _recadoStatusRepo;
        private RecadoRepository _recadoRepo;
        public PessoaRecadoRepository _pessoaRecadoRepo;

        public AgendaContext _context;
        public IMapper _mapper;
        public UnitOfWork(AgendaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public IPessoaRepository PessoaRepository
        {
            get { return _pessoaRepo ??= new PessoaRepository(_context, _mapper); }
        }

        public IDocumentoTipoRepository DocumentoTipoRepository
        {
            get { return _documentoTipoRepo ??= new DocumentoTipoRepository(_context, _mapper); }
        }

        public IPessoaTipoRepository PessoaTipoRepository
        {
            get { return _pessoaTipoRepo ??= new PessoaTipoRepository(_context, _mapper); }
        }

        public IUsuarioRepository UsuarioRepository
        {
            get { return _usuarioRepo ??= new UsuarioRepository(_context, _mapper); }
        }

        public ITurmaRepository TurmaRepository
        {
            get { return _turmaRepo ??= new TurmaRepository(_context, _mapper); }
        }

        public IRecadoTipoRepository RecadoTipoRepository
        {
            get { return _recadoTipoRepo ??= new RecadoTipoRepository(_context, _mapper); }
        }

        public IRecadoStatusRepository RecadoStatusRepository
        {
            get { return _recadoStatusRepo ??= new RecadoStatusRepository(_context, _mapper); }
        }

        public IRecadoRepository RecadoRepository
        {
            get { return _recadoRepo ??= new RecadoRepository(_context, _mapper); }
        }

        public IPessoaRecadoRepository PessoaRecadoRepository
        {
            get { return _pessoaRecadoRepo ??= new PessoaRecadoRepository(_context, _mapper); }
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }
    }
}
