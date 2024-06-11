using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vouchee.Data.Helpers;
using Vouchee.Data.Models.Entities;
using Vouchee.Data.Repositories.Interfaces;

namespace Vouchee.Data.Repositories.Impls
{
    public class CategoryRepo : BaseRepo<Category>, ICategoryRepo
    {
        private readonly VoucheeContext _context;

        public CategoryRepo(VoucheeContext context) : base(context)
        {
            _context = context;
        }
    }
}
