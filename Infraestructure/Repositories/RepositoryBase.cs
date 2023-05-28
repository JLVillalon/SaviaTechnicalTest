using Application.Contracts.Persistence;
using Domain;
using Infraestructure.Persistence;

namespace Infraestructure.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : BaseEntity
    {
        protected readonly ApplicationDbContext _context;

        public RepositoryBase(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public virtual void AddEntity(T entity)
        {
            _context.Set<T>().Add(entity);
        }

    }
}
