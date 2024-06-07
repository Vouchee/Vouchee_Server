using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vouchee.Infrastructure.RequestModels.Helpers
{
	public class PagingRequest
	{
		public int Page { get; set; } = 1;
		public int PageSize { get; set; } = 10;
		public string KeySearch { get; set; } = "";
		public string SearchBy { get; set; } = "";
		public SortOrder SortType { get; set; } = SortOrder.Descending;
		public string CollName { get; set; } = "Id";
	}
}
