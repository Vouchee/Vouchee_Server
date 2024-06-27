using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Vouchee.Data.Helpers;
using Vouchee.Data.Models.Entities;
using Vouchee.Data.Repositories.Interfaces;

namespace Vouchee.Data.Repositories.Impls
{
    public class UserRepo : IUserRepo
    {
        private readonly VoucheeContext _context;
        private readonly UserManager<User> _userManager;

        public UserRepo(VoucheeContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task AddAsync(User entity, string pass)
        {
            await _userManager.CreateAsync(entity, pass);
        }

        public async Task<bool> CheckPasswordAsync(Guid id, string pass)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            if (user == null)
                return false;

            var passwordVerificationResult = await _userManager.CheckPasswordAsync(user, pass);
            return passwordVerificationResult;
        }

        public async void Delete(User entity)
        {
            await _userManager.DeleteAsync(entity);
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            return await _userManager.FindByIdAsync(id.ToString());
        }

        public async Task<User> GetFirstOrDefaultAsync(Expression<Func<User, bool>> predicate)
        {
            return await _userManager.Users.FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<User>> GetWhereAsync(Expression<Func<User, bool>> predicate)
        {
            return await _userManager.Users.Where(predicate).ToListAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async void Update(User entity)
        {
            await _userManager.UpdateAsync(entity);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            var result = await _userManager.Users.ToListAsync();
            return result;
        }
        public async Task<IdentityResult> CreatePass(User entity, string pass)
        {
            return await _userManager.AddPasswordAsync(entity, pass);
        }
        public async Task<IdentityResult> RemovePass (User entity)
        {
            return await _userManager.RemovePasswordAsync(entity);
        }

    }
}
