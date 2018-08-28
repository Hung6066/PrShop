using PrShop.Data.Infrastructure;
using PrShop.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace PrShop.Data.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> GetByAlias(string alias);
    }

    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(IDbFactory dbFacotory) : base(dbFacotory)
        {
        }

        public IEnumerable<Product> GetByAlias(string alias)
        {
            return DbContext.Products.Where(x => x.Alias == alias);
        }
    }
}