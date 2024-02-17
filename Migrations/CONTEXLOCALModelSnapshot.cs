﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication8.Model;

#nullable disable

namespace WebApplication8.Migrations
{
    [DbContext(typeof(CONTEXLOCAL))]
    partial class CONTEXLOCALModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WebApplication8.Model.Datorer", b =>
                {
                    b.Property<int>("DatorId")
                        .HasColumnType("int")
                        .HasColumnName("Dator_ID");

                    b.Property<string>("Modell")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Märke")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<decimal?>("PrisPerDag")
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("Serienummer")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<bool?>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Typ")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("DatorId")
                        .HasName("PK__Datorer__C18FF85F2CAC74CE");

                    b.ToTable("Datorer");
                });

            modelBuilder.Entity("WebApplication8.Model.DatorHyrning", b =>
                {
                    b.Property<int>("DatorHyrningId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Dator_Hyrning_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DatorHyrningId"), 1L, 1);

                    b.Property<string>("Anteckning")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("anteckning");

                    b.Property<int>("DatorId")
                        .HasColumnType("int")
                        .HasColumnName("Dator_ID");

                    b.Property<int>("HyrningsId")
                        .HasColumnType("int")
                        .HasColumnName("Hyrnings_ID");

                    b.HasKey("DatorHyrningId");

                    b.ToTable("Dator_Hyrning");
                });

            modelBuilder.Entity("WebApplication8.Model.Hyrning", b =>
                {
                    b.Property<int>("HyrningsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Hyrnings_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HyrningsId"), 1L, 1);

                    b.Property<int?>("KundId")
                        .HasColumnType("int")
                        .HasColumnName("Kund_ID");

                    b.Property<bool?>("Paminelse")
                        .HasColumnType("bit");

                    b.Property<decimal?>("Pris")
                        .HasColumnType("decimal(10,2)");

                    b.Property<DateTime?>("Slutdatum")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("Startdatum")
                        .HasColumnType("datetime");

                    b.HasKey("HyrningsId")
                        .HasName("PK__Hyrning__47E4174B2EAFED4F");

                    b.ToTable("Hyrning");
                });

            modelBuilder.Entity("WebApplication8.Model.Kunder", b =>
                {
                    b.Property<int>("KundId")
                        .HasColumnType("int")
                        .HasColumnName("Kund_ID");

                    b.Property<string>("Adress")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Epost")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("FöretagsNamn")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Företags_Namn");

                    b.Property<string>("Lösenord")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Telefonnummer")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("KundId")
                        .HasName("PK__Kunder__7C0AD0F5EA6BAF3F");

                    b.ToTable("Kunder");
                });
#pragma warning restore 612, 618
        }
    }
}
