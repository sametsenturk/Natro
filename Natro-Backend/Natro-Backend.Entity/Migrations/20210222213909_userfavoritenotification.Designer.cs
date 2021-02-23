﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Natro_Backend.Entity.Context;

namespace Natro_Backend.Entity.Migrations
{
    [DbContext(typeof(MssqlContext))]
    [Migration("20210222213909_userfavoritenotification")]
    partial class userfavoritenotification
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Natro_Backend.Entity.Entities.UserEntity", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Natro_Backend.Entity.Entities.UserFavoriteEntity", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Domain")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime>("ExpireDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsAvailableToBuy")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastChange")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nameserver1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nameserver2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("UserFavorites");
                });

            modelBuilder.Entity("Natro_Backend.Entity.Entities.UserFavoriteNotificationEntity", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("UserFavoriteID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("UserFavoriteID");

                    b.ToTable("UserFavoriteNotifications");
                });

            modelBuilder.Entity("Natro_Backend.Entity.Entities.UserFavoriteEntity", b =>
                {
                    b.HasOne("Natro_Backend.Entity.Entities.UserEntity", "User")
                        .WithMany("Favorites")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Natro_Backend.Entity.Entities.UserFavoriteNotificationEntity", b =>
                {
                    b.HasOne("Natro_Backend.Entity.Entities.UserFavoriteEntity", "UserFavorite")
                        .WithMany("UserFavoriteNotifications")
                        .HasForeignKey("UserFavoriteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserFavorite");
                });

            modelBuilder.Entity("Natro_Backend.Entity.Entities.UserEntity", b =>
                {
                    b.Navigation("Favorites");
                });

            modelBuilder.Entity("Natro_Backend.Entity.Entities.UserFavoriteEntity", b =>
                {
                    b.Navigation("UserFavoriteNotifications");
                });
#pragma warning restore 612, 618
        }
    }
}
