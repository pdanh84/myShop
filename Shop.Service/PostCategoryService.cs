using Shop.Data.Infrastructure;
using Shop.Data.Repositories;
using Shop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Service
{
    public interface IPostCategoryService
    {
        //Add new entity
        PostCategory Add(PostCategory entity);
        //Update entity
        void Update(PostCategory entity);
        //Delete by id
        PostCategory Delete(int id);
        //Delete multi entity
        void DeleteMulti(Expression<Func<PostCategory, bool>> where);
        //Get all entity
        IEnumerable<PostCategory> GetAll(string[] includes = null);
        //Get multi entity
        IEnumerable<PostCategory> GetByParentId(int parentId);
     
        PostCategory GetById(int id);

        void Save();
    }
    public class PostCategoryService : IPostCategoryService
    {
        IPostCategoryRepository _postCategoryRepository;
        IUnitOfWork _unitOfWork;
        public PostCategoryService(IPostCategoryRepository postCategoryService, IUnitOfWork unitOfWork)
        {
            this._postCategoryRepository = postCategoryService;
            this._unitOfWork = unitOfWork;
        }
        public PostCategory Add(PostCategory entity)
        {
            return _postCategoryRepository.Add(entity);
        }

        public PostCategory Delete(int id)
        {
            return _postCategoryRepository.Delete(id);
        }

        public IEnumerable<PostCategory> GetAll(string[] includes = null)
        {
            return _postCategoryRepository.GetAll();
        }

        public void Update(PostCategory entity)
        {
            _postCategoryRepository.Update(entity);
        }

        public void DeleteMulti(Expression<Func<PostCategory, bool>> where)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PostCategory> GetByParentId(int parentId)
        {
            return _postCategoryRepository.GetByParentId(parentId);
        }

        public PostCategory GetById(int id)
        {
            return _postCategoryRepository.GetById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
