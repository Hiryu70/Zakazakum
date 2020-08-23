﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Zakazakum.EntityFramework;

namespace Zakazakum.EntityFramework.Migrations
{
    [DbContext(typeof(ZakazakumContext))]
    partial class ZakazakumContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7");

            modelBuilder.Entity("Zakazakum.Domain.Entities.Food", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<float>("Cost")
                        .HasColumnType("REAL");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("RestaurantId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Food");
                });

            modelBuilder.Entity("Zakazakum.Domain.Entities.FoodOrder", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Comment")
                        .HasColumnType("TEXT");

                    b.Property<int>("Count")
                        .HasColumnType("INTEGER");

                    b.Property<Guid?>("FoodId")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("UserOrderId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("FoodId");

                    b.HasIndex("UserOrderId");

                    b.ToTable("FoodOrder");
                });

            modelBuilder.Entity("Zakazakum.Domain.Entities.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<float>("DeliveryCost")
                        .HasColumnType("REAL");

                    b.Property<Guid?>("RestaurantId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Zakazakum.Domain.Entities.Restaurant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Restaurants");
                });

            modelBuilder.Entity("Zakazakum.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Zakazakum.Domain.Entities.UserOrder", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsOrderPaid")
                        .HasColumnType("INTEGER");

                    b.Property<Guid?>("OrderId")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("UserId");

                    b.ToTable("UserOrders");
                });

            modelBuilder.Entity("Zakazakum.Domain.Entities.Food", b =>
                {
                    b.HasOne("Zakazakum.Domain.Entities.Restaurant", null)
                        .WithMany("Foods")
                        .HasForeignKey("RestaurantId");
                });

            modelBuilder.Entity("Zakazakum.Domain.Entities.FoodOrder", b =>
                {
                    b.HasOne("Zakazakum.Domain.Entities.Food", "Food")
                        .WithMany()
                        .HasForeignKey("FoodId");

                    b.HasOne("Zakazakum.Domain.Entities.UserOrder", null)
                        .WithMany("FoodOrders")
                        .HasForeignKey("UserOrderId");
                });

            modelBuilder.Entity("Zakazakum.Domain.Entities.Order", b =>
                {
                    b.HasOne("Zakazakum.Domain.Entities.Restaurant", "Restaurant")
                        .WithMany()
                        .HasForeignKey("RestaurantId");
                });

            modelBuilder.Entity("Zakazakum.Domain.Entities.UserOrder", b =>
                {
                    b.HasOne("Zakazakum.Domain.Entities.Order", null)
                        .WithMany("UserOrders")
                        .HasForeignKey("OrderId");

                    b.HasOne("Zakazakum.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
