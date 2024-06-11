using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vouchee.Data.Models.Entities;
using Vouchee.Data.Repositories.Interfaces;

namespace Vouchee.Data.Repositories.Interfaces
{
    public interface IProductRepo : IBaseRepo<Product>
    {
    }
}
