using ProjectsTracker.Application.Services;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

// Add services to the container.

services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

//Контекст БД!!!!!


//AutoMapper
services.AddAutoMapper(typeof(Program));

//Сервисы
services.AddScoped<IProjectService, ProjectService>();
services.AddScoped<IEmployeeService, EmployeeService>();
services.AddScoped<IProblemService, ProblemService>();

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
