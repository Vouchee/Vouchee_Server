using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vouchee.Data.Models.Entities;

namespace Vouchee.Data.Helpers
{
    public class VoucheeContext : DbContext
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
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies();
                var builder = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                IConfigurationRoot configuration = builder.Build();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("VouncheeDB"));
                /*optionsBuilder.UseSqlServer("Server=(local);uid=sa;pwd=12345;database=Vouchee;TrustServerCertificate=True");*/
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(u => u.Shop)
                .WithOne(s => s.User)
                .HasForeignKey<Shop>(s => s.UserId);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Wallet)
                .WithOne(w => w.User)
                .HasForeignKey<Wallet>(w => w.UserId); 

            base.OnModelCreating(modelBuilder);
        }
    }
}
