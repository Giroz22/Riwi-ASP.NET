using FluentValidation;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using RWFormsApi.API.DTOs.Request;
using RWFormsApi.API.Validations;
using RWFormsApi.Infrastructure.Abstract;
using RWFormsApi.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<MongoDbSettings>(
    builder.Configuration.GetSection("MongoDbSettings"));

builder.Services.AddSingleton<IMongoClient>(sp=>
    {
        var settings = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
        return new MongoClient(settings.ConnectionString);
    }
);

builder.Services.AddScoped(sp=>
    {
        var client = sp.GetRequiredService<IMongoClient>();
        var settings = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
        return client.GetDatabase(settings.DatabaseName);
    }
);

//My Services
builder.Services.AddScoped<IUserService, UserService>();

//My controllers
builder.Services.AddControllers();

// Mapper
builder.Services.AddAutoMapper(typeof(Program));

// Fluent validation
builder.Services.AddMvc();
builder.Services.AddScoped<IValidator<UserRequest>, UserValidator>();

// Middleware
builder.Services.AddTransient<IExceptionHandler, IdNotFoundExceptionHandler>();
builder.Services.AddTransient<IExceptionHandler, ValidationExceptionHandler>();

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

//Middleware
app.UseMiddleware<ExceptionMiddleware>();

//Controllers
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
