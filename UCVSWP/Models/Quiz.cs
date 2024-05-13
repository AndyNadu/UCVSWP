namespace UCVSWP.Models
{
    public class Quiz
    {
        public int QuizID { get; set; }
        public string? Name { get; set; }
        public string? Content { get; set; }
        public DateTime Deadline { get; set; }

        public int ClassroomID { get; set; }
        public Classroom? Classroom { get; set; } 
    }
}
