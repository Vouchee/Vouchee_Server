using AutoMapper;
using Vouchee.Business.FilterModels;
using Vouchee.Business.RequestModels.Product;
using Vouchee.Business.RequestModels.Comment;
using Vouchee.Business.ResponseModels;
using Vouchee.Data.Models.Entities;
using Vouchee.Business.RequestModels.Discount;
using Vouchee.Business.RequestModels.Image;
using Vouchee.Business.RequestModels.Location;
using Vouchee.Business.RequestModels.Notify;
using Vouchee.Business.RequestModels.Promotion;
using Vouchee.Business.RequestModels.Rating;
using Vouchee.Business.RequestModels.Role;
using Vouchee.Business.RequestModels.Shop;
using Vouchee.Business.RequestModels.Tag;
using Vouchee.Business.RequestModels.Transaction;
using Vouchee.Business.RequestModels.User;
using Vouchee.Business.RequestModels.Wallet;
using Vouchee.Business.RequestModels.Category;

namespace Vouchee.API.AppStarts
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            #region Category
            CreateMap<Category, CategoryResponse>().ReverseMap();
            CreateMap<Category, CreateCategoryRequest>().ReverseMap();
            CreateMap<Category, UpdateCategoryRequest>().ReverseMap();
            CreateMap<CategoryResponse, CreateCategoryRequest>().ReverseMap();
            CreateMap<CategoryResponse, UpdateCategoryRequest>().ReverseMap();
            CreateMap<CategoryResponse, CategoryFilter>().ReverseMap();
            #endregion

            #region Comment
            CreateMap<Comment, CommentResponse>().ReverseMap();
            CreateMap<Comment, CreateCommentRequest>().ReverseMap();
            CreateMap<Comment, UpdateCommentRequest>().ReverseMap();
            CreateMap<CommentResponse, CreateCommentRequest>().ReverseMap();
            CreateMap<CommentResponse, UpdateCommentRequest>().ReverseMap();
            CreateMap<CommentResponse, CommentFilter>().ReverseMap();
            #endregion

            #region Discount
            CreateMap<Discount, DiscountResponse>().ReverseMap();
            CreateMap<Discount, CreateDiscountRequest>().ReverseMap();
            CreateMap<Discount, UpdateDiscountRequest>().ReverseMap();
            CreateMap<DiscountResponse, CreateDiscountRequest>().ReverseMap();
            CreateMap<DiscountResponse, UpdateDiscountRequest>().ReverseMap();
            CreateMap<DiscountResponse, DiscountFilter>().ReverseMap();
            #endregion

            #region Image
            CreateMap<Image, ImageResponse>().ReverseMap();
            CreateMap<Image, CreateImageRequest>().ReverseMap();
            CreateMap<Image, UpdateImageRequest>().ReverseMap();
            CreateMap<ImageResponse, CreateImageRequest>().ReverseMap();
            CreateMap<ImageResponse, UpdateImageRequest>().ReverseMap();
            CreateMap<ImageResponse, ImageFilter>().ReverseMap();
            #endregion

            #region Location
            CreateMap<Location, LocationResponse>().ReverseMap();
            CreateMap<Location, CreateLocationRequest>().ReverseMap();
            CreateMap<Location, UpdateLocationRequest>().ReverseMap();
            CreateMap<LocationResponse, CreateLocationRequest>().ReverseMap();
            CreateMap<LocationResponse, UpdateLocationRequest>().ReverseMap();
            CreateMap<LocationResponse, LocationFilter>().ReverseMap();
            #endregion

            #region Notify
            CreateMap<Notify, NotifyResponse>().ReverseMap();
            CreateMap<Notify, CreateNotifyRequest>().ReverseMap();
            CreateMap<Notify, UpdateNotifyRequest>().ReverseMap();
            CreateMap<NotifyResponse, CreateNotifyRequest>().ReverseMap();
            CreateMap<NotifyResponse, UpdateNotifyRequest>().ReverseMap();
            CreateMap<NotifyResponse, NotifyFilter>().ReverseMap();
            #endregion

            #region Product
            CreateMap<Product, ProductResponse>().ReverseMap();
            CreateMap<Product, CreateProductRequest>().ReverseMap();
            CreateMap<Product, UpdateProductRequest>().ReverseMap();
            CreateMap<ProductResponse, CreateProductRequest>().ReverseMap();
            CreateMap<ProductResponse, UpdateProductRequest>().ReverseMap();
            CreateMap<ProductResponse, ProductFilter>().ReverseMap();
            #endregion

            #region Promotion
            CreateMap<Promotion, PromotionResponse>().ReverseMap();
            CreateMap<Promotion, CreatePromotionRequest>().ReverseMap();
            CreateMap<Promotion, UpdatePromotionRequest>().ReverseMap();
            CreateMap<PromotionResponse, CreatePromotionRequest>().ReverseMap();
            CreateMap<PromotionResponse, UpdatePromotionRequest>().ReverseMap();
            CreateMap<PromotionResponse, PromotionFilter>().ReverseMap();
            #endregion

            #region Rating
            CreateMap<Rating, RatingResponse>().ReverseMap();
            CreateMap<Rating, CreateRatingRequest>().ReverseMap();
            CreateMap<Rating, UpdateRatingRequest>().ReverseMap();
            CreateMap<RatingResponse, CreateRatingRequest>().ReverseMap();
            CreateMap<RatingResponse, UpdateRatingRequest>().ReverseMap();
            CreateMap<RatingResponse, RatingFilter>().ReverseMap();
            #endregion

            #region Role
            CreateMap<Role, RoleResponse>().ReverseMap();
            CreateMap<Role, CreateRoleRequest>().ReverseMap();
            CreateMap<Role, UpdateRoleRequest>().ReverseMap();
            CreateMap<RoleResponse, CreateRoleRequest>().ReverseMap();
            CreateMap<RoleResponse, UpdateRoleRequest>().ReverseMap();
            CreateMap<RoleResponse, RoleFilter>().ReverseMap();
            #endregion

            #region Shop
            CreateMap<Shop, ShopResponse>().ReverseMap();
            CreateMap<Shop, CreateShopRequest>().ReverseMap();
            CreateMap<Shop, UpdateShopRequest>().ReverseMap();
            CreateMap<ShopResponse, CreateShopRequest>().ReverseMap();
            CreateMap<ShopResponse, UpdateShopRequest>().ReverseMap();
            CreateMap<ShopResponse, ShopFilter>().ReverseMap();
            #endregion

            #region Tag
            CreateMap<Tag, TagResponse>().ReverseMap();
            CreateMap<Tag, CreateTagRequest>().ReverseMap();
            CreateMap<Tag, UpdateTagRequest>().ReverseMap();
            CreateMap<TagResponse, CreateTagRequest>().ReverseMap();
            CreateMap<TagResponse, UpdateTagRequest>().ReverseMap();
            CreateMap<TagResponse, TagFilter>().ReverseMap();
            #endregion

            #region Transaction
            CreateMap<Transaction, TransactionResponse>().ReverseMap();
            CreateMap<Transaction, CreateTransactionRequest>().ReverseMap();
            CreateMap<Transaction, UpdateTransactionRequest>().ReverseMap();
            CreateMap<TransactionResponse, CreateTransactionRequest>().ReverseMap();
            CreateMap<TransactionResponse, UpdateTransactionRequest>().ReverseMap();
            CreateMap<TransactionResponse, TransactionFilter>().ReverseMap();
            #endregion

            #region User
            CreateMap<User, UserResponse>().ReverseMap();
            CreateMap<User, CreateUserRequest>().ReverseMap();
            CreateMap<User, UpdateUserRequest>().ReverseMap();
            CreateMap<UserResponse, CreateUserRequest>().ReverseMap();
            CreateMap<UserResponse, UpdateUserRequest>().ReverseMap();
            CreateMap<UserResponse, UserFilter>().ReverseMap();
            #endregion

            #region Wallet
            CreateMap<Wallet, WalletResponse>().ReverseMap();
            CreateMap<Wallet, CreateWalletRequest>().ReverseMap();
            CreateMap<Wallet, UpdateWalletRequest>().ReverseMap();
            CreateMap<WalletResponse, CreateWalletRequest>().ReverseMap();
            CreateMap<WalletResponse, UpdateWalletRequest>().ReverseMap();
            CreateMap<WalletResponse, WalletFilter>().ReverseMap();
            #endregion
        }
    }
}
