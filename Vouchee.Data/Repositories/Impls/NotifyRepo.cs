﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vouchee.Data.Repositories.Interfaces;
using Vouchee.Data.Helpers;
using Vouchee.Data.Models.Entities;
using Vouchee.Data.Repositories.Impls;
namespace Vouchee.Data.Repositories.Impls
{
    public class NotifyRepo : BaseRepo<Notify>, INotifyRepo
    {
        private readonly VoucheeContext _context;

        public NotifyRepo(VoucheeContext context) : base(context)
        {
            _context = context;
        }
    }
}
