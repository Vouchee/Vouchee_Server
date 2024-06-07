using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vouchee.Domain.Enums;

namespace Vouchee.Infrastructure.RequestModels.Discount
{
	public class CreateDiscountRequest
	{
		[Required]
		public string DiscountName { get; set; }
		[Required]
		public string DiscountDescription { get; set; }
		[Required]
		public string DiscountCode { get; set; }
		[Required]
		public DiscountStatus DiscountStatus { get; set; }
		[Required]
		public DateTime StartDate { get; set; }
		[Required]
		public DateTime ExpireDateTime { get; set; }
		[Required]
		public int Amount { get; set; }
	}
}
