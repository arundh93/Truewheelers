using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using Truewheelers.Models;

namespace Truewheelers.Migrations
{
    [DbContext(typeof(TruewheelersDbContext))]
    partial class TruewheelersDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Truewheelers.Models.Bicycles", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Brand");

                    b.Property<string>("Colour");

                    b.Property<string>("Model");

                    b.Property<double>("Price");

                    b.Property<int>("Size");

                    b.HasKey("ID");
                });
        }
    }
}
