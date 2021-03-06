﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ClassTrack.Models;

namespace ClassTrack.Migrations
{
    [DbContext(typeof(ClassTrackContext))]
    [Migration("20161129110634_ItemNumIdProperty")]
    partial class ItemNumIdProperty
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ClassTrack.Models.ClassTrackUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("Created");

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<DateTime>("Updated");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("ClassTrack.Models.CourseScheduleItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClassNumber");

                    b.Property<string>("Days");

                    b.Property<int>("EndTime");

                    b.Property<string>("Instructor");

                    b.Property<int?>("ItemId");

                    b.Property<string>("Number");

                    b.Property<string>("Room");

                    b.Property<int>("Section");

                    b.Property<int>("StartTime");

                    b.Property<string>("Time");

                    b.Property<string>("Title");

                    b.Property<int>("Units");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.ToTable("CourseScheduleItems");
                });

            modelBuilder.Entity("ClassTrack.Models.CPPMajor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("CPPMajor");
                });

            modelBuilder.Entity("ClassTrack.Models.CPPSubplan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CPPMajorId");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("CPPMajorId");

                    b.ToTable("CPPSubplan");
                });

            modelBuilder.Entity("ClassTrack.Models.CurriculumSheet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClassTrackUserId");

                    b.Property<bool>("IsActive");

                    b.Property<string>("Major");

                    b.Property<int>("MinUnitsReq");

                    b.Property<string>("Subplan");

                    b.Property<string>("UserName");

                    b.Property<int>("Year");

                    b.HasKey("Id");

                    b.HasIndex("ClassTrackUserId");

                    b.ToTable("CurriculumSheets");
                });

            modelBuilder.Entity("ClassTrack.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<short>("HighlightColor");

                    b.Property<bool>("IsCourse");

                    b.Property<int?>("ModuleId");

                    b.Property<int>("NumId");

                    b.Property<string>("Number");

                    b.Property<string>("Title");

                    b.Property<int>("Units");

                    b.HasKey("Id");

                    b.HasIndex("ModuleId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("ClassTrack.Models.Module", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CurriculumSheetId");

                    b.Property<string>("Description");

                    b.Property<bool>("IsSubmodule");

                    b.Property<string>("Title");

                    b.Property<int>("Units");

                    b.HasKey("Id");

                    b.HasIndex("CurriculumSheetId");

                    b.ToTable("Modules");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("ClassTrack.Models.CourseScheduleItem", b =>
                {
                    b.HasOne("ClassTrack.Models.Item")
                        .WithMany("CourseScheduleItems")
                        .HasForeignKey("ItemId");
                });

            modelBuilder.Entity("ClassTrack.Models.CPPSubplan", b =>
                {
                    b.HasOne("ClassTrack.Models.CPPMajor")
                        .WithMany("Subplans")
                        .HasForeignKey("CPPMajorId");
                });

            modelBuilder.Entity("ClassTrack.Models.CurriculumSheet", b =>
                {
                    b.HasOne("ClassTrack.Models.ClassTrackUser")
                        .WithMany("CurriculumSheets")
                        .HasForeignKey("ClassTrackUserId");
                });

            modelBuilder.Entity("ClassTrack.Models.Item", b =>
                {
                    b.HasOne("ClassTrack.Models.Module")
                        .WithMany("Items")
                        .HasForeignKey("ModuleId");
                });

            modelBuilder.Entity("ClassTrack.Models.Module", b =>
                {
                    b.HasOne("ClassTrack.Models.CurriculumSheet")
                        .WithMany("Modules")
                        .HasForeignKey("CurriculumSheetId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ClassTrack.Models.ClassTrackUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ClassTrack.Models.ClassTrackUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ClassTrack.Models.ClassTrackUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
