using Microsoft.EntityFrameworkCore;
using Company.Data.Entities;

namespace Company.Data.Contexts;

public class CompanyContext : DbContext
{
    public DbSet<Companies> Company => Set<Companies>();
    public DbSet<Departments> Department => Set<Departments>();
    public DbSet<Employees> Employee => Set<Employees>();
    public DbSet<EmployeesJobTitles> EmployeeJobTitle => Set<EmployeesJobTitles>();
    public DbSet<JobTitles> JobTitle => Set<JobTitles>();

    public CompanyContext(DbContextOptions<CompanyContext> options) : base(options)
	{

	}
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<EmployeesJobTitles>().HasKey(ejt => new { ejt.EmployeeId, ejt.JobTitleId});
    }

}
