using PrShop.Data.Infrastructure;
using PrShop.Model.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace PrShop.Data.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> GetListProductByTag(string tagId, int page, int pageSize, out int totalRow);
    }

    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(IDbFactory dbFacotory) : base(dbFacotory)
        {
        }

        public IEnumerable<Product> GetListProductByTag(string tagId, int page, int pageSize, out int totalRow)
        {
            var query = from p in DbContext.Products
                        join pt in DbContext.ProductTags
                        on p.ID equals pt.ProductID
                        where pt.TagID == tagId
                        select p;
            totalRow = query.Count();
            return query.OrderByDescending(x=>x.CreateDate).Skip((page - 1) * pageSize).Take(pageSize);
        }
    }
}