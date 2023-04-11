
using Microsoft.EntityFrameworkCore;
using TestCorp.Domain.Data;
using TestCorp.Domain.Models;
using TestCorp.Repository;
using TestCorp.Services;
using TestCorp.Services.Interfaces;
using TestCorp.WebAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddTransient(typeof(EmployeeRepository));
builder.Services.AddTransient(typeof(CompanyRepository));
builder.Services.AddTransient<ICompanyService, CompanyService>();
builder.Services.AddTransient<IEmployeeService, EmployeeService>();
builder.Services.AddTransient<IValidationService, ValidationService>();
builder.Services.AddTransient<ILog, Logger>();
builder.Services.AddEntityFrameworkNpgsql().AddDbContext<Test4CreateDbContext>(opt =>
        opt.UseNpgsql(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddSingleton(MappingConfig.RegisterMaps().CreateMapper());
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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
