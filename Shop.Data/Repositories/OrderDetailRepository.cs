using Shop.Data.Infrastructure;
using Shop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Shop.Data.Repositories
{
    public interface IOrderDetailRepository : IRepository<OrderDetail>
    {

    }
    public class OrderDetailRepository: RepositoryBase<Order> , IOrderDetailRepository
    {
        public OrderDetailRepository(DbFactory dbFactory) : base(dbFactory)
        {

        }

        public OrderDetail Add(OrderDetail entity)
        {
            throw new NotImplementedException();
        }

        public bool CheckContains(Expression<Func<OrderDetail, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public int Count(Expression<Func<OrderDetail, bool>> where)
        {
            throw new NotImplementedException();
        }

        public OrderDetail Delete(OrderDetail entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteMulti(Expression<Func<OrderDetail, bool>> where)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderDetail> GetMulti(Expression<Func<OrderDetail, bool>> where, string[] includes = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderDetail> GetMultiPaging(Expression<Func<OrderDetail, bool>> filter, out int total, int index = 0, int size = 50, string[] includes = null)
        {
            throw new NotImplementedException();
        }

        public OrderDetail GetSingleByCondition(Expression<Func<OrderDetail, bool>> expression, string[] includes = null)
        {
            throw new NotImplementedException();
        }

        public void Update(OrderDetail entity)
        {
            throw new NotImplementedException();
        }

        OrderDetail IRepository<OrderDetail>.Delete(int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<OrderDetail> IRepository<OrderDetail>.GetAll(string[] includes)
        {
            throw new NotImplementedException();
        }

        OrderDetail IRepository<OrderDetail>.GetSingleById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
