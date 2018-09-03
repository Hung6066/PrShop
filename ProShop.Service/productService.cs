using PrShop.Common;
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
            private IProductRepository _productRepository;
            private ITagRepository _tagRepository;
            private IProductTagRepository _productTagRespository;
            private IUnitOfWork _unitOfWork;

            public ProductService(IProductRepository ProductRepository,
                IProductTagRepository productTagRespository,
                ITagRepository tagResponsitory,
                IUnitOfWork unitOfWork)
            {
                _productRepository = ProductRepository;
                _productTagRespository = productTagRespository;
                _tagRepository = tagResponsitory;
                _unitOfWork = unitOfWork;
            }

            public Product Add(Product product)

            {
                var p = _productRepository.Add(product);
                _unitOfWork.Commit();
                if (!string.IsNullOrEmpty(product.Tags))
                {
                    string[] tags = product.Tags.Split(',');
                    for(var i = 0; i < tags.Length; i++)
                    {
                        var tagId = StringHelper.ToUnsignString(tags[i]);
                        if(_tagRepository.Count(x=>x.ID == tagId) == 0)
                        {
                            Tag tag = new Tag();
                            tag.ID = tagId;
                            tag.Name = tags[i];
                            tag.Type = CommonConstants.ProductTag;
                            _tagRepository.Add(tag);
                        }

                        ProductTag productTag = new ProductTag();
                        productTag.ProductID = product.ID;
                        productTag.TagID = tagId;
                        _productTagRespository.Add(productTag);

                    }
                    
                }
                return p;
            }

            public Product Delete(int id)
            {
                return _productRepository.Delete(id);
            }

            public IEnumerable<Product> GetAll()
            {
                return _productRepository.GetAll();
            }

            public Product GetById(int id)
            {
                return _productRepository.GetSingleById(id);
            }

            public void Update(Product product)
            {
                _productRepository.Update(product);
                if (!string.IsNullOrEmpty(product.Tags))
                {
                    string[] tags = product.Tags.Split(',');
                    for (var i = 0; i < tags.Length; i++)
                    {
                        var tagId = StringHelper.ToUnsignString(tags[i]);
                        if (_tagRepository.Count(x => x.ID == tagId) == 0)
                        {
                            Tag tag = new Tag();
                            tag.ID = tagId;
                            tag.Name = tags[i];
                            tag.Type = CommonConstants.ProductTag;
                            _tagRepository.Add(tag);
                            
                        }
                        _productTagRespository.DeleteMulti(x => x.ProductID == product.ID);
                        ProductTag productTag = new ProductTag();
                        productTag.ProductID = product.ID;
                        productTag.TagID = tagId;
                        _productTagRespository.Add(productTag);

                    }
                    
                }
                
            }

            public void saveChanges()
            {
                _unitOfWork.Commit();
            }

            public IEnumerable<Product> GetAll(string keyword)
            {
                if (!string.IsNullOrEmpty(keyword))
                    return _productRepository.GetMulti(x => x.Name.Contains(keyword) || x.Description.Contains(keyword));
                else
                    return _productRepository.GetAll();
            }
        }
    }
}