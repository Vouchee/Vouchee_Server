using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vouchee.Domain.Entities;
using Vouchee.Domain.Enums;

namespace Vouchee.Infrastructure.RequestModels.Comment
{
	public class CreateCommentRequest
	{
		[Required]
		public string Description { get; set; }
		[Required]
		public CommentStatus CommentStatus { get; set; }
		[Required]
		public Guid UserId { get; set; }
		[Required]
		public Guid ProductId { get; set; }
	}
}
