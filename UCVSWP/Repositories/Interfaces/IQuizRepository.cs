using UCVSWP.Models;

namespace UCVSWP.Repositories.Interfaces
{
	public interface IQuizRepository
	{
		IEnumerable<Quiz> GetAll();
		Quiz GetByIdWithRelatedEntities(int id);

		Quiz GetById(int id);
		bool QuizExists(int id);
		void Create(Quiz quiz);
		void Update(Quiz quiz);
		void Delete(Quiz quiz);

		void Save();
		List<Classroom> GetAllClassrooms();
	}
}
