﻿// <auto-generated />
using FakeApplication.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FakeApplication.Repository.Migrations
{
    [DbContext(typeof(FakeLocationContext))]
    partial class FakeLocationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FakeApplication.Repository.Entities.AnchorRE", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("X")
                        .HasColumnType("float");

                    b.Property<double>("Y")
                        .HasColumnType("float");

                    b.Property<double>("Z")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Anchors");

                    b.HasData(
                        new
                        {
                            Id = 512,
                            X = 8.5356280000000009,
                            Y = 27.0,
                            Z = 60.120510000000003
                        },
                        new
                        {
                            Id = 513,
                            X = 8.5356280000000009,
                            Y = 27.0,
                            Z = 7.2367290000000004
                        },
                        new
                        {
                            Id = 514,
                            X = 34.884740000000001,
                            Y = 27.0,
                            Z = 95.933040000000005
                        },
                        new
                        {
                            Id = 515,
                            X = 99.458629999999999,
                            Y = 27.0,
                            Z = 89.252989999999997
                        },
                        new
                        {
                            Id = 516,
                            X = 144.92009999999999,
                            Y = 27.0,
                            Z = 66.058340000000001
                        },
                        new
                        {
                            Id = 517,
                            X = 160.32140000000001,
                            Y = 27.0,
                            Z = 8.9067430000000005
                        },
                        new
                        {
                            Id = 518,
                            X = 96.860830000000007,
                            Y = 27.0,
                            Z = 7.7934000000000001
                        },
                        new
                        {
                            Id = 519,
                            X = 55.852699999999999,
                            Y = 27.0,
                            Z = 8.9067430000000005
                        });
                });

            modelBuilder.Entity("FakeApplication.Repository.Entities.TagRE", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("SignalFrequency")
                        .HasColumnType("int");

                    b.Property<double>("X")
                        .HasColumnType("float");

                    b.Property<double>("Y")
                        .HasColumnType("float");

                    b.Property<double>("Z")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Tags");

                    b.HasData(
                        new
                        {
                            Id = 42,
                            IsActive = false,
                            SignalFrequency = 0,
                            X = 53.0,
                            Y = 199.0,
                            Z = 82.0
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
