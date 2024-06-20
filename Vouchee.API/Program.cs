using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Vouchee.API.AppStarts;
using Vouchee.Data.Helpers;
using Vouchee.Data.Models.Entities;

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

app.Run();
