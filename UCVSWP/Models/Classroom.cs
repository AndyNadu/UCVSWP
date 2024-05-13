using NuGet.DependencyResolver;

namespace UCVSWP.Models
{
    public class Classroom
    {
        public int ClassroomID { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        //public Teacher Teacher { get; set; } ? 
        
        public ICollection<Announcement>? Announcements { get; set; }
        public ICollection<Assignment>? Assignments { get; set; }

    }
}
