// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using hydrants.Models;

#nullable disable

namespace hydrants.net_2022.Migrations
{
    [DbContext(typeof(SiteDbContext))]
    [Migration("20220428154600_fc")]
    partial class fc
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("hydrants.Models.FetchCache", b =>
                {
                    b.Property<uint>("FetchCacheId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int unsigned");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime(6)");

                    b.HasKey("FetchCacheId");

                    b.ToTable("FetchRecords");
                });
#pragma warning restore 612, 618
        }
    }
}
