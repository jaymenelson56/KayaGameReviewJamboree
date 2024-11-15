using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using KayaGameReviewJamboree.Models;
using Microsoft.AspNetCore.Identity;

namespace KayaGameReviewJamboree.Data;
public class KayaGameReviewJamboreeDbContext : IdentityDbContext<IdentityUser>
{
    private readonly IConfiguration _configuration;
    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Reaction> Reactions { get; set; }
    public DbSet<UserComment> UserComments { get; set; }


    public KayaGameReviewJamboreeDbContext(DbContextOptions<KayaGameReviewJamboreeDbContext> context, IConfiguration config) : base(context)
    {
        _configuration = config;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
        {
            Id = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
            Name = "Admin",
            NormalizedName = "admin"
        });

        modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser[]
        {
                new IdentityUser
                {
                    Id = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                    UserName = "JaymeChaka",
                    Email = "jayme@chaka.comx",
                    PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
                },
                new IdentityUser
                {
                    Id = "d8d76512-74f1-43bb-b1fd-87d3a8aa36df",
                    UserName = "KayaGaba",
                    Email = "kaya@gaba.comx",
                    PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
                },
                new IdentityUser
                {
                    Id = "a7d21fac-3b21-454a-a747-075f072d0cf3",
                    UserName = "FoxGaba",
                    Email = "fox@gaba.comx",
                    PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
                },
                new IdentityUser
                {
                    Id = "c806cfae-bda9-47c5-8473-dd52fd056a9b",
                    UserName = "BongoGaba",
                    Email = "bongo@gaba.comx",
                    PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
                },
                new IdentityUser
                {
                    Id = "9ce89d88-75da-4a80-9b0d-3fe58582b8e2",
                    UserName = "JerryGaba",
                    Email = "jerry@gaba.comx",
                    PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
                },
        });

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>[]
           {
                new IdentityUserRole<string>
                {
                    RoleId = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
                    UserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
                    UserId = "d8d76512-74f1-43bb-b1fd-87d3a8aa36df"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
                    UserId = "a7d21fac-3b21-454a-a747-075f072d0cf3"
                },
           });
        modelBuilder.Entity<UserProfile>().HasData(new UserProfile[]

        {
            new UserProfile
            {
            Id = 1,
            IdentityUserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
            FirstName = "Jayme",
            LastName = "Chaka",
            Address = "In my own head",
            },
            new UserProfile
            {
            Id = 2,
            IdentityUserId = "d8d76512-74f1-43bb-b1fd-87d3a8aa36df",
            FirstName = "Kaya",
            LastName = "Chaka",
            Address = "In our hearts",
            },
            new UserProfile
            {
            Id = 3,
            IdentityUserId = "a7d21fac-3b21-454a-a747-075f072d0cf3",
            FirstName = "Fox",
            LastName = "Chaka",
            Address = "In our hearts",
            },
            new UserProfile
            {
            Id = 4,
            IdentityUserId = "c806cfae-bda9-47c5-8473-dd52fd056a9b",
            FirstName = "Bongo",
            LastName = "Chaka",
            Address = "In our hearts",
            },
            new UserProfile
            {
            Id = 5,
            IdentityUserId = "9ce89d88-75da-4a80-9b0d-3fe58582b8e2",
            FirstName = "Jerry",
            LastName = "Chaka",
            Address = "In our hearts",
            },

        });

        modelBuilder.Entity<Review>().HasData(new Review[]

        {
            new Review
                    {
                    Id = 1,
                    UserProfileId = 2,
                    Title = "Overcooked",
                    Body =  "When I first got my paws on this game I wanted to eat the food, made in this game. I could not, it was frustrating, however I moved forward and found that this game was really fun with my friends, the chaotic nature of fumbling to tripping over each other in the kitchen mimicks that way my humans trip over me, I give this game a 4 out of 10 maybe next time I can eat the food.",
                    ReactionId = 8
                    },
        });

        modelBuilder.Entity<Reaction>().HasData(new Reaction[]

        {
            new Reaction
            {
                Id = 1,
                Image = "/images/neutral.jpg",
                AltText = "Kaya's Neutral Face",
                Description = "Neutral"
            }
        });


    }
}