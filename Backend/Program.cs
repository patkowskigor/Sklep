using Backend.Data;
using Backend.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();    
builder.Services.AddSwaggerGen();               

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")
        ?? throw new InvalidOperationException("Database connection string 'DbConnection' is not found"));
});

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "SerwisApp API V1");
        });
    }

    app.UseSwagger();        
    app.UseSwaggerUI();     
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
