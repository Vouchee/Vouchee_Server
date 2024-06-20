using Vouchee.Business.Services.Impls;
using Vouchee.Business.Services.Interfaces;
using Vouchee.Data.Helpers;
using Vouchee.Data.Repositories.Impls;
using Vouchee.Data.Repositories.Interfaces;
using Vouchee.Data.Repositories.Repos;

namespace Vouchee.API.AppStarts
{
    public static class DependencyInjectionConfig
    {
        public static void ConfigDI(this IServiceCollection services)
        {
            services.AddScoped<VoucheeContext>();

            services.AddScoped(typeof(IBaseRepo<>), typeof(BaseRepo<>));

            services.AddScoped<ICategoryRepo, CategoryRepo>();
            services.AddScoped<ICategoryService, CategoryService>();

            services.AddScoped<ICommentRepo, CommentRepo>();
            services.AddScoped<ICommentService, CommentService>();

            services.AddScoped<IDiscountRepo, DiscountRepo>();
            services.AddScoped<IDiscountService, DiscountService>();

            services.AddScoped<IImageRepo, ImageRepo>();
            services.AddScoped<IImageService, ImageService>();

            services.AddScoped<ILocationRepo, LocationRepo>();
            services.AddScoped<ILocationService, LocationService>();

            services.AddScoped<INotifyRepo, NotifyRepo>();
            services.AddScoped<INotifyService, NotifyService>();

            services.AddScoped<IProductRepo, ProductRepo>();
            services.AddScoped<IProductService, ProductService>();

            services.AddScoped<IPromotionRepo, PromotionRepo>();
            services.AddScoped<IPromotionService, PromotionService>();

            services.AddScoped<IRatingRepo, RatingRepo>();
            services.AddScoped<IRatingService, RatingService>();

            services.AddScoped<IRoleRepo, RoleRepo>();
            services.AddScoped<IRoleService, RoleService>();

            services.AddScoped<IShopRepo, ShopRepo>();
            services.AddScoped<IShopService, ShopService>();

            services.AddScoped<ITagRepo, TagRepo>();
            services.AddScoped<ITagService, TagService>();

            services.AddScoped<ITransactionRepo, TransactionRepo>();
            services.AddScoped<ITransactionService, TransactionService>();

            services.AddScoped<IUserRepo, UserRepo>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IWalletRepo, WalletRepo>();
            services.AddScoped<IWalletService, WalletService>();
            
            services.AddScoped<ITokenService, TokenService>();
            
        }
    }
}
