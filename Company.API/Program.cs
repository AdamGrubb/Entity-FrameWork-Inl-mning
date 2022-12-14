using Company.Common.DTOs;
using Company.Data.Entities;
using Company.Data.Services;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<CompanyContext>(options =>options.UseSqlServer(builder.Configuration.GetConnectionString("CompanyConnection")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
ConfigureAutomapper(builder.Services);
RegisterServices(builder.Services);


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

void ConfigureAutomapper(IServiceCollection services)
{
    var config = new MapperConfiguration(cfg =>
    {
        cfg.CreateMap<Companies, CompaniesDTO>().ReverseMap();
        cfg.CreateMap<Departments, DepartmentsDTO>().ReverseMap();
        cfg.CreateMap<Employees, EmployeesDTO>().ReverseMap();
        cfg.CreateMap<JobTitles, JobTitlesDTO>().ReverseMap();
        cfg.CreateMap<EmployeesJobTitles, EmployeesJobTitlesDTO>().ReverseMap();
    });
    var mapper = config.CreateMapper();
    services.AddSingleton(mapper);
}
void RegisterServices (IServiceCollection services)
{
    services.AddScoped<IDbService, DbService>();
}