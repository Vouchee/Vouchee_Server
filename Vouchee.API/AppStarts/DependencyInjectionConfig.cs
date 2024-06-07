using Microsoft.AspNetCore.Cors.Infrastructure;
using Vouchee.Infrastructure.Services.Interface;
using Vouchee.Infrastructure.Services;
using Vouchee.Infrastructure.DataAccessObjects.Interfaces;
using Vouchee.Infrastructure.DataAccessObjects.Impls;
using Vouchee.Infrastructure.Repositories.Interface;
using Vouchee.Infrastructure.Repositories.Impls;
using Vouchee.Infrastructure.DataContext;

namespace Vouchee.AppStarts
{
	public static class DependencyInjectionConfig
	{
		public static void ConfigDI(this IServiceCollection services)
		{
			#region DAO
			services.AddScoped(typeof(IBaseDAO<>), typeof(BaseDAO<>));
			services.AddScoped<ICategoryDAO, CategoryDAO>();
			#endregion

			#region Repository
			services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
			services.AddScoped<ICategoryRepository, CategoryRepository>();
			#endregion

			#region Service
			services.AddScoped<ICategoryService, CategoryService>();
			#endregion

			services.AddSingleton<VoucheeContext>();
		}
	}
}
