using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vouchee.Data.Repositories.Interfaces;
using Vouchee.Data.Helpers;
using Vouchee.Data.Models.Entities;
using Vouchee.Data.Repositories.Impls;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace Vouchee.Data.Repositories.Repos
{
    public class TransactionRepo : BaseRepo<Transaction>, ITransactionRepo
    {
        private readonly VoucheeContext _context;
        private readonly UserManager<User> _userManager;
        private readonly DbSet<Transaction> _transactionSet;
        private readonly IMapper _mapper;
        public TransactionRepo(VoucheeContext context, UserManager<User> userManager, IMapper mapper) : base(context)
        {
            _context = context;
            _userManager = userManager;
            _transactionSet = _context.Set<Transaction>();
            _mapper = mapper;
        }

        public async Task AddfixAsync(Transaction entity)
        {
            var user = await _userManager.FindByIdAsync(entity.UserId.ToString());
            if (user != null)
            {
                // Ensure that Transactions is not null and can be added to
                if (user.Transactions == null)
                {
                    user.Transactions = new List<Transaction>();
                }
                /*var trans = _context.Entry(entity).State = EntityState.Added;*/
                user.Transactions.Add(entity);
                
                // Update the user and save changes asynchronously
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    await _context.SaveChangesAsync();
                }
            }

        }

        public async Task UpdatefixAsync(Transaction entity)
        {
            var user = await _userManager.FindByIdAsync(entity.UserId.ToString());
            var tran = user.Transactions.FirstOrDefault(t => t.TransactionId == entity.TransactionId);
            if (tran != null)
            {
                _mapper.Map(entity, tran);
            }
            await _userManager.UpdateAsync(user);
            _context.SaveChangesAsync();
        }
    }
}
