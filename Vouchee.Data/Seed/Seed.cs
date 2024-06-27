using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Vouchee.Data.Helpers;
using Vouchee.Data.Models.Constants.Enum;
using Vouchee.Data.Models.Entities;

namespace Vouchee.Data.Seed
{
    public class Seed
    {
        public static async Task SeedCategory(VoucheeContext _context)
        {
            if (await _context.Categories.AnyAsync()) { return; }

            var list = new List<Category>
            {
                new Category {CategoryTitle="Electronics", CategoryDescription = "Electronic gadgets and appliances"},
                new Category { CategoryTitle = "Electronics", CategoryDescription = "Electronic gadgets and appliances" },
                new Category { CategoryTitle = "Clothing", CategoryDescription = "Men's, Women's, and Children's apparel" },
                new Category { CategoryTitle = "Books", CategoryDescription = "Books on various topics" },
                new Category { CategoryTitle = "Home Decor", CategoryDescription = "Furniture, decorations, and home essentials" },
                new Category { CategoryTitle = "Sports Equipment", CategoryDescription = "Sporting goods and equipment" },
                new Category { CategoryTitle = "Beauty and Personal Care", CategoryDescription = "Cosmetics, skincare, and personal hygiene products" }
            };

            foreach (var i in list)
            {
                await _context.Categories.AddAsync(i);
                await _context.SaveChangesAsync();
            }
        }
        public static async Task SeedComment(VoucheeContext _context)
        {
            if (await _context.Comments.AnyAsync()) return;

            var commentData = await File.ReadAllTextAsync("../Vouchee.Data/Seed/CommentSeed.json");
            var jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var comments = JsonSerializer.Deserialize<List<Comment>>(commentData, jsonOptions);

            foreach (var comment in comments)
            {
                await _context.Comments.AddAsync(comment);
                await _context.SaveChangesAsync();
            }
        }
        public static async Task SeedDiscount(VoucheeContext _context)
        {
            if (await _context.Comments.AnyAsync()) return;

            var disData = await File.ReadAllTextAsync("../Vouchee.Data/Seed/DiscountSeed.json");
            var jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var dises = JsonSerializer.Deserialize<List<Discount>>(disData, jsonOptions);

            foreach (var dis in dises)
            {
                await _context.Discounts.AddAsync(dis);
                await _context.SaveChangesAsync();
            }
        }
        public static async Task SeedImage(VoucheeContext _context)
        {
            if (await _context.Images.AnyAsync()) { return; }

            var list = new List<Image>
            {
               new Image {ImageType = ImageType.Avatar, ImageUrl = "https://inducthanh.vn/media/data/product/VOUCHER-61.jpg"},
               new Image {ImageType = ImageType.Avatar, ImageUrl = "https://i0.wp.com/baobibigsun.com/wp-content/uploads/2021/01/voucher.png?w=650&ssl=1"},
               new Image {ImageType = ImageType.BackGround, ImageUrl = "https://file.hstatic.net/1000192210/file/voucher-la-gi_1_73e7d99f5ca343b9a6fad732078c9834.jpg"},
            };

            foreach (var i in list)
            {
                await _context.Images.AddAsync(i);
                await _context.SaveChangesAsync();
            }
        }
        public static async Task SeedLocation(VoucheeContext _context)
        {
            if (await _context.Locations.AnyAsync()) return;

            var locateData = await File.ReadAllTextAsync("../Vouchee.Data/Seed/LocationSeed.json");
            var jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var locates = JsonSerializer.Deserialize<List<Location>>(locateData, jsonOptions);

            foreach (var locate in locates)
            {
                await _context.Locations.AddAsync(locate);
                await _context.SaveChangesAsync();
            }
        }
        public static async Task SeedNotify(VoucheeContext _context)
        {
            if (await _context.Notifies.AnyAsync()) return;

            var notifyData = await File.ReadAllTextAsync("../Vouchee.Data/Seed/NotifySeed.json");
            var jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var notifies = JsonSerializer.Deserialize<List<Notify>>(notifyData, jsonOptions);

            foreach (var notify in notifies)
            {
                await _context.Notifies.AddAsync(notify);
                await _context.SaveChangesAsync();
            }
        }
        public static async Task SeedProduct(VoucheeContext _context)
        {
            if (await _context.Products.AnyAsync()) return;

            var productData = await File.ReadAllTextAsync("../Vouchee.Data/Seed/ProductSeed.json");
            var jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var products = JsonSerializer.Deserialize<List<Product>>(productData, jsonOptions);
            var rating = new List<Rating>
            {
                new Rating { CreatedDate = DateTime.Now,RatingTitle = "Excellent Product",RatingType = RatingType.Excellent,RatingContent = "I am extremely satisfied with this product. It exceeded my expectations!"},
                new Rating { CreatedDate = DateTime.Now,RatingTitle = "Good Value",RatingType = RatingType.Good,RatingContent = "The product offers good value for money. Would recommend!"}
            };

            foreach (var product in products)
            {
                product.CreatedDate = DateTime.Now;
                product.Ratings = rating;
                await _context.Products.AddAsync(product);
                await _context.SaveChangesAsync();
            }
        }
        public static async Task SeedPromotion(VoucheeContext _context)
        {
            if (await _context.Promotions.AnyAsync()) return;

            var promoData = await File.ReadAllTextAsync("../Vouchee.Data/Seed/PromotionSeed.json");
            var jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var promos = JsonSerializer.Deserialize<List<Promotion>>(promoData, jsonOptions);

            foreach (var promo in promos)
            {
                await _context.Promotions.AddAsync(promo);
                await _context.SaveChangesAsync();
            }
        }
        public static async Task SeedRating(VoucheeContext _context)
        {
            if (await _context.Ratings.AnyAsync()) return;

            var RatingData = await File.ReadAllTextAsync("../Vouchee.Data/Seed/RatingSeed.json");
            var jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var Ratings = JsonSerializer.Deserialize<List<Rating>>(RatingData, jsonOptions);

            foreach (var Rating in Ratings)
            {
                await _context.Ratings.AddAsync(Rating);
                await _context.SaveChangesAsync();
            }
        }
        public static async Task SeedUser(VoucheeContext _context, UserManager<User> _userManager)
        {

            if (await _userManager.Users.AnyAsync()) return;

            var userData = await File.ReadAllTextAsync("../Vouchee.Data/Seed/UserSeed.json");
            var jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var users = JsonSerializer.Deserialize<List<AddUserDto>>(userData, jsonOptions);

            foreach (var user in users)
            {
                var appUser = new User
                {
                    UserName = user.Username,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    Fullname = user.Fullname,
                    Id = user.UserId,
                    Gender = 0,
                };
                await _userManager.CreateAsync(appUser, "password");
                await _context.SaveChangesAsync();
            }
        }
        public static async Task SeedShop(VoucheeContext _context, UserManager<User> userManager)
        {
            if (await _context.Shops.AnyAsync()) return;

            var shopData = await File.ReadAllTextAsync("../Vouchee.Data/Seed/ShopSeed.json");
            var jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var shops = JsonSerializer.Deserialize<List<Shop>>(shopData, jsonOptions);

            foreach (var shop in shops)
            {
                // Create the user if it doesn't exist
                var user = await userManager.FindByIdAsync(shop.UserId.ToString());
                if (user == null)
                {
                    user = new User { Id = shop.UserId, UserName = shop.UserId.ToString(), Email = shop.UserId.ToString() + "@example.com", Fullname = "J" };
                    await userManager.CreateAsync(user);
                }

                shop.User = user;
                await _context.Shops.AddAsync(shop);
                await _context.SaveChangesAsync();
            }
        }

        public static async Task SeedWallet(VoucheeContext _context, UserManager<User> userManager)
        {
            if (await _context.Wallets.AnyAsync()) return;

            var walletData = await File.ReadAllTextAsync("../Vouchee.Data/Seed/WalletSeed.json");
            var jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var wallets = JsonSerializer.Deserialize<List<Wallet>>(walletData, jsonOptions);

            foreach (var wallet in wallets)
            {
                // Create the user if it doesn't exist
                var user = await userManager.FindByIdAsync(wallet.UserId.ToString());
                if (user == null)
                {
                    user = new User { Id = wallet.UserId, UserName = wallet.UserId.ToString(), Email = wallet.UserId.ToString() + "@example.com", Fullname = "J"};
                    await userManager.CreateAsync(user);
                }

                wallet.User = user;
                await _context.Wallets.AddAsync(wallet);
                await _context.SaveChangesAsync();
            }
        }

        public class AddUserDto
        {
            [Required]
            public required string Fullname { get; set; }
            [Required]
            public required string Username { get; set; }
            [Required]
            [EmailAddress]
            public required string Email { get; set; }
            [Required]
            [Phone]
            public string? PhoneNumber { get; set; }
            public Guid UserId { get; set; }
/*            [Required]
            public required string Password { get; set; }*/
        }
    }
}
