﻿// <auto-generated />
using System;
using MT.OnlineRestaurant.DataLayer.EntityFrameWorkModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MT.OnlineRestaurant.DataLayer.Migrations
{
    [DbContext(typeof(RestaurantManagementContext))]
    [Migration("20191213055519_Charan1234")]
    partial class Charan1234
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MT.OnlineRestaurant.DataLayer.EntityFrameWorkModel.LoggingInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ActionName")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("('')")
                        .HasMaxLength(250);

                    b.Property<string>("ControllerName")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("('')")
                        .HasMaxLength(250);

                    b.Property<string>("Description")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("('')");

                    b.Property<DateTime?>("RecordTimeStamp")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("('')");

                    b.HasKey("Id");

                    b.ToTable("LoggingInfo");
                });

            modelBuilder.Entity("MT.OnlineRestaurant.DataLayer.EntityFrameWorkModel.TblCuisine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cuisine")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("('')")
                        .HasMaxLength(225);

                    b.Property<DateTime>("RecordTimeStamp")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("((0))");

                    b.Property<DateTime>("RecordTimeStampCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("((0))");

                    b.Property<int>("UserCreated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((0))");

                    b.Property<int>("UserModified")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((0))");

                    b.HasKey("Id");

                    b.ToTable("tblCuisine");
                });

            modelBuilder.Entity("MT.OnlineRestaurant.DataLayer.EntityFrameWorkModel.TblLocation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("RecordTimeStamp")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("((0))");

                    b.Property<DateTime>("RecordTimeStampCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("((0))");

                    b.Property<int>("UserCreated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((0))");

                    b.Property<int>("UserModified")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((0))");

                    b.Property<decimal?>("X")
                        .HasColumnType("decimal(18, 0)");

                    b.Property<decimal?>("Y")
                        .HasColumnType("decimal(18, 0)");

                    b.HasKey("Id");

                    b.HasIndex("X")
                        .IsUnique()
                        .HasName("UQ__tblLocat__3BD0198414754610")
                        .HasFilter("[X] IS NOT NULL");

                    b.HasIndex("Y")
                        .IsUnique()
                        .HasName("UQ__tblLocat__3BD01987EC697B94")
                        .HasFilter("[Y] IS NOT NULL");

                    b.ToTable("tblLocation");
                });

            modelBuilder.Entity("MT.OnlineRestaurant.DataLayer.EntityFrameWorkModel.TblMenu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Item")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("('')")
                        .HasMaxLength(225);

                    b.Property<DateTime>("RecordTimeStamp")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("((0))");

                    b.Property<DateTime>("RecordTimeStampCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("((0))");

                    b.Property<int>("TblCuisineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("tblCuisineID")
                        .HasDefaultValueSql("((0))");

                    b.Property<int>("UserCreated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((0))");

                    b.Property<int>("UserModified")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((0))");

                    b.Property<int>("quantity")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Quantity")
                        .HasDefaultValueSql("((0))");

                    b.HasKey("Id");

                    b.HasIndex("TblCuisineId");

                    b.ToTable("tblMenu");
                });

            modelBuilder.Entity("MT.OnlineRestaurant.DataLayer.EntityFrameWorkModel.TblOffer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Discount")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((0))");

                    b.Property<DateTime>("FromDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("((0))");

                    b.Property<decimal>("Price")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal")
                        .HasDefaultValueSql("((0))");

                    b.Property<DateTime>("RecordTimeStamp")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("((0))");

                    b.Property<DateTime>("RecordTimeStampCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("((0))");

                    b.Property<int>("TblMenuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("tblMenuID")
                        .HasDefaultValueSql("((0))");

                    b.Property<int>("TblRestaurantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("tblRestaurantID")
                        .HasDefaultValueSql("((0))");

                    b.Property<DateTime>("ToDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("((0))");

                    b.Property<int>("UserCreated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((0))");

                    b.Property<int>("UserModified")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((0))");

                    b.HasKey("Id");

                    b.HasIndex("TblMenuId");

                    b.HasIndex("TblRestaurantId");

                    b.ToTable("tblOffer");
                });

            modelBuilder.Entity("MT.OnlineRestaurant.DataLayer.EntityFrameWorkModel.TblRating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comments")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("('')");

                    b.Property<string>("Rating")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("('')")
                        .HasMaxLength(10);

                    b.Property<DateTime>("RecordTimeStamp")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("((0))");

                    b.Property<DateTime>("RecordTimeStampCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("((0))");

                    b.Property<int>("TblCustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("tblCustomerId")
                        .HasDefaultValueSql("((0))");

                    b.Property<int>("TblRestaurantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("tblRestaurantID")
                        .HasDefaultValueSql("((0))");

                    b.Property<int>("UserCreated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((0))");

                    b.Property<int>("UserModified")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((0))");

                    b.HasKey("Id");

                    b.HasIndex("TblRestaurantId");

                    b.ToTable("tblRating");
                });

            modelBuilder.Entity("MT.OnlineRestaurant.DataLayer.EntityFrameWorkModel.TblRestaurant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsUnicode(false);

                    b.Property<string>("CloseTime")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("('')")
                        .HasMaxLength(5);

                    b.Property<string>("ContactNo")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("('')")
                        .HasMaxLength(20);

                    b.Property<string>("Name")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("('')")
                        .HasMaxLength(225);

                    b.Property<string>("OpeningTime")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("('')")
                        .HasMaxLength(5);

                    b.Property<DateTime>("RecordTimeStamp")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("((0))");

                    b.Property<DateTime>("RecordTimeStampCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("((0))");

                    b.Property<int>("TblLocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("tblLocationID")
                        .HasDefaultValueSql("((0))");

                    b.Property<int>("UserCreated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((0))");

                    b.Property<int>("UserModified")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((0))");

                    b.Property<string>("Website")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("('')")
                        .HasMaxLength(225);

                    b.HasKey("Id");

                    b.HasIndex("TblLocationId");

                    b.ToTable("tblRestaurant");
                });

            modelBuilder.Entity("MT.OnlineRestaurant.DataLayer.EntityFrameWorkModel.TblRestaurantDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<DateTime>("RecordTimeStamp")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("((0))");

                    b.Property<DateTime>("RecordTimeStampCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("((0))");

                    b.Property<int>("TableCapacity")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((0))");

                    b.Property<int>("TableCount")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((0))");

                    b.Property<int>("TblRestaurantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("tblRestaurantID")
                        .HasDefaultValueSql("((0))");

                    b.Property<int>("UserCreated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((0))");

                    b.Property<int>("UserModified")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((0))");

                    b.HasKey("Id");

                    b.HasIndex("TblRestaurantId");

                    b.ToTable("tblRestaurantDetails");
                });

            modelBuilder.Entity("MT.OnlineRestaurant.DataLayer.EntityFrameWorkModel.TblMenu", b =>
                {
                    b.HasOne("MT.OnlineRestaurant.DataLayer.EntityFrameWorkModel.TblCuisine", "TblCuisine")
                        .WithMany("TblMenu")
                        .HasForeignKey("TblCuisineId")
                        .HasConstraintName("FK_tblMenu_tblCuisineID");
                });

            modelBuilder.Entity("MT.OnlineRestaurant.DataLayer.EntityFrameWorkModel.TblOffer", b =>
                {
                    b.HasOne("MT.OnlineRestaurant.DataLayer.EntityFrameWorkModel.TblMenu", "TblMenu")
                        .WithMany("TblOffer")
                        .HasForeignKey("TblMenuId")
                        .HasConstraintName("FK_tblOffer_tblMenuID");

                    b.HasOne("MT.OnlineRestaurant.DataLayer.EntityFrameWorkModel.TblRestaurant", "TblRestaurant")
                        .WithMany("TblOffer")
                        .HasForeignKey("TblRestaurantId")
                        .HasConstraintName("FK_tblOffer_tblRestaurantID");
                });

            modelBuilder.Entity("MT.OnlineRestaurant.DataLayer.EntityFrameWorkModel.TblRating", b =>
                {
                    b.HasOne("MT.OnlineRestaurant.DataLayer.EntityFrameWorkModel.TblRestaurant", "TblRestaurant")
                        .WithMany("TblRating")
                        .HasForeignKey("TblRestaurantId")
                        .HasConstraintName("FK_tblRating_tblRestaurantID");
                });

            modelBuilder.Entity("MT.OnlineRestaurant.DataLayer.EntityFrameWorkModel.TblRestaurant", b =>
                {
                    b.HasOne("MT.OnlineRestaurant.DataLayer.EntityFrameWorkModel.TblLocation", "TblLocation")
                        .WithMany("TblRestaurant")
                        .HasForeignKey("TblLocationId")
                        .HasConstraintName("FK_tblRestaurant_tblLocationID");
                });

            modelBuilder.Entity("MT.OnlineRestaurant.DataLayer.EntityFrameWorkModel.TblRestaurantDetails", b =>
                {
                    b.HasOne("MT.OnlineRestaurant.DataLayer.EntityFrameWorkModel.TblRestaurant", "TblRestaurant")
                        .WithMany("TblRestaurantDetails")
                        .HasForeignKey("TblRestaurantId")
                        .HasConstraintName("FK_tblRestaurantDetails_tblRestaurantID");
                });
#pragma warning restore 612, 618
        }
    }
}
