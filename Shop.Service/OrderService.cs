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
    public interface IOrderService
    {
        //Add new entity
        Order Add(Order entity);
        //Update entity
        void Update(Order entity);
        //Delete by enttiy
        Order Delete(Order entity);
        //Delete by id
        Order Delete(int id);
        //Delete multi entity
        void DeleteMulti(Expression<Func<Order, bool>> where);
        //Get entity by id
        Order GetSingleById(int id);
        //Get entity by condition
        Order GetSingleByCondition(Expression<Func<Order, bool>> expression, string[] includes = null);
        //Get all entity
        IEnumerable<Order> GetAll(string[] includes = null);
        //Get multi entity
        IEnumerable<Order> GetMulti(Expression<Func<Order, bool>> where, string[] includes = null);
        //Get paging entity
        IEnumerable<Order> GetMultiPaging(Expression<Func<Order, bool>> filter, out int total, int index = 0, int size = 50, string[] includes = null);

        IEnumerable<Order> GetAllPaging(out int total, int index = 0, int size = 50, string[] includes = null);

        void SaveChanges();
    }
    public class OrderService : IOrderService
    {
        IOrderRepository _OrderRepository;
        IUnitOfWork _unitOfWork;
        public OrderService(IOrderRepository OrderRepository, IUnitOfWork unitOfWork)
        {
            this._OrderRepository = OrderRepository;
            this._unitOfWork = unitOfWork;
        }
        public Order Add(Order entity)
        {
            return _OrderRepository.Add(entity);
        }

        public Order Delete(int id)
        {
            return _OrderRepository.Delete(id);
        }

        public Order Delete(Order entity)
        {
            return _OrderRepository.Delete(entity);
        }

        public IEnumerable<Order> GetAll(string[] includes = null)
        {
            return _OrderRepository.GetAll(new string[] { "OrderDetail" });
        }

        public IEnumerable<Order> GetMultiPaging(Expression<Func<Order, bool>> filter, out int total, int index = 0, int size = 50, string[] includes = null)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Order> GetAllPaging(out int total, int index = 0, int size = 50, string[] includes = null)
        {
            return _OrderRepository.GetMultiPaging(x => x.Status,out total, index, size);
        }

        public Order GetSingleByCondition(Expression<Func<Order, bool>> expression, string[] includes = null)
        {
            throw new NotImplementedException();
        }

        public Order GetSingleById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Order entity)
        {
            _OrderRepository.Update(entity);
        }

        public void DeleteMulti(Expression<Func<Order, bool>> where)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetMulti(Expression<Func<Order, bool>> where, string[] includes = null)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }
    }
}
