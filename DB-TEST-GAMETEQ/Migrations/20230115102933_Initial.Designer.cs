// <auto-generated />
using System;
using DB_TEST_GAMETEQ;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CONSOLE_TEST_GAMETEQ.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20230115102933_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.13");

            modelBuilder.Entity("CONSOLE_TEST_GAMETEQ.Entity.Rate", b =>
                {
                    b.Property<string>("Currency")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Currency", "Date");

                    b.ToTable("Rates");
                });
#pragma warning restore 612, 618
        }
    }
}
