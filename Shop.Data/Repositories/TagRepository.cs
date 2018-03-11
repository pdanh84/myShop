﻿using Shop.Data.Infrastructure;
using Shop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Repositories
{
    public interface ITagRepository
    {

    }
    public class TagRepository: RepositoryBase<Tag>, ITagRepository
    {
       
        public TagRepository(DbFactory dbFactory):base(dbFactory){
            
        }
    }
}
