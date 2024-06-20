using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Vouchee.Data.Models.Constants.Enum;
using Vouchee.Data.Models.Entities;

namespace Vouchee.Data.Helpers
{
    public class VoucheeContext : IdentityDbContext<User, Role,
        Guid, IdentityUserClaim<Guid>, UserRole, IdentityUserLogin<Guid>,
        IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>
    {
        public VoucheeContext() 
        { 
        
        }

        public VoucheeContext(DbContextOptions<VoucheeContext> options) : base(options) 
        { 
        
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Discount> Discounts { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Notify> Notifies { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Promotion> Promotions { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Shop> Shops { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Wallet> Wallets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            // optionsBuilder.UseSqlServer("Server=localhost;Database=Vouchee;Trusted_Connection=false;user=sa;pwd=123456@Aa;TrustServerCertificate=True");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(u => u.Shop)
                .WithOne(s => s.User)
                .HasForeignKey<Shop>(s => s.UserId);
            
            modelBuilder.Entity<User>().HasMany(u => u.Roles)
                .WithOne(u => u.User)
                .HasForeignKey(u => u.UserId)
                .IsRequired();

            modelBuilder.Entity<User>()
                .HasOne(u => u.Wallet)
                .WithOne(w => w.User)
                .HasForeignKey<Wallet>(w => w.UserId); 
            
            modelBuilder.Entity<Role>().HasMany(r => r.Roles)
                .WithOne(r => r.Role)
                .HasForeignKey(r => r.RoleId)
                .IsRequired();
           modelBuilder.Entity<Role>().HasData(new Role
               {
                   Id = Guid.NewGuid(),
                   Name = SystemRole.Admin.ToString(),
                   NormalizedName = SystemRole.Admin.ToString().ToUpper(),
               },
               new Role
               {
                   Id = Guid.NewGuid(),
                   Name = SystemRole.Customer.ToString(),
                   NormalizedName = SystemRole.Customer.ToString().ToUpper(),
               },
               new Role
               {
                   Id = Guid.NewGuid(),
                   Name = SystemRole.Shop.ToString(),
                   NormalizedName = SystemRole.Shop.ToString().ToUpper(),
               },
               new Role
               {
                   Id = Guid.NewGuid(),
                   Name = SystemRole.Staff.ToString(),
                   NormalizedName = SystemRole.Staff.ToString().ToUpper(),
               }
           );
               

            base.OnModelCreating(modelBuilder);
        }
    }
}
