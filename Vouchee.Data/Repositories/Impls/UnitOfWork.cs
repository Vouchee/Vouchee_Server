using System;
using System.Threading.Tasks;
using Vouchee.Data.Models.Entities;
using Vouchee.Data.Helpers;
using Vouchee.Data.Repositories.Interfaces;
using Vouchee.Data.Repositories.Interfaces;

namespace Vouchee.Data.Repositories.Impls
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly VoucheeContext _context;

        public UnitOfWork(VoucheeContext context)
        {
            _context = context;
        }

        private IBaseRepo<Category> _categories;
        public IBaseRepo<Category> Categories => _categories ??= new BaseRepo<Category>(_context);

        private IBaseRepo<Comment> _comments;
        public IBaseRepo<Comment> Comments => _comments ??= new BaseRepo<Comment>(_context);

        private IBaseRepo<Discount> _discounts;
        public IBaseRepo<Discount> Discounts => _discounts ??= new BaseRepo<Discount>(_context);

        private IBaseRepo<Image> _images;
        public IBaseRepo<Image> Images => _images ??= new BaseRepo<Image>(_context);

        private IBaseRepo<Location> _locations;
        public IBaseRepo<Location> Locations => _locations ??= new BaseRepo<Location>(_context);

        private IBaseRepo<Notify> _notifies;
        public IBaseRepo<Notify> Notifies => _notifies ??= new BaseRepo<Notify>(_context);

        private IBaseRepo<Product> _products;
        public IBaseRepo<Product> Products => _products ??= new BaseRepo<Product>(_context);

        private IBaseRepo<Promotion> _promotions;
        public IBaseRepo<Promotion> Promotions => _promotions ??= new BaseRepo<Promotion>(_context);

        private IBaseRepo<Rating> _ratings;
        public IBaseRepo<Rating> Ratings => _ratings ??= new BaseRepo<Rating>(_context);

        private IBaseRepo<Role> _roles;
        public IBaseRepo<Role> Roles => _roles ??= new BaseRepo<Role>(_context);

        private IBaseRepo<Shop> _shops;
        public IBaseRepo<Shop> Shops => _shops ??= new BaseRepo<Shop>(_context);

        private IBaseRepo<Tag> _tags;
        public IBaseRepo<Tag> Tags => _tags ??= new BaseRepo<Tag>(_context);

        private IBaseRepo<Transaction> _transactions;
        public IBaseRepo<Transaction> Transactions => _transactions ??= new BaseRepo<Transaction>(_context);

        private IBaseRepo<User> _users;
        public IBaseRepo<User> Users => _users ??= new BaseRepo<User>(_context);

        private IBaseRepo<Wallet> _wallets;
        public IBaseRepo<Wallet> Wallets => _wallets ??= new BaseRepo<Wallet>(_context);

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
