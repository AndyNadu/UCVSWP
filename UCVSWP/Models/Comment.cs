namespace UCVSWP.Models
{
    public class Comment
    {
        public int CommentID { get; set; }
        public string? Content { get; set; }
        public Boolean Privacy { get; set; }

        public int AssignmentID { get; set; }
        public Assignment? Assignement { get; set; }

    }
}
