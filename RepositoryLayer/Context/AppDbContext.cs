using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationDemo.RepositoryLayer.Context
{
  /**this class to interact with database, since we're Authinticating users using Identity we Inherit from IdentityDbContext.
   *IdentityDbContext includes tables for users, roles,and other identity-related information.
   *The tables include fields such as Id, UserName, NormalizedUserName, PasswordHash, and others.
    **/

    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
     // Add your custom model configurations here ,ex: Fk and relations between db tables 

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Add the roles by calling the SeedRole method
            SeedRoles(builder);
        }

        //Add Roles to the AspNetUserRole default dentity table by Data seeding
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

