﻿using Shop.Data.Infrastructure;
using Shop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Repositories
{
    public interface IVisitorStatisticRepository
    {

    }
    public class VisitorStatisticRepository: RepositoryBase<VisitorStatistic>, IVisitorStatisticRepository
    {
       
        public VisitorStatisticRepository(DbFactory dbFactory):base(dbFactory){
            
        }
    }
}