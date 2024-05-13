using UCVSWP.Models;
using UCVSWP.Repositories.Interfaces;
using UCVSWP.Services.Interfaces;

namespace UCVSWP.Services
{
	public class GradeService : IGradeService
	{
		private readonly IGradeRepository _gradeRepository;

		public GradeService(IGradeRepository gradeRepository)
		{
			_gradeRepository = gradeRepository;
		}

		public void AddGrade(Grade grade)
		{
			_gradeRepository.Create(grade);
			_gradeRepository.Save();
		}

		public void DeleteGrade(int id)
		{
			var grade = _gradeRepository.GetById(id);
			if (grade != null)
			{
				_gradeRepository.Delete(grade);
				_gradeRepository.Save();
			}
		}

		public List<Grade> GetAllGrades()
		{
			return _gradeRepository.GetAll().ToList();
		}

		public Grade GetGradeById(int id)
		{
			return _gradeRepository.GetById(id);
		}

		public bool GradeExists(int id)
		{
			return _gradeRepository.GradeExists(id);
		}

		public void UpdateGrade(Grade grade)
		{
			_gradeRepository.Update(grade);
			_gradeRepository.Save();
		}
	}
}
