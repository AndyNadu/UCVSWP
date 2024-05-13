namespace UCVSWP.Models
{
    public class GradeAssignment
    {
        public int GradeAssignmentID { get; set; }

        public int GradeID { get; set; }
        public Grade? Grade { get; set; }

        public int AssignmentID { get; set; }
        public Assignment? Assignment { get; set; }
    }
}
