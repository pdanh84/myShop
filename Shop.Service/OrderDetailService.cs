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
    public interface IOrderDetailService
    {
        //Add new entity
        OrderDetail Add(OrderDetail entity);
        //Update entity
        void Update(OrderDetail entity);
        //Delete by enttiy
        OrderDetail Delete(OrderDetail entity);
        //Delete by id
        OrderDetail Delete(int id);
        //Delete multi entity
        void DeleteMulti(Expression<Func<OrderDetail, bool>> where);
        //Get entity by id
        OrderDetail GetSingleById(int id);
        //Get entity by condition
        OrderDetail GetSingleByCondition(Expression<Func<OrderDetail, bool>> expression, string[] includes = null);
        //Get all entity
        IEnumerable<OrderDetail> GetAll(string[] includes = null);
        //Get multi entity
        IEnumerable<OrderDetail> GetMulti(Expression<Func<OrderDetail, bool>> where, string[] includes = null);
        //Get paging entity
        IEnumerable<OrderDetail> GetMultiPaging(Expression<Func<OrderDetail, bool>> filter, out int total, int index = 0, int size = 50, string[] includes = null);

        IEnumerable<OrderDetail> GetAllPaging(out int total, int index = 0, int size = 50, string[] includes = null);

        void SaveChanges();
    }
    public class OrderDetailService : IOrderDetailService
    {
        IOrderDetailRepository _OrderDetailRepository;
        IUnitOfWork _unitOfWork;
        public OrderDetailService(IOrderDetailRepository OrderDetailRepository, IUnitOfWork unitOfWork)
        {
            this._OrderDetailRepository = OrderDetailRepository;
            this._unitOfWork = unitOfWork;
        }
        public OrderDetail Add(OrderDetail entity)
        {
            return _OrderDetailRepository.Add(entity);
        }

        public OrderDetail Delete(int id)
        {
            return _OrderDetailRepository.Delete(id);
        }

        public OrderDetail Delete(OrderDetail entity)
        {
            return _OrderDetailRepository.Delete(entity);
        }

        public IEnumerable<OrderDetail> GetAll(string[] includes = null)
        {
            return _OrderDetailRepository.GetAll();
        }

        public IEnumerable<OrderDetail> GetMultiPaging(Expression<Func<OrderDetail, bool>> filter, out int total, int index = 0, int size = 50, string[] includes = null)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<OrderDetail> GetAllPaging(out int total, int index = 0, int size = 50, string[] includes = null)
        {
            return _OrderDetailRepository.GetMultiPaging(x => x.Status,out total, index, size);
        }

        public OrderDetail GetSingleByCondition(Expression<Func<OrderDetail, bool>> expression, string[] includes = null)
        {
            throw new NotImplementedException();
        }

        public OrderDetail GetSingleById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(OrderDetail entity)
        {
            _OrderDetailRepository.Update(entity);
        }

        public void DeleteMulti(Expression<Func<OrderDetail, bool>> where)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderDetail> GetMulti(Expression<Func<OrderDetail, bool>> where, string[] includes = null)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }
    }
}
