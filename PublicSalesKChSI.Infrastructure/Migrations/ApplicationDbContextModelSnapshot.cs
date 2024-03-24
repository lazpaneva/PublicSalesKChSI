﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PublicSalesKChSI.Infrastructure.Data;

#nullable disable

namespace PublicSalesKChSI.Infrastructure.Migrations
{
    [DbContext(typeof(PublicSalesDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.28")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("PublicSalesKChSI.Infrastructure.Data.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "dea12856-c198-4129-b3f3-b893d8395082",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "77fef554-8c65-41c2-8d7b-21dc055d15f5",
                            Email = "ja.iv@abv.bg",
                            EmailConfirmed = false,
                            FirstName = "Jana",
                            LastName = "Ivancheva",
                            LockoutEnabled = false,
                            NormalizedEmail = "JA.IV@ABV.BG",
                            NormalizedUserName = "JA.IV@ABV.BG",
                            PasswordHash = "AQAAAAEAACcQAAAAEK1upciXdk0VlT56NvkrYP6LJQ/sfLNiSgUY7Xaa1hQMaOoxpWfCcSrfhWn4rzRIyQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "22584785-cef2-45ea-84d7-538a45f748a8",
                            TwoFactorEnabled = false,
                            UserName = "ja.iv@abv.bg"
                        },
                        new
                        {
                            Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "f29ee724-077e-4f6e-9684-c16e09581e26",
                            Email = "ira1970@abv.bg",
                            EmailConfirmed = false,
                            FirstName = "Ira",
                            LastName = "Kotseva",
                            LockoutEnabled = false,
                            NormalizedEmail = "IRA1970@ABV.BG",
                            NormalizedUserName = "IRA1970@ABV.BG",
                            PasswordHash = "AQAAAAEAACcQAAAAEMZ6Aag1aQyKhkK3TlF0AEdBSrJV2qYUIvlbNyg+SkJADIdjt2n616CqFpn5eB9RGA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "7dd2c10b-62c2-44ad-96a5-a5bf85561054",
                            TwoFactorEnabled = false,
                            UserName = "ira1970@abv.bg"
                        });
                });

            modelBuilder.Entity("PublicSalesKChSI.Infrastructure.Data.Models.BrsFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("Dcng")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<int?>("DeptorOldID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Dpos")
                        .HasColumnType("datetime2")
                        .HasComment("to be fill when file is Ready again");

                    b.Property<string>("EmployeeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsFileExported")
                        .HasColumnType("bit");

                    b.Property<bool>("IsFileReady")
                        .HasColumnType("bit");

                    b.Property<bool>("IsFindDeptor")
                        .HasColumnType("bit");

                    b.Property<string>("Klas")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("Lica")
                        .HasMaxLength(2500)
                        .HasColumnType("nvarchar(2500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Scre")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Telf")
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("ntext");

                    b.Property<DateTime?>("Time")
                        .HasColumnType("datetime2")
                        .HasComment("to be fill when file is Ready again");

                    b.Property<string>("UrlPdf")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DeptorOldID");

                    b.HasIndex("EmployeeId");

                    b.ToTable("BrsFiles");
                });

            modelBuilder.Entity("PublicSalesKChSI.Infrastructure.Data.Models.Court", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("Town")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.ToTable("Courts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Number = "01",
                            Town = "БЛАГОЕВГРАД"
                        },
                        new
                        {
                            Id = 2,
                            Number = "35",
                            Town = "БУРГАС"
                        },
                        new
                        {
                            Id = 3,
                            Number = "02",
                            Town = "ВАРНА"
                        },
                        new
                        {
                            Id = 4,
                            Number = "03",
                            Town = "ВЕЛИКО ТЪРНОВО"
                        },
                        new
                        {
                            Id = 5,
                            Number = "04",
                            Town = "ВИДИН"
                        },
                        new
                        {
                            Id = 6,
                            Number = "05",
                            Town = "ВРАЦА"
                        },
                        new
                        {
                            Id = 7,
                            Number = "06",
                            Town = "ГАБРОВО"
                        },
                        new
                        {
                            Id = 8,
                            Number = "08",
                            Town = "ДОБРИЧ"
                        },
                        new
                        {
                            Id = 9,
                            Number = "09",
                            Town = "КЪРДЖАЛИ"
                        },
                        new
                        {
                            Id = 10,
                            Number = "10",
                            Town = "КЮСТЕНДИЛ"
                        },
                        new
                        {
                            Id = 11,
                            Number = "11",
                            Town = "ЛОВЕЧ"
                        },
                        new
                        {
                            Id = 12,
                            Number = "12",
                            Town = "МОНТАНА"
                        },
                        new
                        {
                            Id = 13,
                            Number = "13",
                            Town = "ПАЗАРДЖИК"
                        },
                        new
                        {
                            Id = 14,
                            Number = "14",
                            Town = "ПЕРНИК"
                        },
                        new
                        {
                            Id = 15,
                            Number = "15",
                            Town = "ПЛЕВЕН"
                        },
                        new
                        {
                            Id = 16,
                            Number = "16",
                            Town = "ПЛОВДИВ"
                        },
                        new
                        {
                            Id = 17,
                            Number = "17",
                            Town = "РАЗГРАД"
                        },
                        new
                        {
                            Id = 18,
                            Number = "18",
                            Town = "РУСЕ"
                        },
                        new
                        {
                            Id = 19,
                            Number = "19",
                            Town = "СИЛИСТРА"
                        },
                        new
                        {
                            Id = 20,
                            Number = "20",
                            Town = "СЛИВЕН"
                        },
                        new
                        {
                            Id = 21,
                            Number = "21",
                            Town = "СМОЛЯН"
                        },
                        new
                        {
                            Id = 22,
                            Number = "22",
                            Town = "СТАРА ЗАГОРА"
                        },
                        new
                        {
                            Id = 23,
                            Number = "23",
                            Town = "ТЪРГОВИЩЕ"
                        },
                        new
                        {
                            Id = 24,
                            Number = "24",
                            Town = "ХАСКОВО"
                        },
                        new
                        {
                            Id = 25,
                            Number = "25",
                            Town = "ШУМЕН"
                        },
                        new
                        {
                            Id = 26,
                            Number = "26",
                            Town = "ЯМБОЛ"
                        },
                        new
                        {
                            Id = 27,
                            Number = "27",
                            Town = "СОФИЯ ГРАД"
                        },
                        new
                        {
                            Id = 28,
                            Number = "27",
                            Town = "СОФИЯ /СГС/"
                        },
                        new
                        {
                            Id = 29,
                            Number = "28",
                            Town = "СОФИЯ ОКРЪГ"
                        });
                });

            modelBuilder.Entity("PublicSalesKChSI.Infrastructure.Data.Models.DeptorOld", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("Appartment")
                        .HasColumnType("int");

                    b.Property<string>("Building")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("Complex")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("CourtExtractFromKlas")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("DeptorsInfo")
                        .IsRequired()
                        .HasMaxLength(10000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Enrtance")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("Floor")
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("PINumber")
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Place")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Can be city or village");

                    b.Property<string>("Sreet")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SreetNumber")
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.Property<string>("Terrain")
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<int>("TypePlace")
                        .HasColumnType("int")
                        .HasComment("0 for city and 1 for village");

                    b.HasKey("Id");

                    b.ToTable("DeptorOlds");
                });

            modelBuilder.Entity("PublicSalesKChSI.Infrastructure.Data.Models.FromDownload.HtmlSeekAttrib", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<decimal?>("Area")
                        .HasColumnType("decimal(14,2)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Court")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("EndDate")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("Price")
                        .IsRequired()
                        .HasMaxLength(18)
                        .HasColumnType("nvarchar(18)");

                    b.Property<string>("PropertyNum")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<string>("Published")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("Receiver")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("SaleDate")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<int>("TempHtmlId")
                        .HasColumnType("int");

                    b.Property<int>("TypeSaleObj")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TempHtmlId");

                    b.ToTable("HtmlSeekAttribs");
                });

            modelBuilder.Entity("PublicSalesKChSI.Infrastructure.Data.Models.FromDownload.TempHtml", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("BrsFileId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("ntext");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("NumberInSite")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("BrsFileId");

                    b.ToTable("TempHtmls");
                });

            modelBuilder.Entity("PublicSalesKChSI.Infrastructure.Data.Models.FromDownload.TempPdf", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DublicatedFileNameNum")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<string>("OriginalName")
                        .IsRequired()
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)");

                    b.Property<long>("SizeOfFile")
                        .HasColumnType("bigint");

                    b.Property<int>("TempHtmlId")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TempHtmlId");

                    b.ToTable("TempPdfs");
                });

            modelBuilder.Entity("PublicSalesKChSI.Infrastructure.Data.Models.LastDownNumber", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("LastNumber")
                        .HasColumnType("int");

                    b.Property<string>("SaleType")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.ToTable("LastDownNumbers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            LastNumber = 7131,
                            SaleType = "asset"
                        },
                        new
                        {
                            Id = 2,
                            LastNumber = 4858,
                            SaleType = "vehicles"
                        },
                        new
                        {
                            Id = 3,
                            LastNumber = 65948,
                            SaleType = "properties"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("PublicSalesKChSI.Infrastructure.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("PublicSalesKChSI.Infrastructure.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PublicSalesKChSI.Infrastructure.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("PublicSalesKChSI.Infrastructure.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PublicSalesKChSI.Infrastructure.Data.Models.BrsFile", b =>
                {
                    b.HasOne("PublicSalesKChSI.Infrastructure.Data.Models.DeptorOld", "DeptorOld")
                        .WithMany("BrsesFiles")
                        .HasForeignKey("DeptorOldID");

                    b.HasOne("PublicSalesKChSI.Infrastructure.Data.Models.ApplicationUser", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId");

                    b.Navigation("DeptorOld");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("PublicSalesKChSI.Infrastructure.Data.Models.FromDownload.HtmlSeekAttrib", b =>
                {
                    b.HasOne("PublicSalesKChSI.Infrastructure.Data.Models.FromDownload.TempHtml", "TempHtml")
                        .WithMany()
                        .HasForeignKey("TempHtmlId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TempHtml");
                });

            modelBuilder.Entity("PublicSalesKChSI.Infrastructure.Data.Models.FromDownload.TempHtml", b =>
                {
                    b.HasOne("PublicSalesKChSI.Infrastructure.Data.Models.BrsFile", "BrsFile")
                        .WithMany("HtmlFiles")
                        .HasForeignKey("BrsFileId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("BrsFile");
                });

            modelBuilder.Entity("PublicSalesKChSI.Infrastructure.Data.Models.FromDownload.TempPdf", b =>
                {
                    b.HasOne("PublicSalesKChSI.Infrastructure.Data.Models.FromDownload.TempHtml", "TempHtml")
                        .WithMany()
                        .HasForeignKey("TempHtmlId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TempHtml");
                });

            modelBuilder.Entity("PublicSalesKChSI.Infrastructure.Data.Models.BrsFile", b =>
                {
                    b.Navigation("HtmlFiles");
                });

            modelBuilder.Entity("PublicSalesKChSI.Infrastructure.Data.Models.DeptorOld", b =>
                {
                    b.Navigation("BrsesFiles");
                });
#pragma warning restore 612, 618
        }
    }
}
