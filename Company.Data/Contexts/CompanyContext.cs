using Microsoft.EntityFrameworkCore;
using Company.Data.Entities;

namespace Company.Data.Contexts;

public class CompanyContext : DbContext, Microsoft.EntityFrameworkCore.Design.IDesignTimeDbContextFactory<CompanyContext>
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
        //SeedData(builder);
    }

    private void SeedData(ModelBuilder builder)
    {
        var Company = new List<Companies>
        {
            new Companies
            {
                Id= 1,
                Name="Pendant publishing",
                Organisationsnummer="550 6600"
            },
            new Companies
            {
                Id= 2,
                Name="Weyland-Yutani",
                Organisationsnummer="551 6622"
            }

        };
        builder.Entity<Companies>().HasData(Company);
        var Department = new List<Departments>
        {
            new Departments
            {
                Id= 1,
                DepartmentName="Shipbuilding",
                CompanyId=2
            },
            new Departments
            {
                Id= 2,
                DepartmentName="Editorial Department",
                CompanyId=1
            }
        };
        builder.Entity<Departments>().HasData(Department);
        var Employee = new List<Employees>
        {
            new Employees
            {
                Id= 1,
                FirstName="Ellen",
                LastName="Ripley",
                Unionized=false,
                Salary=1000,
                DepartmentId=1
            },
            new Employees
            {
                Id= 2,
                FirstName="Elaine",
                LastName="Benes",
                Unionized=false,
                Salary=10000,
                DepartmentId=2
            },
            new Employees
            {
                Id=3,
                FirstName="Dwayne",
                LastName="Hicks",
                Unionized=true,
                Salary=100,
                DepartmentId=1
            }

    };
        builder.Entity<Employees>().HasData(Employee);
        var JobTitle = new List<JobTitles>
        {
            new JobTitles
            {
                Id= 1,
                Title="Corporal",
            },
            new JobTitles
            {
                Id= 2,
                Title="Warrant officer"
            },
            new JobTitles
            {
                Id= 3,
                Title="Crewmember"
            },
            new JobTitles
            {
                Id=4,
                Title="Copy Editor"
            }
        };
        builder.Entity<JobTitles>().HasData(JobTitle);
        var EmployeeJobTitle = new List<EmployeesJobTitles>
        {
            new EmployeesJobTitles
            {
                JobTitleId= 1,
                EmployeeId= 3,
            },
            new EmployeesJobTitles 
            {
                JobTitleId= 3,
                EmployeeId= 3,
            },
            new EmployeesJobTitles
            {
                JobTitleId= 2,
                EmployeeId= 1,
            },
            new EmployeesJobTitles
            {
                JobTitleId= 3,
                EmployeeId= 1,
            },
            new EmployeesJobTitles
            {
                JobTitleId= 4,
                EmployeeId= 2,
            },
        };
        builder.Entity<EmployeesJobTitles>().HasData(EmployeeJobTitle);
    }

    public CompanyContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<CompanyContext>();
        optionsBuilder.UseSqlServer("Data Source=CompanyDb");

        return new CompanyContext(optionsBuilder.Options);
    }
}
