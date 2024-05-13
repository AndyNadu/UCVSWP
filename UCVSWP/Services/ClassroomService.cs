using UCVSWP.Models;
using UCVSWP.Repositories.Interfaces;
using UCVSWP.Services.Interfaces;

namespace UCVSWP.Services
{
	public class ClassroomService : IClassroomService
	{
		private readonly IClassroomRepository _classroomRepository;

		public ClassroomService(IClassroomRepository classroomRepository)
		{
			_classroomRepository = classroomRepository;
		}

		public void AddClassroom(Classroom classroom)
		{
			_classroomRepository.Create(classroom);
			_classroomRepository.Save();
		}

		public bool ClassroomExists(int id)
		{
			return _classroomRepository.ClassroomExists(id);
		}

		public void DeleteClassroom(int id)
		{
			var classroom = _classroomRepository.GetById(id);
			if (classroom != null)
			{
				_classroomRepository.Delete(classroom);
				_classroomRepository.Save();
			}
		}

		public List<Classroom> GetAllClassrooms()
		{
			return _classroomRepository.GetAll().ToList();
		}

		public Classroom GetClassroomById(int id)
		{
			return _classroomRepository.GetById(id);
		}

		public void UpdateClassroom(Classroom classroom)
		{
			_classroomRepository.Update(classroom);
			_classroomRepository.Save();
		}
	}
}
