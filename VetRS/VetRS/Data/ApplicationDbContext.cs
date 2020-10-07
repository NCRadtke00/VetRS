using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VetRS.Models;

namespace VetRS.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<VSO> VSO { get; set; }

        public DbSet<Education> Education { get; set; }
        public DbSet<Veteran> Veteran { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<IdentityRole>()
            .HasData(
            new IdentityRole
            {
                Name = "Veteran",
                NormalizedName = "VETERAN"
            }
            );
            builder.Entity<IdentityRole>()
            .HasData(
            new IdentityRole
            {
                Name = "VSO",
                NormalizedName = "VSO"
            }
            );
            builder.Entity<IdentityRole>()
            .HasData(
            new IdentityRole
            {
                Name = "Education Rep.",
                NormalizedName = "EDUCATION REP"
            }
            );
            {
                builder.Entity<VSO>().HasData(
                    new VSO
                    {
                        Id = 1,
                        FirstName = "Aaron",
                        LastName = "Rodgers",
                        PhoneNumber = "9205552020",
                        Email = "Lombardibarbie@PackersChamps.com",
                        ImageLocation = "",
                        VSOStreet = "Martin Luther King Ave.",
                        VSOCity = "Milwaukee",
                        VSOState = "WI",
                        VSOZipCode = 53022
                    },
                    new VSO
                    {
                        Id = 2,
                        FirstName = "Brett",
                        LastName = "Farve",
                        PhoneNumber = "9203332020",
                        Email = "Gunslinger@PackersChamps.com",
                        ImageLocation = "",
                        VSOStreet = "6th St.",
                        VSOCity = "Milwaukee",
                        VSOState = "WI",
                        VSOZipCode = 53022
                    },
                    new VSO
                    {
                        Id = 3,
                        FirstName = "Jordy",
                        LastName = "Nelson",
                        PhoneNumber = "5558675309",
                        Email = "MrHands@PackersChamps.com",
                        ImageLocation = "",
                        VSOStreet = "31st St.",
                        VSOCity = "Milwaukee",
                        VSOState = "WI",
                        VSOZipCode = 53022
                    },
                    new VSO
                    {
                        Id = 4,
                        FirstName = "BJ",
                        LastName = "Raji",
                        PhoneNumber = "5552344545",
                        Email = "Doubleyourdoublecheck@PackersChamps.com",
                        ImageLocation = "",
                        VSOStreet = "22nd St.",
                        VSOCity = "Milwaukee",
                        VSOState = "Wisconsin",
                        VSOZipCode = 53022
                    },
                    new VSO
                    {
                        Id = 5,
                        FirstName = "Bart",
                        LastName = "Starr",
                        PhoneNumber = "5558761515",
                        Email = "Astarrisborn@packerschamps.com",
                        ImageLocation = "",
                        VSOStreet = "17th St.",
                        VSOCity = "Milwaukee",
                        VSOState = "WI",
                        VSOZipCode = 53022
                    }
                 );
            }
            {
                builder.Entity<Veteran>().HasData(
                    new Veteran
                    {
                        Id = 1,
                        FirstName = "Jose",
                        LastName = "Torres",
                        PhoneNumber = "9203827037",
                        Email = "Sgtjosetorres@yahoo.com",
                        ImageLocation = "",
                        VeteranStreet = "515 Walnut St",
                        VeteranCity = "Beaver Dam",
                        VeteranState = "WI",
                        VeteranZipCode = 53916
                    },
                    new Veteran
                    {
                        Id = 2,
                        FirstName = "Eric",
                        LastName = "Hill",
                        PhoneNumber = "5552452010",
                        Email = "Thatdude@softwaredeveloper.com",
                        ImageLocation = "",
                        VeteranStreet = "Kilbourn Ave",
                        VeteranCity = "Milwaukee",
                        VeteranState = "WI",
                        VeteranZipCode = 53022
                    },
                    new Veteran
                    {
                        Id = 3,
                        FirstName = "Chesty",
                        LastName = "Puller",
                        PhoneNumber = "1234567891",
                        Email = "Realamericanhero@DevDogg.com",
                        ImageLocation = "",
                        VeteranStreet = "W. Wisconsin Ave.",
                        VeteranCity = "Milwaukee",
                        VeteranState = "WI",
                        VeteranZipCode = 53022
                    },
                    new Veteran
                    {
                        Id = 4,
                        FirstName = "Lucian",
                        LastName = "Adams",
                        PhoneNumber = "9201119999",
                        Email = "MedalOfHonor@armyman.com",
                        ImageLocation = "",
                        VeteranStreet = "E. State St.",
                        VeteranCity = "Milwaukee",
                        VeteranState = "WI",
                        VeteranZipCode = 53022
                    },
                    new Veteran
                    {
                        Id = 5,
                        FirstName = "Steven",
                        LastName = "Bennet",
                        PhoneNumber = "9998883333",
                        Email = "RealFlyBoy@airforcehero.com",
                        ImageLocation = "",
                        VeteranStreet = "E. Knapp St.",
                        VeteranCity = "Milwaukee",
                        VeteranState = "WI",
                        VeteranZipCode = 53022
                    }
                    );
            }
            {
                builder.Entity<Education>().HasData(
                    new Education
                    {
                        Id = 1,
                        FirstName = "Bobby",
                        LastName = "Knight",
                        PhoneNumber = "2228389992",
                        Email = "BigGuy@comcast.net",
                        ImageLocation = "",
                        ProgramName = "University of Wisconsin",
                        ProgramImageLocation = "",
                        ProgramBio = "Wisconsin's Premier Educational State Institution",
                        EducationStreet = "Surly",
                        EducationCity = "Milwaukee",
                        EducationState = "Wisconsin",
                        EducationZipCode = 53022,
                    },
                    new Education
                    {
                        Id = 2,
                        FirstName = "Mitch",
                        LastName = "Holcomb",
                        PhoneNumber = "9392244234",
                        Email = "RuReady@comcast.net",
                        ImageLocation = "",
                        ProgramName = "Milwaukee Area Technical College",
                        ProgramImageLocation = "",
                        ProgramBio = "Education that transforms lives, industry, and community.",
                        EducationStreet = "700 W. State Street",
                        EducationCity = "Milwaukee",
                        EducationState = "Wisconsin",
                        EducationZipCode = 53232,
                    },
                    new Education
                    {
                        Id = 3,
                        FirstName = "Sheila",
                        LastName = "Williams",
                        PhoneNumber = "8003478822",
                        Email = "ShellieN19@gmail.com",
                        ImageLocation = "",
                        ProgramName = "Cardinal Stritch University",
                        ProgramImageLocation = "",
                        ProgramBio = "Stritch's story is integrated with more than 38,000 of our alumni who are positively impacting the communities in which they live, work, serve, and lead.",
                        EducationStreet = "6801 N. Yates Road",
                        EducationCity = "Milwaukee",
                        EducationState = "Wisconsin",
                        EducationZipCode = 53217,
                    },
                    new Education
                    {
                        Id = 4,
                        FirstName = "Wendy",
                        LastName = "Knight",
                        PhoneNumber = "4145330639",
                        Email = "Wendydev13@comcast.net",
                        ImageLocation = "",
                        ProgramName = "devCodeCamp",
                        ProgramImageLocation = "",
                        ProgramBio = "devCodeCamp has been awarded 'Best Coding Bootcamp' by Course Report each year 2016-2020",
                        EducationStreet = "313 N Plankington Ave Suite 209",
                        EducationCity = "Milwaukee",
                        EducationState = "Wisconsin",
                        EducationZipCode = 53303,
                    },
                    new Education
                    {
                        Id = 5,
                        FirstName = "James",
                        LastName = "Schmidt",
                        PhoneNumber = "4142296627",
                        Email = "vets@uwm.edu",
                        ImageLocation = "",
                        ProgramName = "University of Wisconsin - Milwaukee",
                        ProgramImageLocation = "",
                        ProgramBio = "Wisconsin's Premier Educational State Institution",
                        EducationStreet = "Mellencamp Hall, Room 168A, P.O. Box 469",
                        EducationCity = "Milwaukee",
                        EducationState = "Wisconsin",
                        EducationZipCode = 53201,
                    }
                    );
            }
        }
    }

        }

