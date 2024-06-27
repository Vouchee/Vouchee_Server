using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Vouchee.API.AppStarts;
using Vouchee.Data.Helpers;
using Vouchee.Data.Models.Entities;
using Vouchee.Data.Seed;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddIdentity<User, Role>(options =>
    {
        options.Password.RequireDigit = true;
        options.Password.RequireLowercase = true;
        options.Password.RequiredLength = 6;
        options.Password.RequireNonAlphanumeric = true;
        options.Password.RequireUppercase = true;
    })
    .AddEntityFrameworkStores<VoucheeContext>()
    .AddDefaultTokenProviders();    
    
builder.Services.AddAuthentication(options =>   
{
    options.DefaultAuthenticateScheme = 
        options.DefaultChallengeScheme = 
            options.DefaultForbidScheme = 
                options.DefaultScheme = 
                    options.DefaultSignInScheme = 
                        options.DefaultSignOutScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        RequireExpirationTime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(
            System.Text.Encoding.UTF8.GetBytes(builder.Configuration["JWT:SigningKey"]!))
    };
});

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(MapperConfig).Assembly);
builder.Services.ConfigDI();
#region Cors
builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowAnyOrigins", options =>
        options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});
#endregion
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors();

app.MapControllers();
using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
try
{
    var context = services.GetRequiredService<VoucheeContext>();
    var userManager = services.GetRequiredService<UserManager<User>>();
    /*var walletManager = services.GetRequiredService<UserManager<Wallet>>();*/
    await context.Database.MigrateAsync();
    await Seed.SeedCategory(context);
    await Seed.SeedUser(context,userManager);
    await Seed.SeedShop(context,userManager);
    await Seed.SeedWallet(context,userManager);
    
    // await Seed.SeedComment(context);
    // await Seed.SeedDiscount(context);
    // await Seed.SeedImage(context);
    // await Seed.SeedNotify(context);
    await Seed.SeedProduct(context);
    // await Seed.SeedPromotion(context);
    // await Seed.SeedRating(context);
    
}
catch (Exception ex)
{
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error while seeding data");
}
app.Run();