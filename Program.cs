using MigrationProject.Model;
using MigrationProject.Repository;
using Microsoft.EntityFrameworkCore;
using MigrationProject.Interface;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection")));
builder.Services.AddScoped<IManager, ManagerRepository>();
builder.Services.AddScoped<IEmployee,EmployeeRepository>();

builder.Services.AddLogging(loggingbuilder =>
{
    loggingbuilder.AddConsole();
    loggingbuilder.AddDebug();
});

builder.Services.AddControllers();
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

app.MapControllers();

app.Run();
