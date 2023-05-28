using Application.Contracts.Persistence;
using Infraestructure.Persistence;
using Infraestructure.Repositories;

namespace Infraestructure.UnitOfWork
{
    /// <summary>
    /// Unit of work manager for Application entity framework context
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        #region Fields

        private readonly ApplicationDbContext _context;
        private IProductRepository _products;

        #endregion

        #region Constructors

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Interfaces

        public IProductRepository Products => _products ??= new ProductRepository(_context);

        #endregion

        #region Methods

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public ApplicationDbContext ApplicationDbContext => _context;

        public void Dispose()
        {
            _context.Dispose();
        }

        #endregion

    }
}
