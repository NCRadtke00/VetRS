﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VetRS.Data;

namespace VetRS.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20201006225053_Education-Data")]
    partial class EducationData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "7f35ea31-cfc1-474e-9346-efed6a2ce70f",
                            ConcurrencyStamp = "23993739-4b76-4c87-8d76-8fb90cc9078f",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

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
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("VetRS.Models.Education", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EducationCity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EducationState")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EducationStreet")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EducationZipCode")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdentityUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ImageLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProgramBio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProgramImageLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProgramName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdentityUserId");

                    b.ToTable("Education");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EducationCity = "Milwaukee",
                            EducationState = "Wisconsin",
                            EducationStreet = "Surly",
                            EducationZipCode = 53022,
                            Email = "BigGuy@comcast.net",
                            FirstName = "Bobby",
                            ImageLocation = "",
                            LastName = "Knight",
                            PhoneNumber = "2228389992",
                            ProgramBio = "Wisconsin's Premier Educational State Institution",
                            ProgramImageLocation = "",
                            ProgramName = "University of Wisconsin"
                        },
                        new
                        {
                            Id = 2,
                            EducationCity = "Milwaukee",
                            EducationState = "Wisconsin",
                            EducationStreet = "700 W. State Street",
                            EducationZipCode = 53232,
                            Email = "RuReady@comcast.net",
                            FirstName = "Mitch",
                            ImageLocation = "",
                            LastName = "Holcomb",
                            PhoneNumber = "9392244234",
                            ProgramBio = "Education that transforms lives, industry, and community.",
                            ProgramImageLocation = "",
                            ProgramName = "Milwaukee Area Technical College"
                        },
                        new
                        {
                            Id = 3,
                            EducationCity = "Milwaukee",
                            EducationState = "Wisconsin",
                            EducationStreet = "6801 N. Yates Road",
                            EducationZipCode = 53217,
                            Email = "ShellieN19@gmail.com",
                            FirstName = "Sheila",
                            ImageLocation = "",
                            LastName = "Williams",
                            PhoneNumber = "8003478822",
                            ProgramBio = "Stritch's story is integrated with more than 38,000 of our alumni who are positively impacting the communities in which they live, work, serve, and lead.",
                            ProgramImageLocation = "",
                            ProgramName = "Cardinal Stritch University"
                        },
                        new
                        {
                            Id = 4,
                            EducationCity = "Milwaukee",
                            EducationState = "Wisconsin",
                            EducationStreet = "313 N Plankington Ave Suite 209",
                            EducationZipCode = 53303,
                            Email = "Wendydev13@comcast.net",
                            FirstName = "Wendy",
                            ImageLocation = "",
                            LastName = "Knight",
                            PhoneNumber = "4145330639",
                            ProgramBio = "devCodeCamp has been awarded 'Best Coding Bootcamp' by Course Report each year 2016-2020",
                            ProgramImageLocation = "",
                            ProgramName = "devCodeCamp"
                        },
                        new
                        {
                            Id = 5,
                            EducationCity = "Milwaukee",
                            EducationState = "Wisconsin",
                            EducationStreet = "Mellencamp Hall, Room 168A, P.O. Box 469",
                            EducationZipCode = 52732,
                            Email = "vets@uwm.edu",
                            FirstName = "James",
                            ImageLocation = "",
                            LastName = "Schmidt",
                            PhoneNumber = "4142296627",
                            ProgramBio = "Wisconsin's Premier Educational State Institution",
                            ProgramImageLocation = "",
                            ProgramName = "University of Wisconsin - Milwaukee"
                        });
                });

            modelBuilder.Entity("VetRS.Models.VSO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdentityUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ImageLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VSOCity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VSOState")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VSOStreet")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VSOZipCode")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdentityUserId");

                    b.ToTable("VSO");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "Lombardibarbie@PackersChamps.com",
                            FirstName = "Aaron",
                            ImageLocation = "",
                            LastName = "Rodgers",
                            PhoneNumber = "9205552020",
                            VSOCity = "Milwaukee",
                            VSOState = "WI",
                            VSOStreet = "Martin Luther King Ave.",
                            VSOZipCode = 53022
                        },
                        new
                        {
                            Id = 2,
                            Email = "Gunslinger@PackersChamps.com",
                            FirstName = "Brett",
                            ImageLocation = "",
                            LastName = "Farve",
                            PhoneNumber = "9203332020",
                            VSOCity = "Milwaukee",
                            VSOState = "WI",
                            VSOStreet = "6th St.",
                            VSOZipCode = 53022
                        },
                        new
                        {
                            Id = 3,
                            Email = "MrHands@PackersChamps.com",
                            FirstName = "Jordy",
                            ImageLocation = "",
                            LastName = "Nelson",
                            PhoneNumber = "5558675309",
                            VSOCity = "Milwaukee",
                            VSOState = "WI",
                            VSOStreet = "31st St.",
                            VSOZipCode = 53022
                        },
                        new
                        {
                            Id = 4,
                            Email = "Doubleyourdoublecheck@PackersChamps.com",
                            FirstName = "BJ",
                            ImageLocation = "",
                            LastName = "Raji",
                            PhoneNumber = "5552344545",
                            VSOCity = "Milwaukee",
                            VSOState = "Wisconsin",
                            VSOStreet = "22nd St.",
                            VSOZipCode = 53022
                        },
                        new
                        {
                            Id = 5,
                            Email = "Astarrisborn@packerschamps.com",
                            FirstName = "Bart",
                            ImageLocation = "",
                            LastName = "Starr",
                            PhoneNumber = "5558761515",
                            VSOCity = "Milwaukee",
                            VSOState = "WI",
                            VSOStreet = "17th St.",
                            VSOZipCode = 53022
                        });
                });

            modelBuilder.Entity("VetRS.Models.Veteran", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdentityUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ImageLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VeteranCity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VeteranState")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VeteranStreet")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VeteranZipCode")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdentityUserId");

                    b.ToTable("Veteran");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "Sgtjosetorres@yahoo.com",
                            FirstName = "Jose",
                            ImageLocation = "",
                            LastName = "Torres",
                            PhoneNumber = "9203827037",
                            VeteranCity = "Beaver Dam",
                            VeteranState = "WI",
                            VeteranStreet = "515 Walnut St",
                            VeteranZipCode = 53916
                        },
                        new
                        {
                            Id = 2,
                            Email = "Thatdude@softwaredeveloper.com",
                            FirstName = "Eric",
                            ImageLocation = "",
                            LastName = "Hill",
                            PhoneNumber = "5552452010",
                            VeteranCity = "Milwaukee",
                            VeteranState = "WI",
                            VeteranStreet = "Kilbourn Ave",
                            VeteranZipCode = 53022
                        },
                        new
                        {
                            Id = 3,
                            Email = "Realamericanhero@DevDogg.com",
                            FirstName = "Chesty",
                            ImageLocation = "",
                            LastName = "Puller",
                            PhoneNumber = "1234567891",
                            VeteranCity = "Milwaukee",
                            VeteranState = "WI",
                            VeteranStreet = "W. Wisconsin Ave.",
                            VeteranZipCode = 53022
                        },
                        new
                        {
                            Id = 4,
                            Email = "MedalOfHonor@armyman.com",
                            FirstName = "Lucian",
                            ImageLocation = "",
                            LastName = "Adams",
                            PhoneNumber = "9201119999",
                            VeteranCity = "Milwaukee",
                            VeteranState = "WI",
                            VeteranStreet = "E. State St.",
                            VeteranZipCode = 53022
                        },
                        new
                        {
                            Id = 5,
                            Email = "RealFlyBoy@airforcehero.com",
                            FirstName = "Steven",
                            ImageLocation = "",
                            LastName = "Bennet",
                            PhoneNumber = "9998883333",
                            VeteranCity = "Milwaukee",
                            VeteranState = "WI",
                            VeteranStreet = "E. Knapp St.",
                            VeteranZipCode = 53022
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
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
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

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VetRS.Models.Education", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "IdentityUser")
                        .WithMany()
                        .HasForeignKey("IdentityUserId");
                });

            modelBuilder.Entity("VetRS.Models.VSO", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "IdentityUser")
                        .WithMany()
                        .HasForeignKey("IdentityUserId");
                });

            modelBuilder.Entity("VetRS.Models.Veteran", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "IdentityUser")
                        .WithMany()
                        .HasForeignKey("IdentityUserId");
                });
#pragma warning restore 612, 618
        }
    }
}
