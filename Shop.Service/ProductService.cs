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
    public interface IProductService
    {
        //Add new entity
        Product Add(Product entity);
        //Update entity
        void Update(Product entity);
        //Delete by enttiy
        Product Delete(Product entity);
        //Delete by id
        Product Delete(int id);
        //Delete multi entity
        void DeleteMulti(Expression<Func<Product, bool>> where);
        //Get entity by id
        Product GetSingleById(int id);
        //Get entity by condition
        Product GetSingleByCondition(Expression<Func<Product, bool>> expression, string[] includes = null);
        //Get all entity
        IEnumerable<Product> GetAll(string[] includes = null);
        //Get multi entity
        IEnumerable<Product> GetMulti(Expression<Func<Product, bool>> where, string[] includes = null);
        //Get paging entity
        IEnumerable<Product> GetMultiPaging(Expression<Func<Product, bool>> filter, out int total, int index = 0, int size = 50, string[] includes = null);

        IEnumerable<Product> GetAllPaging(out int total, int index = 0, int size = 50, string[] includes = null);

        void SaveChanges();
    }
    public class ProductService : IProductService
    {
        IProductRepository _ProductRepository;
        IUnitOfWork _unitOfWork;
        public ProductService(IProductRepository ProductRepository, IUnitOfWork unitOfWork)
        {
            this._ProductRepository = ProductRepository;
            this._unitOfWork = unitOfWork;
        }
        public Product Add(Product entity)
        {
            return _ProductRepository.Add(entity);
        }

        public Product Delete(int id)
        {
            return _ProductRepository.Delete(id);
        }

        public Product Delete(Product entity)
        {
            return _ProductRepository.Delete(entity);
        }

        public IEnumerable<Product> GetAll(string[] includes = null)
        {
            return _ProductRepository.GetAll(new string[] { "ProductCategory" });
        }

        public IEnumerable<Product> GetMultiPaging(Expression<Func<Product, bool>> filter, out int total, int index = 0, int size = 50, string[] includes = null)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Product> GetAllPaging(out int total, int index = 0, int size = 50, string[] includes = null)
        {
            return _ProductRepository.GetMultiPaging(x => x.Status,out total, index, size);
        }

        public Product GetSingleByCondition(Expression<Func<Product, bool>> expression, string[] includes = null)
        {
            throw new NotImplementedException();
        }

        public Product GetSingleById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            _ProductRepository.Update(entity);
        }

        public void DeleteMulti(Expression<Func<Product, bool>> where)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetMulti(Expression<Func<Product, bool>> where, string[] includes = null)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }
    }
}
