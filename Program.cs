
using Microsoft.EntityFrameworkCore;
using student_management_api.Models.Data;
using student_management_api.Repository.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//! Registering personal services
builder.Services.MyPersonalApplicationServices();

//! Register controllers
builder.Services.AddControllers();

// builder.Services.AddOpenApi();
//! Registering our dbContext class
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    // app.MapOpenApi();
}

app.UseHttpsRedirection();

//! This is needed for Swagger to work with our created controllers
app.MapControllers();

app.Run();

