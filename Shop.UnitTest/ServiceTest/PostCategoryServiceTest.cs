using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shop.Data.Infrastructure;
using Shop.Data.Repositories;
using Shop.Model.Models;
using Shop.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.UnitTest.ServiceTest
{
    /// <summary>
    /// Class PostCategory Service Test
    /// </summary>
    [TestClass]
    public class PostCategoryServiceTest
    {
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private Mock<IPostCategoryRepository> _mockPostCategoryRepository;
        private IPostCategoryService _postCategoryService;
        private List<PostCategory> _listPostCategory;
        /// <summary>
        /// Init function
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            _mockPostCategoryRepository = new Mock<IPostCategoryRepository>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _postCategoryService = new PostCategoryService(_mockPostCategoryRepository.Object, _mockUnitOfWork.Object);
            _listPostCategory = new List<PostCategory>()
            {
                new PostCategory() {ID = 1, Name="Quan Nam",Alias="quan-nam", Description ="",Status=true },
                new PostCategory() {ID = 2, Name="Quan Nu",Alias="quan-nu", Description ="",Status=true },
                new PostCategory() {ID = 2, Name="Ao Nu",Alias="ao-nu", Description ="",Status=true }
            };
        }
        /// <summary>
        /// Test service Add
        /// </summary>
        [TestMethod]
        public void PostCategory_Service_Add()
        {
            PostCategory pc = new PostCategory() { ID= 2, Name="postcategory1", Alias="post-category-1", Description="", Status=true};
            _mockPostCategoryRepository.Setup(m => m.Add(pc)).Returns((PostCategory p) => {
                p.ID = 2;
                return p;
            });

            var result = _postCategoryService.Add(pc);

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.ID);
        }
        /// <summary>
        /// Test sevice GetAll
        /// </summary>
        [TestMethod]
        public void PostCategory_Service_GetAll()
        {
            _mockPostCategoryRepository.Setup(m => m.GetAll(null)).Returns(_listPostCategory);

            var result = _postCategoryService.GetAll();

            Assert.IsNotNull(result);
            Assert.AreEqual(3, _listPostCategory.Count);
        }
    }
}
