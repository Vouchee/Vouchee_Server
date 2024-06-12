using Vouchee.API.AppStarts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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
