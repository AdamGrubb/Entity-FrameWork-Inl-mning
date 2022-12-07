using Microsoft.EntityFrameworkCore;
using Company.Data.Entities;

namespace Company.Data.Contexts;

public class CompanyContext : DbContext
{
	public CompanyContext(DbContextOptions<CompanyContext> options) : base(options)
	{

	}
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<EmployeeJobTitles>().HasKey(ejt => new { ejt.EmployeeId, ejt.JobTitleId});
    }

}
