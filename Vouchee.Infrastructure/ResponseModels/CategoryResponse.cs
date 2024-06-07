using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vouchee.Domain.Entities;

namespace Vouchee.Infrastructure.WebResponse
{
	public class CategoryResponse
	{
		public string CategoryTitle { get; set; }
		public string CategoryDescription { get; set; }

		public ICollection<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();
	}
}
