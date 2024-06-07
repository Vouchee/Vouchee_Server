using AutoMapper;
using Vouchee.Domain.Entities;
using Vouchee.Infrastructure.FilterModels;
using Vouchee.Infrastructure.RequestModels.Category;
using Vouchee.Infrastructure.WebResponse;

namespace Vouchee.AppStarts
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
		}
	}
}
