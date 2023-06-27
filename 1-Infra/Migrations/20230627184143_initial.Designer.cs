﻿// <auto-generated />
using System;
using Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infra.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230627184143_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Domain.Entity.Address", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("MoreDetails")
                        .HasColumnType("longtext");

                    b.Property<string>("Municipe")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PetId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Province")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("StreetName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("PetId")
                        .IsUnique();

                    b.ToTable("Address");
                });

            modelBuilder.Entity("Domain.Entity.Application", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("ApplicationState")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("PetId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("PetId");

                    b.HasIndex("UserId");

                    b.ToTable("Application");
                });

            modelBuilder.Entity("Domain.Entity.Form", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<bool>("Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Form");
                });

            modelBuilder.Entity("Domain.Entity.Pet", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime?>("AdoptionDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Fullname")
                        .HasColumnType("longtext");

                    b.Property<string>("PhotoPath")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<bool>("WasAdopted")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("PetsReported");
                });

            modelBuilder.Entity("Domain.Entity.Question", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("FormId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Priority")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("TypeQuestion")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FormId");

                    b.ToTable("Question");
                });

            modelBuilder.Entity("Domain.Entity.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Fullname")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Domain.Entity.UserResponse", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ApplicationId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Response")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationId");

                    b.ToTable("UserResponse");
                });

            modelBuilder.Entity("Domain.Entity.Address", b =>
                {
                    b.HasOne("Domain.Entity.Pet", null)
                        .WithOne("Address")
                        .HasForeignKey("Domain.Entity.Address", "PetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entity.Application", b =>
                {
                    b.HasOne("Domain.Entity.Pet", null)
                        .WithMany("Application")
                        .HasForeignKey("PetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entity.User", null)
                        .WithMany("UserResponse")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entity.Pet", b =>
                {
                    b.HasOne("Domain.Entity.User", null)
                        .WithMany("PetsReported")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entity.Question", b =>
                {
                    b.HasOne("Domain.Entity.Form", null)
                        .WithMany("Question")
                        .HasForeignKey("FormId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entity.UserResponse", b =>
                {
                    b.HasOne("Domain.Entity.Application", null)
                        .WithMany("UserResponse")
                        .HasForeignKey("ApplicationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entity.Application", b =>
                {
                    b.Navigation("UserResponse");
                });

            modelBuilder.Entity("Domain.Entity.Form", b =>
                {
                    b.Navigation("Question");
                });

            modelBuilder.Entity("Domain.Entity.Pet", b =>
                {
                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("Application");
                });

            modelBuilder.Entity("Domain.Entity.User", b =>
                {
                    b.Navigation("PetsReported");

                    b.Navigation("UserResponse");
                });
#pragma warning restore 612, 618
        }
    }
}