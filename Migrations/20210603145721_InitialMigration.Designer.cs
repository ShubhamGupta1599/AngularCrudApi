﻿// <auto-generated />
using AngularCrud.BDO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AngularCrud.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210603145721_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AngularCrud.BDO.City", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CityName")
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("StateId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("StateId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("AngularCrud.BDO.Country", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CountryName")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("AngularCrud.BDO.Registration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(50)");

                    b.Property<long>("PhoneNumber")
                        .HasColumnType("bigint");

                    b.Property<int>("PinCode")
                        .HasColumnType("int");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Registration");
                });

            modelBuilder.Entity("AngularCrud.BDO.Roles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("AngularCrud.BDO.State", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("StateName")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("id");

                    b.HasIndex("CountryId");

                    b.ToTable("States");
                });

            modelBuilder.Entity("AngularCrud.BDO.UserRoles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("AngularCrud.BDO.City", b =>
                {
                    b.HasOne("AngularCrud.BDO.State", "State")
                        .WithMany("Cities")
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("State");
                });

            modelBuilder.Entity("AngularCrud.BDO.State", b =>
                {
                    b.HasOne("AngularCrud.BDO.Country", "Country")
                        .WithMany("States")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("AngularCrud.BDO.Country", b =>
                {
                    b.Navigation("States");
                });

            modelBuilder.Entity("AngularCrud.BDO.State", b =>
                {
                    b.Navigation("Cities");
                });
#pragma warning restore 612, 618
        }
    }
}
