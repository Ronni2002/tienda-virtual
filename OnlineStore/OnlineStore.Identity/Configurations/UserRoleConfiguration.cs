using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnlineStore.Identity.Configurations;

public class UserRoleConfiguration: IEntityTypeConfiguration<IdentityUserRole<string>>
{
    public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
    {
        builder.HasData
        (
            new IdentityUserRole<string>
            {
                RoleId = "248423d0-7059-4941-9956-a2aa8d6e7348",
                UserId = "47f17096-acbc-47dd-98d6-e38953ecf2d4"
            },
            new IdentityUserRole<string>
            {
                RoleId = "3349204e-63f7-4bf9-aa57-889735c41ba5",
                UserId = "e9fd25c3-8619-4bc1-98a5-60ebc81d7fe9"
            },
            new IdentityUserRole<string>
            {
                RoleId = "a12eb854-a1f5-4711-a12b-88c9e7d6b0a2",
                UserId = "b3a67450-450a-4f7c-b3da-c00d966dca2f"
            }
        );
    }
}