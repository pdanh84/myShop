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
    public interface IProductCategoryService
    {
        //Add new entity
        ProductCategory Add(ProductCategory entity);
        //Update entity
        void Update(ProductCategory entity);
        //Delete by enttiy
        ProductCategory Delete(ProductCategory entity);
        //Delete by id
        ProductCategory Delete(int id);
        //Delete multi entity
        void DeleteMulti(Expression<Func<ProductCategory, bool>> where);
        //Get entity by id
        ProductCategory GetSingleById(int id);
        //Get entity by condition
        ProductCategory GetSingleByCondition(Expression<Func<ProductCategory, bool>> expression, string[] includes = null);
        //Get all entity
        IEnumerable<ProductCategory> GetAll(string[] includes = null);
        //Get multi entity
        IEnumerable<ProductCategory> GetMulti(Expression<Func<ProductCategory, bool>> where, string[] includes = null);
        //Get paging entity
        IEnumerable<ProductCategory> GetMultiPaging(Expression<Func<ProductCategory, bool>> filter, out int total, int index = 0, int size = 50, string[] includes = null);

        IEnumerable<ProductCategory> GetAllPaging(out int total, int index = 0, int size = 50, string[] includes = null);

        void SaveChanges();
    }
    public class ProductCategoryService : IProductCategoryService
    {
        IProductCategoryRepository _ProductCategoryRepository;
        IUnitOfWork _unitOfWork;
        public ProductCategoryService(IProductCategoryRepository ProductCategoryRepository, IUnitOfWork unitOfWork)
        {
            this._ProductCategoryRepository = ProductCategoryRepository;
            this._unitOfWork = unitOfWork;
        }
        public ProductCategory Add(ProductCategory entity)
        {
            return _ProductCategoryRepository.Add(entity);
        }

        public ProductCategory Delete(int id)
        {
            return _ProductCategoryRepository.Delete(id);
        }

        public ProductCategory Delete(ProductCategory entity)
        {
            return _ProductCategoryRepository.Delete(entity);
        }

        public IEnumerable<ProductCategory> GetAll(string[] includes = null)
        {
            return _ProductCategoryRepository.GetAll();
        }

        public IEnumerable<ProductCategory> GetMultiPaging(Expression<Func<ProductCategory, bool>> filter, out int total, int index = 0, int size = 50, string[] includes = null)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<ProductCategory> GetAllPaging(out int total, int index = 0, int size = 50, string[] includes = null)
        {
            return _ProductCategoryRepository.GetMultiPaging(x => x.Status,out total, index, size);
        }

        public ProductCategory GetSingleByCondition(Expression<Func<ProductCategory, bool>> expression, string[] includes = null)
        {
            throw new NotImplementedException();
        }

        public ProductCategory GetSingleById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(ProductCategory entity)
        {
            _ProductCategoryRepository.Update(entity);
        }

        public void DeleteMulti(Expression<Func<ProductCategory, bool>> where)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductCategory> GetMulti(Expression<Func<ProductCategory, bool>> where, string[] includes = null)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }
    }
}
