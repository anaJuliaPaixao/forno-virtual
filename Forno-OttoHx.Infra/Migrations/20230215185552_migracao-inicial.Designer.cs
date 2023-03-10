// <auto-generated />
using System;
using Forno_OttoHx.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace Forno_OttoHx.Infra.Migrations
{
    [DbContext(typeof(OracleDbContext))]
    [Migration("20230215185552_migracao-inicial")]
    partial class migracaoinicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Forno_OttoHx.Dominio.Modelos.Forno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("HoraInicio")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<int>("Potencia")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("SegundosAquecimento")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("Id");

                    b.ToTable("Forno");
                });
#pragma warning restore 612, 618
        }
    }
}
