using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity;

public class AppUser : IdentityUser<long>
{
	public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Photo { get; set; } = null!;

    public virtual ICollection<AppUserRole> UserRoles { get; set; } = null!;
}
