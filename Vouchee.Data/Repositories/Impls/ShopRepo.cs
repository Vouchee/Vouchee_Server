using System;
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
    public class ShopRepo : BaseRepo<Shop>, IShopRepo
    {
        private readonly VoucheeContext _context;

        public ShopRepo(VoucheeContext context) : base(context)
        {
            _context = context;
        }
    }
}
