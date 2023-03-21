using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Identity.Models;

namespace OnlineStore.Identity.Configurations;

public class UserConfiguration: IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        var hasher = new PasswordHasher<ApplicationUser>();

        builder.HasData
        (
            new ApplicationUser
            {
                Id = "47f17096-acbc-47dd-98d6-e38953ecf2d4",
                Email = "admin@localhost.com",
                NormalizedEmail = "admin@localhost.com",
                Name = "Admin",
                LastName = "Admin",
                UserName = "admin",
                NormalizedUserName = "admin",
                PasswordHash = hasher.HashPassword(null, "123456789"),
                EmailConfirmed = true
            },
            new ApplicationUser
            {
                Id = "e9fd25c3-8619-4bc1-98a5-60ebc81d7fe9",
                Email = "seller@localhost.com",
                NormalizedEmail = "seller@localhost.com",
                Name = "Seller",
                LastName = "Seller",
                UserName = "seller",
                NormalizedUserName = "seller",
                PasswordHash = hasher.HashPassword(null, "123456789"),
                EmailConfirmed = true
            },
            new ApplicationUser
            {
                Id = "b3a67450-450a-4f7c-b3da-c00d966dca2f",
                Email = "user@localhost.com",
                NormalizedEmail = "user@localhost.com",
                Name = "user",
                LastName = "user",
                UserName = "user",
                NormalizedUserName = "user",
                PasswordHash = hasher.HashPassword(null, "123456789"),
                EmailConfirmed = true
            }
        );
    }
}