﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectsTracker.Persistence;

#nullable disable

namespace ProjectsTracker.Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240906045323_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EmployeeProject", b =>
                {
                    b.Property<int>("EmployeesEmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("ProjectsProjectId")
                        .HasColumnType("int");

                    b.HasKey("EmployeesEmployeeId", "ProjectsProjectId");

                    b.HasIndex("ProjectsProjectId");

                    b.ToTable("EmployeeProject");
                });

            modelBuilder.Entity("ProjectsTracker.Domain.Models.Company", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CompanyId"));

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CompanyId");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("ProjectsTracker.Domain.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeId");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("ProjectsTracker.Domain.Models.Problem", b =>
                {
                    b.Property<int>("ProblemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProblemId"));

                    b.Property<int?>("AssigneeEmployeeId")
                        .HasColumnType("int");

                    b.Property<int?>("AuthorEmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<string>("ProblemName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("ProblemId");

                    b.HasIndex("AssigneeEmployeeId");

                    b.HasIndex("AuthorEmployeeId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Problems");
                });

            modelBuilder.Entity("ProjectsTracker.Domain.Models.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProjectId"));

                    b.Property<int?>("CustomerCompanyCompanyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ExecutorCompanyCompanyId")
                        .HasColumnType("int");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<int?>("ProjectManagerEmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("ProjectName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ProjectId");

                    b.HasIndex("CustomerCompanyCompanyId");

                    b.HasIndex("ExecutorCompanyCompanyId");

                    b.HasIndex("ProjectManagerEmployeeId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("EmployeeProject", b =>
                {
                    b.HasOne("ProjectsTracker.Domain.Models.Employee", null)
                        .WithMany()
                        .HasForeignKey("EmployeesEmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectsTracker.Domain.Models.Project", null)
                        .WithMany()
                        .HasForeignKey("ProjectsProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProjectsTracker.Domain.Models.Problem", b =>
                {
                    b.HasOne("ProjectsTracker.Domain.Models.Employee", "Assignee")
                        .WithMany()
                        .HasForeignKey("AssigneeEmployeeId");

                    b.HasOne("ProjectsTracker.Domain.Models.Employee", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorEmployeeId");

                    b.HasOne("ProjectsTracker.Domain.Models.Project", null)
                        .WithMany("Problems")
                        .HasForeignKey("ProjectId");

                    b.Navigation("Assignee");

                    b.Navigation("Author");
                });

            modelBuilder.Entity("ProjectsTracker.Domain.Models.Project", b =>
                {
                    b.HasOne("ProjectsTracker.Domain.Models.Company", "CustomerCompany")
                        .WithMany()
                        .HasForeignKey("CustomerCompanyCompanyId");

                    b.HasOne("ProjectsTracker.Domain.Models.Company", "ExecutorCompany")
                        .WithMany()
                        .HasForeignKey("ExecutorCompanyCompanyId");

                    b.HasOne("ProjectsTracker.Domain.Models.Employee", "ProjectManager")
                        .WithMany()
                        .HasForeignKey("ProjectManagerEmployeeId");

                    b.Navigation("CustomerCompany");

                    b.Navigation("ExecutorCompany");

                    b.Navigation("ProjectManager");
                });

            modelBuilder.Entity("ProjectsTracker.Domain.Models.Project", b =>
                {
                    b.Navigation("Problems");
                });
#pragma warning restore 612, 618
        }
    }
}
