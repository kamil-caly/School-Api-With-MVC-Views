using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using SchoolTask;
using SchoolTask.Entities;
using SchoolTask.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SchoolDbContext>(option => 

    option.UseSqlServer(builder.Configuration
        .GetConnectionString("MyConnection"))
);
builder.Services.AddScoped<SchoolSeeder>();
builder.Services.AddScoped<ISchoolService, SchoolService>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddScoped<IStudetnService, StudentService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(policy =>
    policy.WithOrigins("http://localhost:7014", "https://localhost:7112")
    .AllowAnyMethod()
    .WithHeaders(HeaderNames.ContentType)
);

using var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<SchoolSeeder>();
seeder.Seed();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
