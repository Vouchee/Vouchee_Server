using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vouchee.Infrastructure.RequestModels.Location
{
	public class CreateLocationRequest
	{
		[Required]
		public string LocationCity { get; set; }
		[Required]
		public string LocationDistrict { get; set; }
		[Required]
		public string LocationWard { get; set; }
		[Required]
		public string LocationStreet { get; set; }
		[Required]
		public string LocationDetails { get; set; }
		[Required]
		public Guid ShopId { get; set; }
	}
}
