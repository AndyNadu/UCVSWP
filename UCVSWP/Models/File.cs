using Microsoft.AspNetCore.Identity;

namespace UCVSWP.Models
{
    public class File
    {
        public int? ID { get; set; }
        public string? FileName { get; set; }
        public byte[]? Attachment { get; set; }

        public string? UserId { get; set; }
        public IdentityUser? User { get; set; }
        public int? AssignmentID { get; set; }
        public Assignment? Assignment { get; set; }
    }
}
