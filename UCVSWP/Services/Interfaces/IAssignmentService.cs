using UCVSWP.Models;

namespace UCVSWP.Services.Interfaces
{
	public interface IAssignmentService
	{
		List<Assignment> GetAllAssignments();
		Assignment GetAssignmentAndRelatedById(int id);
		bool AssignmentExists(int id);
		void AddAssignment(Assignment assignment);
		void UpdateAssignment(Assignment assignment);
		void DeleteAssignment(int id);

		List<Classroom> GetAllClassrooms();

		Assignment GetAssignmentById(int id);
	}
}
