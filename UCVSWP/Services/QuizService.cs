using UCVSWP.Models;
using UCVSWP.Repositories.Interfaces;
using UCVSWP.Services.Interfaces;

namespace UCVSWP.Services
{
	public class QuizService : IQuizService
	{
		private readonly IQuizRepository _quizRepository;

		public QuizService(IQuizRepository quizRepository)
		{
			_quizRepository = quizRepository;
		}

		public void AddQuiz(Quiz quiz)
		{
			_quizRepository.Create(quiz);
			_quizRepository.Save();
		}

		public void DeleteQuiz(int id)
		{
			var quiz = _quizRepository.GetById(id);
			if (quiz != null)
			{
				_quizRepository.Delete(quiz);
				_quizRepository.Save();
			}
		}

		public List<Classroom> GetAllClassrooms()
		{
			return _quizRepository.GetAllClassrooms();
		}

		public List<Quiz> GetAllQuizs()
		{
			return _quizRepository.GetAll().ToList();
		}

		public Quiz GetQuizAndRelatedById(int id)
		{
			return _quizRepository.GetByIdWithRelatedEntities(id);
		}

		public Quiz GetQuizById(int id)
		{
			return _quizRepository.GetById(id);
		}

		public bool QuizExists(int id)
		{
			return _quizRepository.QuizExists(id);
		}

		public void UpdateQuiz(Quiz quiz)
		{
			_quizRepository.Update(quiz);
			_quizRepository.Save();
		}
	}
}
