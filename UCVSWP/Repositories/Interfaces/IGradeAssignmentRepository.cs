using UCVSWP.Models;

namespace UCVSWP.Repositories.Interfaces
{
	public interface IGradeAssignmentRepository
	{
		IEnumerable<GradeAssignment> GetAll();
		GradeAssignment GetByIdWithRelatedEntities(int id);

		GradeAssignment GetById(int id);
		bool GradeAssignmentExists(int id);
		void Create(GradeAssignment gradeAssignment);
		void Update(GradeAssignment gradeAssignment);
		void Delete(GradeAssignment gradeAssignment);

		void Save();
		List<Assignment> GetAllAssignments();
		List<Grade> GetAllGrades();
	}
}
