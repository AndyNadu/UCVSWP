namespace UCVSWP.Models
{
    public class Assignment
    {
        public int AssignmentID { get; set; }
        public string? Name { get; set; }
        public string? Content { get; set; }
        public DateTime Deadline { get; set; }

        public int ClassroomID { get; set; }
        public Classroom? Classroom { get; set; }

        public ICollection<Comment>? Comments { get; set; }
        public ICollection<GradeAssignment>? GradeAssignments { get; set; }
    }
}
