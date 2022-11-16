﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20221116173443_EditTable2")]
    partial class EditTable2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Aggregates.Leads.Lead", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal?>("AnnualRevenue")
                        .HasPrecision(2)
                        .HasColumnType("decimal(2,2)");

                    b.Property<string>("City")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Company")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Country")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<long>("CreatedAt")
                        .HasColumnType("bigint");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("IndustryId")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LeadSourceId")
                        .HasColumnType("int");

                    b.Property<int?>("LeadStatusId")
                        .HasColumnType("int");

                    b.Property<string>("Mobile")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<long>("ModifiedAt")
                        .HasColumnType("bigint");

                    b.Property<Guid>("ModifiedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("NumberOfEmployees")
                        .HasColumnType("int");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Phone")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PostalCode")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("RatingId")
                        .HasColumnType("int");

                    b.Property<string>("State")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Street")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Website")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("IndustryId");

                    b.HasIndex("LeadSourceId");

                    b.HasIndex("LeadStatusId");

                    b.HasIndex("RatingId");

                    b.ToTable("Leads");
                });

            modelBuilder.Entity("Domain.Aggregates.Leads.ValueObjects.Industry", b =>
                {
                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Value");

                    b.ToTable("Industries", (string)null);

                    b.HasData(
                        new
                        {
                            Value = 0,
                            Name = "--None--"
                        },
                        new
                        {
                            Value = 31,
                            Name = "Agriculture"
                        },
                        new
                        {
                            Value = 1,
                            Name = "Apparel"
                        },
                        new
                        {
                            Value = 2,
                            Name = "Banking"
                        },
                        new
                        {
                            Value = 3,
                            Name = "Biotechnology"
                        },
                        new
                        {
                            Value = 4,
                            Name = "Chemicals"
                        },
                        new
                        {
                            Value = 5,
                            Name = "Communications"
                        },
                        new
                        {
                            Value = 6,
                            Name = "Construction"
                        },
                        new
                        {
                            Value = 7,
                            Name = "Consulting"
                        },
                        new
                        {
                            Value = 8,
                            Name = "Education"
                        },
                        new
                        {
                            Value = 9,
                            Name = "Electronics"
                        },
                        new
                        {
                            Value = 10,
                            Name = "Energy"
                        },
                        new
                        {
                            Value = 11,
                            Name = "Engineering"
                        },
                        new
                        {
                            Value = 12,
                            Name = "Entertainment"
                        },
                        new
                        {
                            Value = 13,
                            Name = "Environmental"
                        },
                        new
                        {
                            Value = 14,
                            Name = "Finance"
                        },
                        new
                        {
                            Value = 15,
                            Name = "Government"
                        },
                        new
                        {
                            Value = 16,
                            Name = "Healthcare"
                        },
                        new
                        {
                            Value = 17,
                            Name = "Hospitality"
                        },
                        new
                        {
                            Value = 18,
                            Name = "Insurance"
                        },
                        new
                        {
                            Value = 19,
                            Name = "Machinery"
                        },
                        new
                        {
                            Value = 29,
                            Name = "Manufacturing"
                        },
                        new
                        {
                            Value = 20,
                            Name = "Media"
                        },
                        new
                        {
                            Value = 21,
                            Name = "Not For Profit"
                        },
                        new
                        {
                            Value = 22,
                            Name = "Retail"
                        },
                        new
                        {
                            Value = 23,
                            Name = "Shipping"
                        },
                        new
                        {
                            Value = 24,
                            Name = "Technology"
                        },
                        new
                        {
                            Value = 25,
                            Name = "Telecommunications"
                        },
                        new
                        {
                            Value = 26,
                            Name = "Transportation"
                        },
                        new
                        {
                            Value = 27,
                            Name = "Utilities"
                        },
                        new
                        {
                            Value = 28,
                            Name = "Recreation"
                        },
                        new
                        {
                            Value = 30,
                            Name = "Other"
                        });
                });

            modelBuilder.Entity("Domain.Aggregates.Leads.ValueObjects.LeadSource", b =>
                {
                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Value");

                    b.ToTable("LeadSources", (string)null);

                    b.HasData(
                        new
                        {
                            Value = 0,
                            Name = "--None--"
                        },
                        new
                        {
                            Value = 2,
                            Name = "External Referral"
                        },
                        new
                        {
                            Value = 1,
                            Name = "Advertisement"
                        },
                        new
                        {
                            Value = 7,
                            Name = "Word of mouth"
                        },
                        new
                        {
                            Value = 3,
                            Name = "In-Store"
                        },
                        new
                        {
                            Value = 4,
                            Name = "On Site"
                        },
                        new
                        {
                            Value = 5,
                            Name = "Social"
                        },
                        new
                        {
                            Value = 6,
                            Name = "Web"
                        });
                });

            modelBuilder.Entity("Domain.Aggregates.Leads.ValueObjects.LeadStatus", b =>
                {
                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Value");

                    b.ToTable("LeadStatuses", (string)null);

                    b.HasData(
                        new
                        {
                            Value = 0,
                            Name = "New"
                        },
                        new
                        {
                            Value = 2,
                            Name = "Working"
                        },
                        new
                        {
                            Value = 1,
                            Name = "Contacted"
                        },
                        new
                        {
                            Value = 3,
                            Name = "Qualified"
                        },
                        new
                        {
                            Value = 4,
                            Name = "Unqualified"
                        });
                });

            modelBuilder.Entity("Domain.Aggregates.Leads.ValueObjects.Rating", b =>
                {
                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Value");

                    b.ToTable("Rating", (string)null);

                    b.HasData(
                        new
                        {
                            Value = 0,
                            Name = "Cold"
                        },
                        new
                        {
                            Value = 1,
                            Name = "Warm"
                        },
                        new
                        {
                            Value = 2,
                            Name = "Hot"
                        });
                });

            modelBuilder.Entity("Domain.SharedKernel.Salutation", b =>
                {
                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Value");

                    b.ToTable("Salutations", (string)null);

                    b.HasData(
                        new
                        {
                            Value = 0,
                            Name = "--None--"
                        },
                        new
                        {
                            Value = 1,
                            Name = "Mr."
                        },
                        new
                        {
                            Value = 2,
                            Name = "Ms."
                        },
                        new
                        {
                            Value = 3,
                            Name = "Dr."
                        },
                        new
                        {
                            Value = 4,
                            Name = "Prof."
                        });
                });

            modelBuilder.Entity("Domain.Aggregates.Leads.Lead", b =>
                {
                    b.HasOne("Domain.Aggregates.Leads.ValueObjects.Industry", "Industry")
                        .WithMany()
                        .HasForeignKey("IndustryId");

                    b.HasOne("Domain.Aggregates.Leads.ValueObjects.LeadSource", "LeadSource")
                        .WithMany()
                        .HasForeignKey("LeadSourceId");

                    b.HasOne("Domain.Aggregates.Leads.ValueObjects.LeadStatus", "LeadStatus")
                        .WithMany()
                        .HasForeignKey("LeadStatusId");

                    b.HasOne("Domain.Aggregates.Leads.ValueObjects.Rating", "Rating")
                        .WithMany()
                        .HasForeignKey("RatingId");

                    b.OwnsOne("Domain.SharedKernel.FullName", "FullName", b1 =>
                        {
                            b1.Property<Guid>("LeadId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("SalutationId")
                                .HasColumnType("int")
                                .HasColumnName("SalutationId");

                            b1.HasKey("LeadId");

                            b1.HasIndex("SalutationId");

                            b1.ToTable("Leads");

                            b1.WithOwner()
                                .HasForeignKey("LeadId");

                            b1.HasOne("Domain.SharedKernel.Salutation", "Salutation")
                                .WithMany()
                                .HasForeignKey("SalutationId");

                            b1.Navigation("Salutation");
                        });

                    b.Navigation("FullName")
                        .IsRequired();

                    b.Navigation("Industry");

                    b.Navigation("LeadSource");

                    b.Navigation("LeadStatus");

                    b.Navigation("Rating");
                });
#pragma warning restore 612, 618
        }
    }
}
