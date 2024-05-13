using UCVSWP.Models;

namespace UCVSWP.Repositories.Interfaces
{
	public interface IAssignmentRepository
	{
		IEnumerable<Assignment> GetAll();
		Assignment GetByIdWithRelatedEntities(int id);

		Assignment GetById(int id);
		bool AssignmentExists(int id);
		void Create(Assignment assignment);
		void Update(Assignment assignment);
		void Delete(Assignment assignment);

		void Save();

		List<Classroom> GetAllClassrooms();
	}
}
