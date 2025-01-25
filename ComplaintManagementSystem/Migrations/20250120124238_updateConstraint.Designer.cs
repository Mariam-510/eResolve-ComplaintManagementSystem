﻿// <auto-generated />
using System;
using ComplaintManagementSystem.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ComplaintManagementSystem.Migrations
{
    [DbContext(typeof(ComplaintSystemContext))]
    [Migration("20250120124238_updateConstraint")]
    partial class updateConstraint
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ComplaintManagementSystem.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Accounts", t =>
                        {
                            t.HasCheckConstraint("CK_Account_Role", "[Role] IN ('Citizen', 'Admin', 'Employee')");
                        });

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2025, 1, 20, 9, 50, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            PasswordHash = "dnaqr7AnyCW9mrq3iyNAcOcCdS9iW3UuVeVbSOYH41g=",
                            Role = "Admin",
                            Username = "Admin1"
                        });
                });

            modelBuilder.Entity("ComplaintManagementSystem.Models.Citizen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId")
                        .IsUnique();

                    b.ToTable("Citizens", t =>
                        {
                            t.HasCheckConstraint("CK_Citizen_PhoneNumber_Length", "LEN([PhoneNumber]) BETWEEN 11 AND 15");
                        });
                });

            modelBuilder.Entity("ComplaintManagementSystem.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsDeleted = false,
                            Name = "Alexandria"
                        },
                        new
                        {
                            Id = 2,
                            IsDeleted = false,
                            Name = "Aswan"
                        },
                        new
                        {
                            Id = 3,
                            IsDeleted = false,
                            Name = "Asyut"
                        },
                        new
                        {
                            Id = 4,
                            IsDeleted = false,
                            Name = "Beheira"
                        },
                        new
                        {
                            Id = 5,
                            IsDeleted = false,
                            Name = "Beni Suef"
                        },
                        new
                        {
                            Id = 6,
                            IsDeleted = false,
                            Name = "Cairo"
                        },
                        new
                        {
                            Id = 7,
                            IsDeleted = false,
                            Name = "Dakahlia"
                        },
                        new
                        {
                            Id = 8,
                            IsDeleted = false,
                            Name = "Damietta"
                        },
                        new
                        {
                            Id = 9,
                            IsDeleted = false,
                            Name = "Faiyum"
                        },
                        new
                        {
                            Id = 10,
                            IsDeleted = false,
                            Name = "Gharbia"
                        },
                        new
                        {
                            Id = 11,
                            IsDeleted = false,
                            Name = "Giza"
                        },
                        new
                        {
                            Id = 12,
                            IsDeleted = false,
                            Name = "Ismailia"
                        },
                        new
                        {
                            Id = 13,
                            IsDeleted = false,
                            Name = "Kafr El-Sheikh"
                        },
                        new
                        {
                            Id = 14,
                            IsDeleted = false,
                            Name = "Luxor"
                        },
                        new
                        {
                            Id = 15,
                            IsDeleted = false,
                            Name = "Marsa Matruh"
                        },
                        new
                        {
                            Id = 16,
                            IsDeleted = false,
                            Name = "Minya"
                        },
                        new
                        {
                            Id = 17,
                            IsDeleted = false,
                            Name = "Monufia"
                        },
                        new
                        {
                            Id = 18,
                            IsDeleted = false,
                            Name = "New Valley"
                        },
                        new
                        {
                            Id = 19,
                            IsDeleted = false,
                            Name = "North Sinai"
                        },
                        new
                        {
                            Id = 20,
                            IsDeleted = false,
                            Name = "Port Said"
                        },
                        new
                        {
                            Id = 21,
                            IsDeleted = false,
                            Name = "Qalyubia"
                        },
                        new
                        {
                            Id = 22,
                            IsDeleted = false,
                            Name = "Qena"
                        },
                        new
                        {
                            Id = 23,
                            IsDeleted = false,
                            Name = "Red Sea"
                        },
                        new
                        {
                            Id = 24,
                            IsDeleted = false,
                            Name = "Sharqia"
                        },
                        new
                        {
                            Id = 25,
                            IsDeleted = false,
                            Name = "Sohag"
                        },
                        new
                        {
                            Id = 26,
                            IsDeleted = false,
                            Name = "South Sinai"
                        },
                        new
                        {
                            Id = 27,
                            IsDeleted = false,
                            Name = "Suez"
                        });
                });

            modelBuilder.Entity("ComplaintManagementSystem.Models.Complaint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("AssignedEmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("CitizenId")
                        .HasColumnType("int");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<DateTime?>("ResolutionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("SubmissionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("AssignedEmployeeId");

                    b.HasIndex("CitizenId");

                    b.HasIndex("CityId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Complaints", t =>
                        {
                            t.HasCheckConstraint("CK_Complaint_PhoneNumber_Length", "LEN([PhoneNumber]) BETWEEN 11 AND 15");

                            t.HasCheckConstraint("CK_Complaint_Status", "[Status] IN ('Pending', 'In Progress', 'Resolved')");
                        });
                });

            modelBuilder.Entity("ComplaintManagementSystem.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsDeleted = false,
                            Name = "Water"
                        },
                        new
                        {
                            Id = 2,
                            IsDeleted = false,
                            Name = "Electricity"
                        },
                        new
                        {
                            Id = 3,
                            IsDeleted = false,
                            Name = "Road"
                        },
                        new
                        {
                            Id = 4,
                            IsDeleted = false,
                            Name = "Sanitation"
                        },
                        new
                        {
                            Id = 5,
                            IsDeleted = false,
                            Name = "Telecommunication"
                        },
                        new
                        {
                            Id = 6,
                            IsDeleted = false,
                            Name = "Transport"
                        });
                });

            modelBuilder.Entity("ComplaintManagementSystem.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId")
                        .IsUnique();

                    b.HasIndex("CityId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Employees", t =>
                        {
                            t.HasCheckConstraint("CK_Employee_DateOfBirth", "DATEDIFF(YEAR, [DateOfBirth], GETDATE()) BETWEEN 18 AND 60");

                            t.HasCheckConstraint("CK_Employee_PhoneNumber_Length", "LEN([PhoneNumber]) BETWEEN 11 AND 15");

                            t.HasCheckConstraint("CK_Employee_Salary", "[Salary] > 0");
                        });

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccountId = 1,
                            CityId = 6,
                            DateOfBirth = new DateTime(2002, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            Name = "Mariam Ashraf",
                            PhoneNumber = "01144456820",
                            Salary = 10000.00m
                        });
                });

            modelBuilder.Entity("ComplaintManagementSystem.Models.Citizen", b =>
                {
                    b.HasOne("ComplaintManagementSystem.Models.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("ComplaintManagementSystem.Models.Complaint", b =>
                {
                    b.HasOne("ComplaintManagementSystem.Models.Employee", "AssignedEmployee")
                        .WithMany("Complaints")
                        .HasForeignKey("AssignedEmployeeId");

                    b.HasOne("ComplaintManagementSystem.Models.Citizen", "Citizen")
                        .WithMany("Complaints")
                        .HasForeignKey("CitizenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ComplaintManagementSystem.Models.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ComplaintManagementSystem.Models.Department", "Department")
                        .WithMany("Complaints")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AssignedEmployee");

                    b.Navigation("Citizen");

                    b.Navigation("City");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("ComplaintManagementSystem.Models.Employee", b =>
                {
                    b.HasOne("ComplaintManagementSystem.Models.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ComplaintManagementSystem.Models.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ComplaintManagementSystem.Models.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId");

                    b.Navigation("Account");

                    b.Navigation("City");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("ComplaintManagementSystem.Models.Citizen", b =>
                {
                    b.Navigation("Complaints");
                });

            modelBuilder.Entity("ComplaintManagementSystem.Models.Department", b =>
                {
                    b.Navigation("Complaints");

                    b.Navigation("Employees");
                });

            modelBuilder.Entity("ComplaintManagementSystem.Models.Employee", b =>
                {
                    b.Navigation("Complaints");
                });
#pragma warning restore 612, 618
        }
    }
}
