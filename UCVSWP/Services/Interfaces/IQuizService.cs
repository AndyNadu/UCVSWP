using UCVSWP.Models;

namespace UCVSWP.Services.Interfaces
{
	public interface IQuizService
	{
		List<Quiz> GetAllQuizs();
		Quiz GetQuizAndRelatedById(int id);
		bool QuizExists(int id);
		void AddQuiz(Quiz quiz);
		void UpdateQuiz(Quiz quiz);
		void DeleteQuiz(int id);

		List<Classroom> GetAllClassrooms();
		Quiz GetQuizById(int id);
	}
}
