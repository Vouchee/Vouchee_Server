using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vouchee.Data.Models.Entities;
using Vouchee.Data.Repositories.Interfaces;

namespace Vouchee.Data.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IBaseRepo<Category>  Categories { get; }
        IBaseRepo<Comment> Comments { get; }
        IBaseRepo<Discount> Discounts { get; }
        IBaseRepo<Image> Images { get; }
        IBaseRepo<Location> Locations { get; }
        IBaseRepo<Notify> Notifies { get; }
        IBaseRepo<Product> Products { get; }
        IBaseRepo<Promotion> Promotions { get; }
        IBaseRepo<Rating> Ratings { get; }
        IBaseRepo<Role> Roles { get; }
        IBaseRepo<Shop> Shops { get; }
        IBaseRepo<Tag> Tags { get; }
        IBaseRepo<Transaction> Transactions { get; }
        IBaseRepo<User> Users { get; }
        IBaseRepo<Wallet> Wallets { get; }

        Task SaveAsync();
    }
}
