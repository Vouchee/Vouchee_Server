using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vouchee.Domain.Entities;

namespace Vouchee.Infrastructure.RequestModels.Category
{
	public class CreateCategoryRequest
	{
		[Required]
		public string CategoryTitle { get; set; }
		[Required]
		public string CategoryDescription { get; set; }
	}
}
