using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrShop.Data.Infrastructure;
using PrShop.Model.Models;
using System.Linq;
using PrShop.Data.Repositories;

namespace PrShop.UnitTest.RepositoryTest
{
    [TestClass]
    public class PostCategoryRespositoryTest
    {
        IDbFactory dbFactory;
        IPostCategoryRepository objRespository;
        IUnitOfWork unitOfWork;

        [TestInitialize]
        public void Initialize()
        {
            dbFactory = new DbFactory();
            objRespository = new PostCategoryRepository(dbFactory);
            unitOfWork = new UnitOfWork(dbFactory);
        }
        [TestMethod]
        public void PostCategory_Respository_GetAll()
        {
            var list = objRespository.GetAll().ToList();
            Assert.AreEqual(20, list.Count);
        }
        [TestMethod]
        public void PostCategory_Respository_Create()
        {
            PostCategory category = new PostCategory();
            category.Name = "Test category";
            category.Alias = "Test-category";
            category.Status = true;

            var result = objRespository.Add(category);
            unitOfWork.Commit();

            Assert.IsNotNull(result);
            Assert.AreEqual(21, result.ID);
        }
    }
}