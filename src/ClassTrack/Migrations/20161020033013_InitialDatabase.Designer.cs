using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ClassTrack.Models;

namespace ClassTrack.Migrations
{
    [DbContext(typeof(ClassTrackContext))]
    [Migration("20161020033013_InitialDatabase")]
    partial class InitialDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ClassTrack.Models.CurriculumSheet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Major");

                    b.Property<int>("MinUnitsReq");

                    b.Property<string>("Subplan");

                    b.Property<DateTime>("Year");

                    b.HasKey("Id");

                    b.ToTable("CurriculumSheets");
                });

            modelBuilder.Entity("ClassTrack.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<int?>("ModuleId");

                    b.HasKey("Id");

                    b.HasIndex("ModuleId");

                    b.ToTable("Item");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Item");
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

            modelBuilder.Entity("ClassTrack.Models.CourseItem", b =>
                {
                    b.HasBaseType("ClassTrack.Models.Item");

                    b.Property<short>("HighlightColor");

                    b.Property<string>("Number");

                    b.Property<string>("Title");

                    b.Property<int>("Units");

                    b.ToTable("CourseItem");

                    b.HasDiscriminator().HasValue("CourseItem");
                });

            modelBuilder.Entity("ClassTrack.Models.InfoItem", b =>
                {
                    b.HasBaseType("ClassTrack.Models.Item");

                    b.Property<string>("Text");

                    b.ToTable("InfoItem");

                    b.HasDiscriminator().HasValue("InfoItem");
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
        }
    }
}
