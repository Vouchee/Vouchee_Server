using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vouchee.Infrastructure.WebRequests.Category
{
	public class UpdateCategoryRequest
	{
		[Required]
		public string CategoryTitle { get; set; }
		[Required]
		public string CategoryDescription { get; set; }
	}
}
