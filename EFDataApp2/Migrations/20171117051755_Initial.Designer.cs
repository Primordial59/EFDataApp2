﻿// <auto-generated />
using EFDataApp2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace EFDataApp2.Migrations
{
    [DbContext(typeof(MobileContext))]
    [Migration("20171117051755_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFDataApp2.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<bool>("Dispatched");

                    b.Property<string>("EMail");

                    b.Property<string>("Family");

                    b.Property<bool>("GiftWrap");

                    b.Property<string>("Index");

                    b.Property<string>("Name");

                    b.Property<string>("SecondName");

                    b.HasKey("OrderId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("EFDataApp2.Models.OrderLine", b =>
                {
                    b.Property<int>("OrderLineId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("OrderId");

                    b.Property<int?>("ProductId");

                    b.Property<int>("Quantity");

                    b.HasKey("OrderLineId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderLines");
                });

            modelBuilder.Entity("EFDataApp2.Models.Phone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Company");

                    b.Property<string>("Name");

                    b.Property<int>("Price");

                    b.HasKey("Id");

                    b.ToTable("Phones");
                });

            modelBuilder.Entity("EFDataApp2.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Album");

                    b.Property<string>("Artist");

                    b.Property<string>("Booklet");

                    b.Property<string>("Category");

                    b.Property<string>("Country");

                    b.Property<string>("Cover");

                    b.Property<string>("Label");

                    b.Property<string>("Licensing");

                    b.Property<string>("Number");

                    b.Property<string>("Picture");

                    b.Property<decimal>("Price");

                    b.Property<int>("Quantity");

                    b.Property<string>("Style");

                    b.Property<string>("Tracks");

                    b.Property<decimal>("Year");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("EFDataApp2.Models.OrderLine", b =>
                {
                    b.HasOne("EFDataApp2.Models.Order", "Order")
                        .WithMany("OrderLines")
                        .HasForeignKey("OrderId");

                    b.HasOne("EFDataApp2.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");
                });
#pragma warning restore 612, 618
        }
    }
}
