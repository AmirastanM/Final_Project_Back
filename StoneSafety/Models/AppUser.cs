using Microsoft.AspNetCore.Identity;

namespace StoneSafety.Models
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}
