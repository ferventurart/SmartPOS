﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SmartPOS.Products.Infrastructure;

#nullable disable

namespace SmartPOS.Products.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SmartPOS.Products.Domain.Categories.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("uuid")
                        .HasColumnName("department_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("character varying(60)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_categories");

                    b.HasIndex("DepartmentId")
                        .HasDatabaseName("ix_categories_department_id");

                    b.ToTable("categories", (string)null);
                });

            modelBuilder.Entity("SmartPOS.Products.Domain.Departments.Department", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("character varying(60)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_departments");

                    b.ToTable("departments", (string)null);
                });

            modelBuilder.Entity("SmartPOS.Products.Domain.Products.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Barcode")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)")
                        .HasColumnName("barcode");

                    b.Property<bool>("BulkSale")
                        .HasColumnType("boolean")
                        .HasColumnName("bulk_sale");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid")
                        .HasColumnName("category_id");

                    b.Property<string>("Description")
                        .HasMaxLength(300)
                        .HasColumnType("character varying(300)")
                        .HasColumnName("description");

                    b.Property<bool>("Favorite")
                        .HasColumnType("boolean")
                        .HasColumnName("favorite");

                    b.Property<bool>("InventoryControl")
                        .HasColumnType("boolean")
                        .HasColumnName("inventory_control");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("character varying(75)")
                        .HasColumnName("name");

                    b.Property<bool>("ShowInPos")
                        .HasColumnType("boolean")
                        .HasColumnName("show_in_pos");

                    b.Property<string>("Sku")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("sku");

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.Property<int>("UnitOfMeasure")
                        .HasColumnType("integer")
                        .HasColumnName("unit_of_measure");

                    b.HasKey("Id")
                        .HasName("pk_products");

                    b.HasIndex("CategoryId")
                        .HasDatabaseName("ix_products_category_id");

                    b.HasIndex("Sku")
                        .HasDatabaseName("ix_products_sku");

                    b.ToTable("products", (string)null);
                });

            modelBuilder.Entity("SmartPOS.Products.Domain.Products.ProductTax", b =>
                {
                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid")
                        .HasColumnName("product_id");

                    b.Property<Guid>("TaxId")
                        .HasColumnType("uuid")
                        .HasColumnName("tax_id");

                    b.HasKey("ProductId", "TaxId")
                        .HasName("pk_product_tax");

                    b.HasIndex("TaxId")
                        .HasDatabaseName("ix_product_tax_tax_id");

                    b.ToTable("product_tax", (string)null);
                });

            modelBuilder.Entity("SmartPOS.Products.Domain.Taxes.Tax", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<bool>("AddAutomatically")
                        .HasColumnType("boolean")
                        .HasColumnName("add_automatically");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("name");

                    b.Property<decimal>("Percentage")
                        .HasColumnType("numeric")
                        .HasColumnName("percentage");

                    b.HasKey("Id")
                        .HasName("pk_taxes");

                    b.ToTable("taxes", (string)null);
                });

            modelBuilder.Entity("SmartPOS.Products.Infrastructure.Outbox.OutboxMessage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("json")
                        .HasColumnName("content");

                    b.Property<string>("Error")
                        .HasColumnType("text")
                        .HasColumnName("error");

                    b.Property<DateTime>("OccurredOnUtc")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("occurred_on_utc");

                    b.Property<DateTime?>("ProcessedOnUtc")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("processed_on_utc");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("type");

                    b.HasKey("Id")
                        .HasName("pk_outbox_messages");

                    b.ToTable("outbox_messages", (string)null);
                });

            modelBuilder.Entity("SmartPOS.Products.Domain.Categories.Category", b =>
                {
                    b.HasOne("SmartPOS.Products.Domain.Departments.Department", null)
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_categories_department_department_temp_id");
                });

            modelBuilder.Entity("SmartPOS.Products.Domain.Products.Product", b =>
                {
                    b.HasOne("SmartPOS.Products.Domain.Categories.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_products_categories_category_id1");

                    b.OwnsOne("SmartPOS.Products.Domain.Shared.Money", "Cost", b1 =>
                        {
                            b1.Property<Guid>("ProductId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<decimal>("Amount")
                                .HasColumnType("numeric")
                                .HasColumnName("cost_amount");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("cost_currency");

                            b1.HasKey("ProductId");

                            b1.ToTable("products");

                            b1.WithOwner()
                                .HasForeignKey("ProductId")
                                .HasConstraintName("fk_products_products_id");
                        });

                    b.OwnsOne("SmartPOS.Products.Domain.Shared.Money", "CostWithTaxes", b1 =>
                        {
                            b1.Property<Guid>("ProductId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<decimal>("Amount")
                                .HasColumnType("numeric")
                                .HasColumnName("cost_with_taxes_amount");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("cost_with_taxes_currency");

                            b1.HasKey("ProductId");

                            b1.ToTable("products");

                            b1.WithOwner()
                                .HasForeignKey("ProductId")
                                .HasConstraintName("fk_products_products_id");
                        });

                    b.Navigation("Cost")
                        .IsRequired();

                    b.Navigation("CostWithTaxes")
                        .IsRequired();
                });

            modelBuilder.Entity("SmartPOS.Products.Domain.Products.ProductTax", b =>
                {
                    b.HasOne("SmartPOS.Products.Domain.Products.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_product_tax_products_product_id");

                    b.HasOne("SmartPOS.Products.Domain.Taxes.Tax", null)
                        .WithMany()
                        .HasForeignKey("TaxId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_product_tax_tax_tax_id");
                });
#pragma warning restore 612, 618
        }
    }
}
