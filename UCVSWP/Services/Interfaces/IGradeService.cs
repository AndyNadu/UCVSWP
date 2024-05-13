using UCVSWP.Models;

namespace UCVSWP.Services.Interfaces
{
	public interface IGradeService
	{
		List<Grade> GetAllGrades();
		Grade GetGradeById(int id);
		bool GradeExists(int id);
		void AddGrade(Grade grade);
		void UpdateGrade(Grade grade);
		void DeleteGrade(int id);
	}
}
