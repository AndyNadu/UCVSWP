using UCVSWP.Models;

namespace UCVSWP.Repositories.Interfaces
{
	public interface IGradeRepository
	{
		IEnumerable<Grade> GetAll();
		Grade GetById(int id);

		bool GradeExists(int id);
		void Create(Grade grade);
		void Update(Grade grade);
		void Delete(Grade grade);

		void Save();

	}
}
