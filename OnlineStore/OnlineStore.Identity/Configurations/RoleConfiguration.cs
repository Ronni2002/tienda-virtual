using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnlineStore.Identity.Configurations;

public class RoleConfiguration: IEntityTypeConfiguration<IdentityRole>
{
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        builder.HasData
        (
            new IdentityRole
            {
                Id = "248423d0-7059-4941-9956-a2aa8d6e7348",
                Name = "Admin",
                NormalizedName = "ADMIN",

            },
            new IdentityRole
            {
                Id = "3349204e-63f7-4bf9-aa57-889735c41ba5",
                Name = "Seller",
                NormalizedName = "SELLER",

            },
            new IdentityRole
            {
                Id = "a12eb854-a1f5-4711-a12b-88c9e7d6b0a2",
                Name = "User",
                NormalizedName = "USER",

            }
        );
    }
}