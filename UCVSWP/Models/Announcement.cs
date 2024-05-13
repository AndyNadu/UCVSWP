using System.ComponentModel.DataAnnotations.Schema;

namespace UCVSWP.Models
{
    public class Announcement
    {
        public int AnnouncementID { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }

        public int ClassroomID { get; set; }
        public Classroom? Classroom { get; set; }
    }
}
