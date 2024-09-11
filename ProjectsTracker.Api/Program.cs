using Microsoft.EntityFrameworkCore;
using ProjectsTracker.Api.Middlewares;
using ProjectsTracker.Application.Services;
using ProjectsTracker.Domain.Repositories;
using ProjectsTracker.Domain.Stores;
using ProjectsTracker.Persistence;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

//Database context
services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("ProjectsTrackerDb")));

//AutoMapper
services.AddAutoMapper(typeof(Program));

//Services
services.AddScoped<IProjectService, ProjectService>();
services.AddScoped<IEmployeeService, EmployeeService>();
services.AddScoped<IProblemService, ProblemService>();
//Repositores
services.AddScoped<IProjectRepository, ProjectRepository>();
services.AddScoped<IEmployeeRepository, EmployeeRepository>();
services.AddScoped<IProblemRepository, ProblemRepository>();

var app = builder.Build();
app.UseMiddleware<ExceptionHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
