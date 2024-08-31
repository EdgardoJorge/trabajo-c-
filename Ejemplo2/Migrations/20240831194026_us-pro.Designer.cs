﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ejemploData.DataBase;

#nullable disable

namespace Ejemplo2.Migrations
{
    [DbContext(typeof(MiDbContext))]
    [Migration("20240831194026_us-pro")]
    partial class uspro
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.33")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ejemploData.DataBase.Tables.Categoria", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("id");

                    b.ToTable("categorias");

                    b.HasData(
                        new
                        {
                            id = 1,
                            nombre = "Frutas"
                        },
                        new
                        {
                            id = 2,
                            nombre = "Verduras"
                        },
                        new
                        {
                            id = 3,
                            nombre = "Carnes"
                        },
                        new
                        {
                            id = 4,
                            nombre = "Menestras"
                        },
                        new
                        {
                            id = 5,
                            nombre = "Bebidas"
                        });
                });

            modelBuilder.Entity("ejemploData.DataBase.Tables.Persona", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("apellidos")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("fecha_nacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("nombre_document")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("telefono")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("tipo_documento")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("id");

                    b.ToTable("personas");
                });

            modelBuilder.Entity("ejemploData.DataBase.Tables.Producto", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("categoria_id")
                        .HasColumnType("int");

                    b.Property<string>("codigoBarras")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasMaxLength(260)
                        .HasColumnType("nvarchar(260)");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("precio")
                        .HasPrecision(6, 2)
                        .HasColumnType("decimal(6,2)");

                    b.Property<int?>("stock")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("categoria_id");

                    b.ToTable("productos");

                    b.HasData(
                        new
                        {
                            id = 1,
                            categoria_id = 1,
                            descripcion = "Es una fresa",
                            nombre = "Fresa",
                            precio = 8.50m
                        });
                });

            modelBuilder.Entity("ejemploData.DataBase.Tables.Usuario", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<int>("persona_id")
                        .HasColumnType("int");

                    b.Property<string>("salt")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("id");

                    b.HasIndex("persona_id")
                        .IsUnique();

                    b.ToTable("usuarios");
                });

            modelBuilder.Entity("ejemploData.DataBase.Tables.Producto", b =>
                {
                    b.HasOne("ejemploData.DataBase.Tables.Categoria", null)
                        .WithMany()
                        .HasForeignKey("categoria_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ejemploData.DataBase.Tables.Usuario", b =>
                {
                    b.HasOne("ejemploData.DataBase.Tables.Persona", null)
                        .WithOne()
                        .HasForeignKey("ejemploData.DataBase.Tables.Usuario", "persona_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
