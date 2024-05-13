using Microsoft.AspNetCore.Identity;

namespace UCVSWP.Models
{
    public class UserClassroom
    {
        public int? UserClassroomId { get; set; }
        public string? UserId { get; set; }
        public IdentityUser? User { get; set; }
        public int? ClassroomID { get; set; }
        public Classroom? Classroom { get; set; }
    }
}
