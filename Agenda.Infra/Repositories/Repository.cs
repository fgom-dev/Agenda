using Agenda.Domain.Models;
using Agenda.Domain.Pagination;
using Agenda.Domain.Repositories;
using Agenda.Infra.Context;
using Agenda.Shared.Errors;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Agenda.Infra.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected AgendaContext _context;
        protected IMapper _mapper;

        public Repository(AgendaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Add(T entity)
        {
            try
            {
                entity.CreatedAt = DateTime.UtcNow;
                entity.UpdatedAt = DateTime.UtcNow;
                _context.Set<T>().Add(entity);
            }
            catch
            {
                throw new CustomException(HttpStatusCode.InternalServerError, $"Erro não previsto!");
            }
        }

        public void Delete(T entity)
        {
            try
            {
                _context.Set<T>().Remove(entity);
            }
            catch
            {
                throw new CustomException(HttpStatusCode.InternalServerError, $"Erro não previsto!");
            }
        }

        public async Task<PagedList<T>> Get(PaginationParameters parameters)
        {
            try
            {
                return PagedList<T>.ToPagedList(await _context.Set<T>()
                    .ToListAsync(), parameters.PageNumber, parameters.PageSize);
            }
            catch
            {
                throw new CustomException(HttpStatusCode.InternalServerError, $"Erro não previsto!");
            }
        }

        public async Task<T> GetById(int id)
        {
            try
            {
                return await _context.Set<T>().SingleAsync(x => x.Id == id);
            }
            catch (InvalidOperationException)
            {
                throw new CustomException(HttpStatusCode.NotFound, $"{_context.Set<T>().EntityType.DisplayName()} não encontrado(a)");
            }
            catch
            {
                throw new CustomException(HttpStatusCode.InternalServerError, $"Erro não previsto!");
            }
        }

        public void Update(T entity)
        {
            try
            {
                entity.UpdatedAt = DateTime.UtcNow;
                _context.Set<T>().Update(entity);
            }
            catch
            {
                throw new CustomException(HttpStatusCode.InternalServerError, $"Erro não previsto!");
            }
        }
    }
}
