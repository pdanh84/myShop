using Shop.Data.Infrastructure;
using Shop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Repositories
{
    public interface IPostCategoryRepository : IRepository<PostCategory>
    {
        IEnumerable<PostCategory> GetByAlias(string alias);
    }
    public class PostCategoryRepository: RepositoryBase<PostCategory> , IPostCategoryRepository
    {
        public PostCategoryRepository(DbFactory dbFactory) : base(dbFactory)
        {

        }
        /// <summary>
        /// implement
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PostCategory> GetByAlias(string alias)
        {
            var query = (from postCategory in this.DbContext.PostCategories
                         where postCategory.Alias == alias
                         select postCategory) as IEnumerable<PostCategory>;
            return query;
        }
    }
}
