using Domain;

namespace Application.Contracts.Persistence
{
    public interface IRepositoryBase<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(Guid id);

        void AddEntity(T entity);
    }
}
