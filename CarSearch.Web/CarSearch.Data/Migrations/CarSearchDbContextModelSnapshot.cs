﻿namespace CarSearch.Data.Migrations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Infrastructure;
    using Microsoft.EntityFrameworkCore.Metadata;

    [DbContext(typeof(CarSearchDbContext))]
    partial class CarSearchDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CarSearch.Data.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000);

                    b.Property<string>("Importer")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<string>("Make")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.Property<int>("Power");

                    b.Property<int>("Year");

                    b.HasKey("Id");

                    b.ToTable("Cars");
                });
#pragma warning restore 612, 618
        }
    }
}
