using Shop.Data.Infrastructure;
using Shop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Repositories
{
    public interface IProductCategoryRepository{
        IEnumerable<ProductCategory> GetByAlias(string alias);
    }
    public class ProductCategoryRepository : RepositoryBase<ProductCategory>,IProductCategoryRepository
    {
        ProductCategoryRepository(DbFactory dbFactory) : base(dbFactory)
        {

        }
        /// <summary>
        /// implement
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ProductCategory> GetByAlias(string alias)
        {
            var query = (from productCategory in this.DbContext.ProductCategories
                         where productCategory.Alias == alias
                         select productCategory) as IEnumerable<ProductCategory>;
            return query;
        }
    }
}
