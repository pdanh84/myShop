using Shop.Data.Infrastructure;
using Shop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Repositories
{
    public interface ISlideRepository : IRepository<Slice>
    {

    }
    public class SlideRepository: RepositoryBase<Slice>, ISlideRepository
    {
       
        public SlideRepository(DbFactory dbFactory):base(dbFactory){
            
        }
    }
}
