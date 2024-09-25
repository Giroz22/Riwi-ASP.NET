using FluentValidation;
using Microsoft.EntityFrameworkCore;
using RiwiStore.Data;
using RiwiStore.DTO;
using RiwiStore.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// DbContext
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<BaseContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Add services
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IUserService, UserService>();

// Fluent validation
builder.Services.AddMvc();
builder.Services.AddScoped<IValidator<ProductRequest>, ProductValidator>();
builder.Services.AddScoped<IValidator<UserRequest>, UserValidator>();

// Mapper
builder.Services.AddAutoMapper(typeof(Program));

// Add services to controllers
builder.Services.AddControllers()
    .AddJsonOptions(options =>
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles  //avoid reference cycles
    );

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//4.Controllers
// Mapea los controladores de API
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
