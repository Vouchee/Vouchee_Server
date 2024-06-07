using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vouchee.Domain.Entities;

namespace Vouchee.Infrastructure.FilterModels
{
	public class CategoryFilter
	{
		public string? CategoryTitle { get; set; }
		public string? CategoryDescription { get; set; }

		public ICollection<ProductCategory>? ProductCategories { get; set; } = new List<ProductCategory>();
	}
}
