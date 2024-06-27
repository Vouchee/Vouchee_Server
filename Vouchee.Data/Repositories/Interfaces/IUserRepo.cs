using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Vouchee.Data.Models.Entities;
using Vouchee.Data.Repositories.Interfaces;

namespace Vouchee.Data.Repositories.Interfaces
{
    public interface IUserRepo
    {
        Task<bool> CheckPasswordAsync(Guid id, string pass);
        Task<User> GetByIdAsync(Guid id);
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetFirstOrDefaultAsync(Expression<Func<User, bool>> predicate);
        Task<IEnumerable<User>> GetWhereAsync(Expression<Func<User, bool>> predicate);
        Task AddAsync(User entity, string pass);
        void Update(User entity);
        void Delete(User entity);
        Task SaveAsync();
        Task<IdentityResult> CreatePass(User entity, string pass);
        Task<IdentityResult> RemovePass(User entity);

    }
}
