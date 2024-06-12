using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vouchee.Business.RequestModels.Helpers
{
    public class PagingRequest
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public SortOrder OrderType { get; set; } = SortOrder.Ascending;
    }
}
