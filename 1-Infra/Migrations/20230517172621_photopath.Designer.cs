﻿// <auto-generated />
using System;
using Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infra.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230517172621_photopath")]
    partial class photopath
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entity.Address", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("MoreDetails")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Municipe")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PetId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Province")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("StreetName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("PetId")
                        .IsUnique();

                    b.ToTable("Address");
                });

            modelBuilder.Entity("Domain.Entity.Pet", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<DateTime>("AdoptionDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("Age")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Fullname")
                        .HasColumnType("text");

                    b.Property<string>("PhotoPath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("WasAdopted")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("PetsReported");
                });

            modelBuilder.Entity("Domain.Entity.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Fullname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Domain.Entity.Address", b =>
                {
                    b.HasOne("Domain.Entity.Pet", null)
                        .WithOne("Address")
                        .HasForeignKey("Domain.Entity.Address", "PetId")
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

            modelBuilder.Entity("Domain.Entity.Pet", b =>
                {
                    b.Navigation("Address")
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entity.User", b =>
                {
                    b.Navigation("PetsReported");
                });
#pragma warning restore 612, 618
        }
    }
}
