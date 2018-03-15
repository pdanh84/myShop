using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shop.Data.Infrastructure;
using Shop.Data.Repositories;
using Shop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.UnitTest.RepositoryTest
{
    /// <summary>
    /// Class PostCategory Repository Test
    /// </summary>
    [TestClass]
    public class PostCategoryRepositoryTest
    {
        IDbFactory _dbFactory;
        IUnitOfWork _unitOfWork;
        IPostCategoryRepository _postCategoryRepository;
        /// <summary>
        /// Init function
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            _dbFactory = new DbFactory();
            _unitOfWork = new UnitOfWork(_dbFactory);
            _postCategoryRepository = new PostCategoryRepository(_dbFactory);
        }
        /// <summary>
        /// Test repository add
        /// </summary>
        [TestMethod]
        public void PostCategory_Repository_Add()
        {
            PostCategory p = new PostCategory();
            p.Name = "Ao Nam";
            p.Alias = "ao-nam";
            p.Description = "áo phông, sơ mi, khoác ...";
            p.Status = true;
            var result = _postCategoryRepository.Add(p);
            _unitOfWork.Commit();

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.ID);
        }
        /// <summary>
        /// Test repository getall
        /// </summary>
        [TestMethod]
        public void PostCategory_Repository_GetAll()
        {
            var listResult = _postCategoryRepository.GetAll();
            _unitOfWork.Commit();

            Assert.IsNotNull(listResult);
            Assert.AreEqual(1, listResult.Count());
        }
    }
}
