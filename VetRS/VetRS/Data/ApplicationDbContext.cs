using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
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
        public DbSet<MilitaryJobTranslator> MilitaryJobsTranslator { get; set; }
        public DbSet<Employer> Employer { get; set; }
        public DbSet<Models.Group> Group { get; set; }
        public DbSet<Models.Message> Message { get; set; }
        public DbSet<UserGroup> UserGroup { get; set; }
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
            builder.Entity<IdentityRole>()
            .HasData(
            new IdentityRole
            {
                Name = "Employer",
                NormalizedName = "EMPLOYER"
            }
            );
            {
                builder.Entity<Employer>().HasData(
                    new Employer
                    {
                        Id = 1,
                        FirstName = "Reggie",
                        LastName = "White",
                        PhoneNumber = "4149647837",
                        Email = "ThisAintNoReggie92@Sprecher.com",
                        ImageLocation = "",
                        CompanyName = "Sprecher Brewing Co. Inc.",
                        CompanyImageLocation = "https://www.sprecherbrewery.com/wp-content/uploads/2020/06/Re_Fresh_500x500.jpg",
                        CompanyUrl = "sprecherbrewery.com",
                        CompanyBio = "Manufacturer of craft beers and craft gourmet sodas; retail shop, tap room, local entertainment venue",
                        CompanyStreet = "701 W. Glendale Ave.",
                        CompanyCity = "Glendale",
                        CompanyState = "Wisconsin",
                        CompanyZipCode = 53209,
                        Rating = 5,
                        Lat = 43.099650,
                        Long = -87.919820
                    },
                    new Employer
                    {
                        Id = 2,
                        FirstName = "LeRoy",
                        LastName = "Butler",
                        PhoneNumber = "262-796-1040",
                        Email = "Roy@EWH.com",
                        ImageLocation = "",
                        CompanyName = "EWH Small Business Accounting SC",
                        CompanyImageLocation = "",
                        CompanyUrl = "ewhsba.com",
                        CompanyBio = "Training for small business owners and their team, workshops focus on teaching the skills and tools to a business by the numbers",
                        CompanyStreet = "20670 Watertown Rd.",
                        CompanyCity = "Waukesha",
                        CompanyState = "Wisconsin",
                        CompanyZipCode = 53186,
                        Rating = 4,
                        Lat = 43.038780,
                        Long = 88.169670
                    },
                    new Employer
                    {
                        Id = 3,
                        FirstName = "Robert",
                        LastName = "Brooks",
                        PhoneNumber = "2627850900",
                        Email = "TDBob@EHCG.com",
                        ImageLocation = "",
                        CompanyName = "Elite Human Capital Group",
                        CompanyImageLocation = "",
                        CompanyUrl = "elitehumancapital.com",
                        CompanyBio = "Staffing, recruitment search firm specializing in areas of financial, manufacturing, health care, telecom, IT, engineering, human resources, and sales and marketing",
                        CompanyStreet = "155 S. Executive Dr.",
                        CompanyCity = "Brookfield",
                        CompanyState = "Wisconsin",
                        CompanyZipCode = 53005,
                        Rating = 4,
                        Lat = 43.030954,
                        Long = -88.115035
                    },
                    new Employer
                    {
                        Id = 4,
                        FirstName = "Don",
                        LastName = "Beebe",
                        PhoneNumber = "4149625110",
                        Email = "4x1xChamp@KMK.com",
                        ImageLocation = "",
                        CompanyName = "Kohner, Mann & Kailas SC",
                        CompanyImageLocation = "https://kmksc.com/wp-content/themes/kmk/images/KMK-Logo-Round.png",
                        CompanyUrl = "kmksc.com",
                        CompanyBio = "Law firm specializes in representation of commercial creditors in any respect and legal environment, both secured and unsecured; business clients utilize services to promote, protect interests as creditors in the state and country.",
                        CompanyStreet = "4650 N. Port Washington Rd",
                        CompanyCity = "Milwaukee",
                        CompanyState = "Wisconsin",
                        CompanyZipCode = 53212,
                        Rating = 5,
                        Lat = 43.100910,
                        Long = -87.915160
                    },
                    new Employer
                    {
                        Id = 5,
                        FirstName = "Mark",
                        LastName = "Chmura",
                        PhoneNumber = "2623673661",
                        Email = "89BigC@GPBalum.com",
                        ImageLocation = "",
                        CompanyName = "MSI General Corp.",
                        CompanyImageLocation = "",
                        CompanyUrl = "msigeneral.com",
                        CompanyBio = "Firm designs/constructs industrial, retail, commercial and institution buildings for projects throughout SE Wisconsin; approximately 30 major projects a year; also select project division for renovation and repair projects",
                        CompanyStreet = "P.O. Box 7",
                        CompanyCity = "Oconomowoc",
                        CompanyState = "Wisconsin",
                        CompanyZipCode = 53066,
                        Rating = 5,
                        Lat = 43.099160,
                        Long = -88.498070
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
                            VSOStreet = "Martin Luther King Dr.",
                            VSOCity = "Milwaukee",
                            VSOState = "WI",
                            VSOZipCode = 53212,
                            Rating = 5,
                            Lat = 43.066527,
                            Long = -87.914071
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
                            VSOZipCode = 53212,
                            Rating = 4,
                            Lat = 43.061505,
                            Long = -87.918490
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
                            VSOZipCode = 53216,
                            Rating = 3,
                            Lat = 43.076442,
                            Long = -87.952109

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
                            VSOZipCode = 53206,
                            Rating = 4,
                            Lat = 43.072878,
                            Long = -87.939920
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
                            VSOZipCode = 53206,
                            Rating = 5,
                            Lat = 43.065750,
                            Long = -87.933822
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
                            VeteranZipCode = 53916,
                            Lat = 43.459987,
                            Long = -88.819759
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
                            VeteranZipCode = 53233,
                            Lat = 43.041615,
                            Long = -87.936450
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
                            VeteranZipCode = 53202,
                            Lat = 43.038844,
                            Long = -87.905074
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
                            VeteranZipCode = 53202,
                            Lat = 43.043459,
                            Long = -87.909976
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
                            VeteranZipCode = 53202,
                            Lat = 43.046977,
                            Long = -87.906663
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
                            EducationStreet = "Mitchell St.",
                            EducationCity = "Milwaukee",
                            EducationState = "Wisconsin",
                            EducationZipCode = 53215,
                            Lat = 43.012317,
                            Long = -87.955794
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
                            EducationZipCode = 53233,
                            Lat = 43.043551,
                            Long = -87.921151
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
                            Lat = 43.140320,
                            Long = -87.907153
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
                            EducationStreet = "313 N Plankinton Ave Suite 209",
                            EducationCity = "Milwaukee",
                            EducationState = "Wisconsin",
                            EducationZipCode = 53203,
                            Lat = 43.034196,
                            Long = -87.912330
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
                            EducationZipCode = 53211,
                            Lat = 43.074988,
                            Long = -87.879600
                        }
                        );
                    {
                        builder.Entity<MilitaryJobTranslator>().HasData(
                            new MilitaryJobTranslator
                            {
                                MilitarySpecialtyNumber = "3531",
                                MilitaryJobTitle = "Motor Vehicle Operator",
                                CivilianJobTitle = "Truck Driver"
                            },
                            new MilitaryJobTranslator
                            {
                                MilitarySpecialtyNumber = "8411",
                                MilitaryJobTitle = "Recruiter",
                                CivilianJobTitle = "Human Resource Specialist"
                            },
                            new MilitaryJobTranslator
                            {
                                MilitarySpecialtyNumber = "25B",
                                MilitaryJobTitle = "Information Technology Specialist",
                                CivilianJobTitle = "Computer and Information System Manager"
                            },
                            new MilitaryJobTranslator
                            {
                                MilitarySpecialtyNumber = "4N0",
                                MilitaryJobTitle = "Aerospace Medical Services",
                                CivilianJobTitle = "Emergency Medical Technician"
                            },
                            new MilitaryJobTranslator
                            {
                                MilitarySpecialtyNumber = "4T0",
                                MilitaryJobTitle = "Medical Laboratory Specialist",
                                CivilianJobTitle = "Clinical Laboratory Technologist"
                            }

                            );
                    }
                }


            }
        }
    }
}






