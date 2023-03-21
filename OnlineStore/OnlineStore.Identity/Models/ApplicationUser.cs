using Microsoft.AspNetCore.Identity;

namespace OnlineStore.Identity.Models;

public class ApplicationUser: IdentityUser
{
    public string Name { get; set; } = null!;
    public string LastName { get; set; } = null!;

}