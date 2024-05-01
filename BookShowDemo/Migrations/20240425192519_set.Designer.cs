﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SaveUrShowUsingCFA.models;

#nullable disable

namespace SaveUrShowUsingCFA.Migrations
{
    [DbContext(typeof(SaveUrShowUsingCFADbContext))]
    [Migration("20240425192519_set")]
    partial class set
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.29")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SaveUrShowUsingCFA.models.BookTicket", b =>
                {
                    b.Property<long>("Bookid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Bookid"), 1L, 1);

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("MovieId")
                        .HasColumnType("int");

                    b.Property<int?>("Seatnum")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Bookid");

                    b.HasIndex("MovieId");

                    b.HasIndex("UserId");

                    b.ToTable("BookTicket");
                });

            modelBuilder.Entity("SaveUrShowUsingCFA.models.FindTicket", b =>
                {
                    b.Property<int>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MovieId"), 1L, 1);

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MovieLink")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Moviename")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Slot")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Theatrename")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("charges")
                        .HasColumnType("int");

                    b.Property<DateTime?>("date")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.HasKey("MovieId");

                    b.ToTable("FindTicket");
                });

            modelBuilder.Entity("SaveUrShowUsingCFA.models.Registration", b =>
                {
                    b.Property<int>("userid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("userid"), 1L, 1);

                    b.Property<string>("confirmpassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("usertype")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("userid");

                    b.ToTable("Registration");
                });

            modelBuilder.Entity("SaveUrShowUsingCFA.models.BookTicket", b =>
                {
                    b.HasOne("SaveUrShowUsingCFA.models.FindTicket", "Movie")
                        .WithMany()
                        .HasForeignKey("MovieId");

                    b.HasOne("SaveUrShowUsingCFA.models.Registration", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Movie");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
