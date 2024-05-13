using UCVSWP.Models;

namespace UCVSWP.Repositories.Interfaces
{
	public interface IClassroomRepository
	{
		IEnumerable<Classroom> GetAll();
		Classroom GetById(int id);

		bool ClassroomExists(int id);
		void Create(Classroom classroom);
		void Update(Classroom classroom);
		void Delete(Classroom classroom);

		void Save();

	}
}

