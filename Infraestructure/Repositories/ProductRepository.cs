using Application.Contracts.Persistence;
using Domain;
using Infraestructure.Persistence;

namespace Infraestructure.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
        }

    }
}
