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
    public interface IPostService
    {
        //Add new entity
        Post Add(Post entity);
        //Update entity
        void Update(Post entity);
        //Delete by enttiy
        Post Delete(Post entity);
        //Delete by id
        Post Delete(int id);
        //Delete multi entity
        void DeleteMulti(Expression<Func<Post, bool>> where);
        //Get entity by id
        Post GetSingleById(int id);
        //Get entity by condition
        Post GetSingleByCondition(Expression<Func<Post, bool>> expression, string[] includes = null);
        //Get all entity
        IEnumerable<Post> GetAll(string[] includes = null);
        //Get multi entity
        IEnumerable<Post> GetMulti(Expression<Func<Post, bool>> where, string[] includes = null);
        //Get paging entity
        IEnumerable<Post> GetMultiPaging(Expression<Func<Post, bool>> filter, out int total, int index = 0, int size = 20, string[] includes = null);

        IEnumerable<Post> GetAllPaging(out int total, int index = 0, int size = 20, string[] includes = null);
        /// <summary>
        /// Get tag paging by tagid
        /// </summary>
        /// <param name="tagId"></param>
        /// <param name="total"></param>
        /// <param name="index"></param>
        /// <param name="size"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        IEnumerable<Post> GetAllByTagPaging(string tagId,out int total, int index = 0, int size = 20, string[] includes = null);

        void SaveChanges();
    }
    public class PostService : IPostService
    {
        IPostRepository _postRepository;
        IUnitOfWork _unitOfWork;
        public PostService(IPostRepository postRepository, IUnitOfWork unitOfWork)
        {
            this._postRepository = postRepository;
            this._unitOfWork = unitOfWork;
        }
        public Post Add(Post entity)
        {
            return _postRepository.Add(entity);
        }

        public Post Delete(int id)
        {
            return _postRepository.Delete(id);
        }

        public Post Delete(Post entity)
        {
            return _postRepository.Delete(entity);
        }

        public IEnumerable<Post> GetAll(string[] includes = null)
        {
            return _postRepository.GetAll(new string[] { "PostCategory" });
        }

        public IEnumerable<Post> GetMultiPaging(Expression<Func<Post, bool>> filter, out int total, int index = 0, int size = 20, string[] includes = null)
        {
            return _postRepository.GetMultiPaging(x => x.Status, out total, index, size);
        }
        public IEnumerable<Post> GetAllPaging(out int total, int index = 0, int size = 20, string[] includes = null)
        {
            return _postRepository.GetMultiPaging(x => x.Status,out total, index, size);
        }

        public Post GetSingleByCondition(Expression<Func<Post, bool>> expression, string[] includes = null)
        {
            return _postRepository.GetSingleByCondition(expression);
        }

        public Post GetSingleById(int id)
        {
            return _postRepository.GetSingleById(id);
        }

        public void Update(Post entity)
        {
            _postRepository.Update(entity);
        }

        public void DeleteMulti(Expression<Func<Post, bool>> where)
        {
            _postRepository.DeleteMulti(where);
        }

        public IEnumerable<Post> GetMulti(Expression<Func<Post, bool>> where, string[] includes = null)
        {
            return _postRepository.GetMulti(where);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }
        
        public IEnumerable<Post> GetAllByTagPaging(string tagId, out int total, int index = 0, int size = 20, string[] includes = null)
        {
            return _postRepository.GetAllByTag(tagId, index, size,out total);
        }
    }
}
