using Microsoft.AspNetCore.Identity;

namespace StopHere.Api.Entities;

public class User : IdentityUser<Guid>
{
    public List<IdentityRole<Guid>>? Roles { get; set; }
}
