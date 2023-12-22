using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationDemo.RepositoryLayer.Context
{

    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //Add the roles by calling the SeedRole method
            SeedRoles(builder);
        }

        //Add Roles to the AspNetUserRole default dentity table
        private static void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole()
                {
                    Name = "Admin",
                    //helps prevent conflicts by ensuring that updates are applied only if the entity's concurrency stamp matches
                    ConcurrencyStamp = "1",
                    //NormalizedName is used to support case-insensitive searches and comparisons for role names.
                    NormalizedName = "Admin"
                },
                
                new IdentityRole()
                {
                    Name = "Patient",
                    ConcurrencyStamp = "2",
                    NormalizedName = "Patient"
                }
                ,
                
                    new IdentityRole()
                    {
                        Name = "Doctor",
                        ConcurrencyStamp = "3",
                        NormalizedName = "Doctor"
                    }
                    );

    }
    }
    }

