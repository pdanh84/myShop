using Shop.Data.Infrastructure;
using Shop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Repositories
{
    public interface IPostRepository : IRepository<Post>
    {
        /// <summary>
     /// Get tag paging by tagid
     /// </summary>
     /// <param name="tagId"></param>
     /// <param name="total"></param>
     /// <param name="index"></param>
     /// <param name="size"></param>
     /// <param name="includes"></param>
     /// <returns></returns>
        IEnumerable<Post> GetAllByTag(string tagId, int index, int pageSize, out int totalRow);
    }
    public class PostRepository: RepositoryBase<Post> , IPostRepository
    {
        public PostRepository(DbFactory dbFactory) : base(dbFactory)
        {

        }
        /// <summary>
        /// get paging by tagid
        /// </summary>
        /// <param name="tagId"></param>
        /// <param name="index"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalRow"></param>
        /// <returns></returns>
        public IEnumerable<Post> GetAllByTag(string tagId, int index, int pageSize, out int totalRow)
        {
            var query = from p in DbContext.Posts
                        join pt in DbContext.PostTags
                        on p.ID equals pt.PostID
                        where p.Status && pt.TagID == tagId
                        orderby p.CreatedDate descending
                        select p;

            totalRow = query.Count();

            query = query.Skip((pageSize - 1) * pageSize).Take(pageSize);

            return query;
                        
        }
    }
}
