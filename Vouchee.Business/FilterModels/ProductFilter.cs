using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vouchee.Data.Models.Entities;

namespace Vouchee.Business.FilterModels
{
    public class ProductFilter
    {
        public ProductFilter()
        {
            /*Users = new HashSet<UserFilter>();
            Comments = new HashSet<CommentFilter>();
            Discounts = new HashSet<DiscountFilter>();
            Ratings = new HashSet<RatingFilter>();*/
            Tags = new HashSet<TagFilter>();
            Categories = new HashSet<CategoryFilter>();
        }

        public Guid? ProductId { get; set; }

        public string? ProductName { get; set; }

        public string? ProductDescription { get; set; }

        public decimal? ProductPrice { get; set; }

        public decimal? ProductDiscountPrice { get; set; }

        public int? Amount { get; set; }

        public DateTime? StartDateTime { get; set; }

        public DateTime? EndDateTime { get; set; }

        public string? ProductPolicy { get; set; }

        public string? ProductCode { get; set; }

        public string? ProductCodeImage { get; set; }

        public DateTime? CreatedDate { get; set; }

        public Guid? CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public Guid? UpdatedBy { get; set; }

        /*public virtual ICollection<UserFilter>? Users { get; set; }

        public virtual ICollection<CommentFilter>? Comments { get; set; }

        public virtual ICollection<DiscountFilter>? Discounts { get; set; }

        public virtual ICollection<RatingFilter>? Ratings { get; set; }*/

        public virtual ICollection<TagFilter>? Tags { get; set; }

        public virtual ICollection<CategoryFilter> Categories { get; set; }
    }
}
