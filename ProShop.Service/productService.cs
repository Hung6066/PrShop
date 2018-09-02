using PrShop.Data.Infrastructure;
using PrShop.Data.Repositories;
using PrShop.Model.Models;
using System.Collections.Generic;

namespace ProShop.Service
{
    public class productService
    {
        public interface IProductService
        {
            Product Add(Product category);

            void Update(Product Product);

            Product Delete(int id);

            IEnumerable<Product> GetAll();

            IEnumerable<Product> GetAll(string keyword);

            Product GetById(int id);

            void saveChanges();
        }

        public class ProductService : IProductService
        {
            private IProductRepository _ProductRepository;
            private IUnitOfWork _unitOfWork;

            public ProductService(IProductRepository ProductRepository, IUnitOfWork unitOfWork)
            {
                _ProductRepository = ProductRepository;
                _unitOfWork = unitOfWork;
            }

            public Product Add(Product category)
            {
                return _ProductRepository.Add(category);
            }

            public Product Delete(int id)
            {
                return _ProductRepository.Delete(id);
            }

            public IEnumerable<Product> GetAll()
            {
                return _ProductRepository.GetAll();
            }

            public Product GetById(int id)
            {
                return _ProductRepository.GetSingleById(id);
            }

            public void Update(Product Product)
            {
                _ProductRepository.Update(Product);
            }

            public void saveChanges()
            {
                _unitOfWork.Commit();
            }

            public IEnumerable<Product> GetAll(string keyword)
            {
                if (!string.IsNullOrEmpty(keyword))
                    return _ProductRepository.GetMulti(x => x.Name.Contains(keyword) || x.Description.Contains(keyword));
                else
                    return _ProductRepository.GetAll();
            }
        }
    }
}