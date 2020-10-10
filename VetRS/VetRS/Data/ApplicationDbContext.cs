using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VetRS.Models;
using System.Linq;
using System.Threading.Tasks;


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
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<ChatRoom> ChatRooms { get; set; }
        public DbSet<ChatRoomUser> ChatRoomUsers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(GetConnectionString());
            optionsBuilder.EnableSensitiveDataLogging();
            //optionsBuilder.UseLazyLoadingProxies(); cant get this to work
        }

        private static string GetConnectionString()
        {
            const string databaseName = "ExampleSignalR";

            return $"Server=localhost;" +
                   $"database={databaseName};" +
                   $"Trusted_Connection = True;" +
                   $"MultipleActiveResultSets = True;" +
                    $"pooling=true;";
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ChatRoomUser>(b => b.HasOne<User>(navigationExpression: uf => uf.User)
           .WithMany(navigationExpression: nf => nf.ChatRoomUsers)
           .HasForeignKey(nf => nf.UserId));

            builder.Entity<ChatRoomUser>(b => b.HasOne<ChatRoom>(navigationExpression: uf => uf.ChatRoom)
           .WithMany(navigationExpression: nf => nf.ChatRoomUsers)
           .HasForeignKey(nf => nf.ChatRoomId));

            builder.Entity<ChatRoomUser>(b => b.HasKey(x => new { x.UserId, x.ChatRoomId }));
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
                        VSOStreet = "Martin Luther King Dr.",
                        VSOCity = "Milwaukee",
                        VSOState = "WI",
                        VSOZipCode = 53212,
                        Rating = 5,
                        Lat = 43.066527,
                        Long =  -87.914071
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

    
    


