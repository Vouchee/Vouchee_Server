﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vouchee.Data.Repositories.Interfaces;
using Vouchee.Data.Helpers;
using Vouchee.Data.Models.Entities;
using Vouchee.Data.Repositories.Impls;
using Vouchee.Data.Repositories.Repos;

namespace Vouchee.Data.Repositories.Repos
{
    public class ProductRepo : BaseRepo<Product>, IProductRepo
    {
        private readonly VoucheeContext _context;

        public ProductRepo(VoucheeContext context) : base(context)
        {
            _context = context;
        }
    }
}
