using Microsoft.AspNetCore.Identity;
using UCVSWP.Models;

namespace UCVSWP.Controllers
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<UserClassroom>? userClassrooms { get; set; }
    }
}
