using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Infrastructure
{
    public interface IRepository<T> where T :class
    {
        //Add new entity
        T Add(T entity);
        //Update entity
        void Update(T entity);
        //Delete by enttiy
        T Delete(T entity);
        //Delete by id
        T Delete(int id);
        //Delete multi entity
        void DeleteMulti(Expression<Func<T, bool>> where);
        //Get entity by id
        T GetSingleById(int id);
        //Get entity by condition
        T GetSingleByCondition(Expression<Func<T, bool>> expression, string[] includes = null);
        //Get all entity
        IEnumerable<T> GetAll(string[] includes = null);
        //Get multi entity
        IEnumerable<T> GetMulti(Expression<Func<T, bool>> where, string[] includes = null);
        //Get paging entity
        IEnumerable<T> GetMultiPaging(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 50, string[] includes = null);
        //Count
        int Count(Expression<Func<T, bool>> where);
        //Check contains
        bool CheckContains(Expression<Func<T, bool>> predicate);
    }
}
