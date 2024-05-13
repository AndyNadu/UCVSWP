using UCVSWP.Models;

namespace UCVSWP.Services.Interfaces
{
	public interface IGradeAssignmentService
	{
		List<GradeAssignment> GetAllGradeAssignments();
		GradeAssignment GetGradeAssignmentAndRelatedById(int id);
		bool GradeAssignmentExists(int id);
		void AddGradeAssignment(GradeAssignment gradeAssignment);
		void UpdateGradeAssignment(GradeAssignment gradeAssignment);
		void DeleteGradeAssignment(int id);

		List<Assignment> GetAllAssignments();
		List<Grade> GetAllGrades();
		GradeAssignment GetGradeAssignmentById(int id);
	}
}
