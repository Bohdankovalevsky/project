using LiquidCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LiquidWebApp.Data
{
    public static class ApplicationDbContextModelBuilder
    {

        public static void Seed(this ModelBuilder builder)
        {
            string ADMIN_ROLE_ID = Guid.NewGuid().ToString();
            string USER_ROLE_ID = Guid.NewGuid().ToString();
            builder.Entity<IdentityRole>()
                .HasData(
                new IdentityRole
                {
                    Id = ADMIN_ROLE_ID,
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = ADMIN_ROLE_ID
                },
                new IdentityRole
                {
                    
                    Id = USER_ROLE_ID,
                    Name = "User",
                    NormalizedName = "USER",
                    ConcurrencyStamp = ADMIN_ROLE_ID
                });
            String ADMIN_ID = Guid.NewGuid().ToString();
            String USER_ID = Guid.NewGuid().ToString();

            var adminUser = new AppUser
            {
                Id = ADMIN_ID,
                UserName = "admin@liquid.com",
                EmailConfirmed = true,
                NormalizedUserName = "admin@liquid.com",
                Email = "admin@liquid.com"

            };
            var editorUser = new AppUser
            {
                Id = USER_ID,
                UserName = "user@liquid.com",
                EmailConfirmed = true,
                NormalizedUserName = "user@liquid.com",
                Email = "user@liquid.com"

            };

            PasswordHasher<AppUser> passwordHasher = new PasswordHasher<AppUser>();
            adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, "admin123");
            editorUser.PasswordHash = passwordHasher.HashPassword(editorUser, "user123");

            builder.Entity<AppUser>()
                .HasData(adminUser, editorUser);
            builder.Entity<IdentityUserRole<string>>()
                .HasData(
                new IdentityUserRole<string>
                {
                    RoleId = USER_ROLE_ID,
                    UserId = USER_ID
                },

                new IdentityUserRole<string>
                {
                    RoleId = ADMIN_ROLE_ID,
                    UserId = ADMIN_ID
                }


                ) ;

            


        }
     }
}
