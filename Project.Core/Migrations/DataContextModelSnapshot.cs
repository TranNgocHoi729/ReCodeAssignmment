// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Project.Core.Context;

namespace Project.Core.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Project.Core.Entities.Account", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailOptIn")
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("MobileNumber")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Email");

                    b.HasIndex("MobileNumber")
                        .IsUnique();

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            Email = "CMC1@gmail.com",
                            DOB = new DateTime(2021, 9, 23, 22, 4, 38, 586, DateTimeKind.Local).AddTicks(6110),
                            Gender = 1,
                            MobileNumber = "0909090909",
                            Name = "NgokHoi",
                            Password = "f8cgamafgO7tEl6Y67qRrOK4JytFm3XIYxaHHhPwc74=|WkOOdSuKNVpzFOG9A3eGnA=="
                        },
                        new
                        {
                            Email = "CMC2@gmail.com",
                            DOB = new DateTime(2021, 9, 23, 22, 4, 38, 587, DateTimeKind.Local).AddTicks(9313),
                            Gender = 1,
                            MobileNumber = "0909090999",
                            Name = "NgokHoi1234",
                            Password = "f8cgamafgO7tEl6Y67qRrOK4JytFm3XIYxaHHhPwc74=|WkOOdSuKNVpzFOG9A3eGnA=="
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
