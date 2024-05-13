namespace UCVSWP.Models
{
    public class Grade
    {
        public int GradeID { get; set; }
        public int Score { get; set; }
        //public User User { get; set; }
        public ICollection<GradeAssignment>? GradeAssignments { get; set; }
      
    }
}
