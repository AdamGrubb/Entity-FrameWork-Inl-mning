﻿// <auto-generated />
using Company.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Company.Data.Migrations
{
    [DbContext(typeof(CompanyContext))]
    [Migration("20221217135019_FixedBugWithExtension")]
    partial class FixedBugWithExtension
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Company.Data.Entities.Companies", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Organisationsnummer")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.ToTable("Company");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Pendant publishing",
                            Organisationsnummer = "550 6600"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Weyland-Yutani",
                            Organisationsnummer = "551 6622"
                        });
                });

            modelBuilder.Entity("Company.Data.Entities.Departments", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Department");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CompanyId = 2,
                            DepartmentName = "Shipbuilding"
                        },
                        new
                        {
                            Id = 2,
                            CompanyId = 1,
                            DepartmentName = "Editorial Department"
                        });
                });

            modelBuilder.Entity("Company.Data.Entities.Employees", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Salary")
                        .HasColumnType("int");

                    b.Property<bool>("Unionized")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Employee");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DepartmentId = 1,
                            FirstName = "Ellen",
                            LastName = "Ripley",
                            Salary = 1000,
                            Unionized = false
                        },
                        new
                        {
                            Id = 2,
                            DepartmentId = 2,
                            FirstName = "Elaine",
                            LastName = "Benes",
                            Salary = 10000,
                            Unionized = false
                        },
                        new
                        {
                            Id = 3,
                            DepartmentId = 1,
                            FirstName = "Dwayne",
                            LastName = "Hicks",
                            Salary = 100,
                            Unionized = true
                        });
                });

            modelBuilder.Entity("Company.Data.Entities.EmployeesJobTitles", b =>
                {
                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("JobTitleId")
                        .HasColumnType("int");

                    b.HasKey("EmployeeId", "JobTitleId");

                    b.HasIndex("JobTitleId");

                    b.ToTable("EmployeeJobTitle");

                    b.HasData(
                        new
                        {
                            EmployeeId = 3,
                            JobTitleId = 1
                        },
                        new
                        {
                            EmployeeId = 3,
                            JobTitleId = 3
                        },
                        new
                        {
                            EmployeeId = 1,
                            JobTitleId = 2
                        },
                        new
                        {
                            EmployeeId = 1,
                            JobTitleId = 3
                        },
                        new
                        {
                            EmployeeId = 2,
                            JobTitleId = 4
                        });
                });

            modelBuilder.Entity("Company.Data.Entities.JobTitles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("JobTitle");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Title = "Corporal"
                        },
                        new
                        {
                            Id = 2,
                            Title = "Warrant officer"
                        },
                        new
                        {
                            Id = 3,
                            Title = "Crewmember"
                        },
                        new
                        {
                            Id = 4,
                            Title = "Copy Editor"
                        });
                });

            modelBuilder.Entity("EmployeesJobTitles", b =>
                {
                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("JobTitleId")
                        .HasColumnType("int");

                    b.HasKey("EmployeeId", "JobTitleId");

                    b.HasIndex("JobTitleId");

                    b.ToTable("EmployeesJobTitles");
                });

            modelBuilder.Entity("Company.Data.Entities.Departments", b =>
                {
                    b.HasOne("Company.Data.Entities.Companies", "Company")
                        .WithMany("Department")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Company.Data.Entities.Employees", b =>
                {
                    b.HasOne("Company.Data.Entities.Departments", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("Company.Data.Entities.EmployeesJobTitles", b =>
                {
                    b.HasOne("Company.Data.Entities.Employees", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Company.Data.Entities.JobTitles", "JobTitle")
                        .WithMany()
                        .HasForeignKey("JobTitleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("JobTitle");
                });

            modelBuilder.Entity("EmployeesJobTitles", b =>
                {
                    b.HasOne("Company.Data.Entities.Employees", null)
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Company.Data.Entities.JobTitles", null)
                        .WithMany()
                        .HasForeignKey("JobTitleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Company.Data.Entities.Companies", b =>
                {
                    b.Navigation("Department");
                });
#pragma warning restore 612, 618
        }
    }
}
