using Shop.Data.Infrastructure;
using Shop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Repositories
{
    public interface IProductTagRepository
    {

    }
    public class ProductTagRepository: RepositoryBase<ProductTag>, IProductTagRepository
    {
       
        public ProductTagRepository(DbFactory dbFactory):base(dbFactory){
            
        }
    }
}
