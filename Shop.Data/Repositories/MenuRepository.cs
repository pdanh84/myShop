﻿using Shop.Data.Infrastructure;
using Shop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Repositories
{
    public interface IMenuRepository
    {

    }
    public class MenuRepository: RepositoryBase<Menu>, IMenuRepository
    {
        public MenuRepository(DbFactory dbFactory): base(dbFactory)
        {

        }
    }
}
