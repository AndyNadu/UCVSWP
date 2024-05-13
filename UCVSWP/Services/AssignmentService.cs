using UCVSWP.Models;
using UCVSWP.Repositories.Interfaces;
using UCVSWP.Services.Interfaces;

namespace UCVSWP.Services
{
	public class AssignmentService : IAssignmentService
	{
		private readonly IAssignmentRepository _assignmentRepository;

		public AssignmentService(IAssignmentRepository assignmentRepository)
		{
			_assignmentRepository = assignmentRepository;
		}

		public void AddAssignment(Assignment assignment)
		{
			_assignmentRepository.Create(assignment);
			_assignmentRepository.Save();
		}

		public bool AssignmentExists(int id)
		{
			return _assignmentRepository.AssignmentExists(id);
		}

		public void DeleteAssignment(int id)
		{
			var assignment = _assignmentRepository.GetById(id);
			if (assignment != null)
			{
				_assignmentRepository.Delete(assignment);
				_assignmentRepository.Save();
			}
		}

		public List<Assignment> GetAllAssignments()
		{
			return _assignmentRepository.GetAll().ToList();
		}

		public List<Classroom> GetAllClassrooms()
		{
			return _assignmentRepository.GetAllClassrooms();
		}

		public Assignment GetAssignmentAndRelatedById(int id)
		{
			return _assignmentRepository.GetByIdWithRelatedEntities(id);
		}

		public Assignment GetAssignmentById(int id)
		{
			return _assignmentRepository.GetById(id);
		}

		public void UpdateAssignment(Assignment assignment)
		{
			_assignmentRepository.Update(assignment);
			_assignmentRepository.Save();
		}
	}
}
