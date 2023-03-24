using Agenda.Domain.Pagination;

namespace Agenda.Domain.Repositories
{
    public interface IRepository<T>
    {
        Task<PagedList<T>> Get(PaginationParameters parameters);
        Task<T> GetById(Guid id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
