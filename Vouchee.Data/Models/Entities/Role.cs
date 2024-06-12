using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Vouchee.Data.Models.Entities
{
    [Table("Role")]
    public class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid RoleId { get; set; }

        [Required]
        [StringLength(50)]
        public string RoleName { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
