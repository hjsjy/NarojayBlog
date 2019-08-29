﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NarojayBlog.DatabaseRepository.DbContext;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace NarojayBlog.DatabaseRepository.Migrations
{
    [DbContext(typeof(NarojayContext))]
    [Migration("20190828054050_20190828")]
    partial class _20190828
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("NarojayBlog.DatabaseRepository.Model.Article", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Author");

                    b.Property<string>("CatalogId");

                    b.Property<int>("CommentAmount");

                    b.Property<string>("Content");

                    b.Property<DateTime>("CreateTime");

                    b.Property<int>("PraiseAmount");

                    b.Property<int>("ReadingAmount");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("CatalogId");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("NarojayBlog.DatabaseRepository.Model.Catalog", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Catalogs");
                });

            modelBuilder.Entity("NarojayBlog.DatabaseRepository.Model.Comment", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ArticleId");

                    b.Property<string>("Content");

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("NarojayBlog.DatabaseRepository.Model.GuestBook", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("GuestBooks");
                });

            modelBuilder.Entity("NarojayBlog.DatabaseRepository.Model.Article", b =>
                {
                    b.HasOne("NarojayBlog.DatabaseRepository.Model.Catalog", "Catalog")
                        .WithMany("Articles")
                        .HasForeignKey("CatalogId");
                });
#pragma warning restore 612, 618
        }
    }
}