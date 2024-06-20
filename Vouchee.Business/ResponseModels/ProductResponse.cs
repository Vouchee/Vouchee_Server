using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vouchee.Data.Models.Entities;

namespace Vouchee.Business.ResponseModels
{
    public class ProductResponse
    {
        public ProductResponse()
        {
            /*Users = new HashSet<UserResponse>();*/
            /*Comments = new HashSet<CommentResponse>();
            Discounts = new HashSet<DiscountResponse>();
            Ratings = new HashSet<RatingResponse>();*/
            Tags = new HashSet<TagResponse>();
            Categories = new HashSet<CategoryResponse>();
        }

        public Guid ProductId { get; set; }

        public string ProductName { get; set; }

        public string ProductDescription { get; set; }

        public decimal ProductPrice { get; set; }

        public decimal ProductDiscountPrice { get; set; }

        public int Amount { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public string ProductPolicy { get; set; }

        public string ProductCode { get; set; }

        public string ProductCodeImage { get; set; }

        public DateTime CreatedDate { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public Guid? UpdatedBy { get; set; }

        /*public virtual ICollection<UserResponse> Users { get; set; }*/

        /*public virtual ICollection<CommentResponse>? Comments { get; set; }*/

       /* public virtual ICollection<DiscountResponse>? Discounts { get; set; }

        public virtual ICollection<RatingResponse>? Ratings { get; set; }*/

        public virtual ICollection<TagResponse> Tags { get; set; }

        public virtual ICollection<CategoryResponse> Categories { get; set; }
    }
}
