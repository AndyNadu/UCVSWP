using UCVSWP.Models;
using UCVSWP.Repositories.Interfaces;
using UCVSWP.Services.Interfaces;

namespace UCVSWP.Services
{
	public class GradeAssignmentService : IGradeAssignmentService
	{
		private readonly IGradeAssignmentRepository _gradeAssignmentRepository;
		public GradeAssignmentService(IGradeAssignmentRepository gradeAssignmentRepository)
		{
			_gradeAssignmentRepository = gradeAssignmentRepository;
		}

		public void AddGradeAssignment(GradeAssignment gradeAssignment)
		{
			_gradeAssignmentRepository.Create(gradeAssignment);
			_gradeAssignmentRepository.Save();
		}

		public void DeleteGradeAssignment(int id)
		{
			var gradeAssignment = _gradeAssignmentRepository.GetById(id);
			if (gradeAssignment != null)
			{
				_gradeAssignmentRepository.Delete(gradeAssignment);
				_gradeAssignmentRepository.Save();
			}
		}

		public List<Assignment> GetAllAssignments()
		{
			return _gradeAssignmentRepository.GetAllAssignments();
		}

		public List<Grade> GetAllGrades()
		{
			return _gradeAssignmentRepository.GetAllGrades();
		}

		public List<GradeAssignment> GetAllGradeAssignmnets()
		{
			return _gradeAssignmentRepository.GetAll().ToList();
		}

		public GradeAssignment GetGradeAssignmentAndRelatedById(int id)
		{
			return _gradeAssignmentRepository.GetByIdWithRelatedEntities(id);
		}

		public GradeAssignment GetGradeAssignmentById(int id)
		{
			 return _gradeAssignmentRepository.GetById(id); 
		}

		public bool GradeAssignmentExists(int id)
		{
			return _gradeAssignmentRepository.GradeAssignmentExists(id);
		}

		public void UpdateGradeAssignment(GradeAssignment gradeAssignment)
		{
			_gradeAssignmentRepository.Update(gradeAssignment);
			_gradeAssignmentRepository.Save();
		}

		public List<GradeAssignment> GetAllGradeAssignments()
		{
			throw new NotImplementedException();
		}
	}
}
