﻿// <auto-generated />
using akademia_web_dev.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using System;

namespace akademia_web_dev.Migrations
{
    [DbContext(typeof(LinkDBContext))]
    [Migration("20180403204535_Create Link table")]
    partial class CreateLinktable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011");

            modelBuilder.Entity("akademia_web_dev.Models.HyperLinkModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Hash");

                    b.Property<string>("Link");

                    b.HasKey("Id");

                    b.ToTable("link");
                });
#pragma warning restore 612, 618
        }
    }
}
