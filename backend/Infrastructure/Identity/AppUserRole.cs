using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Infrastructure.Identity;

public class AppUserRole : IdentityUserRole<long>
{
    public virtual AppUser User { get; set; } = null!;

    public virtual AppRole Role { get; set; } = null!;
}