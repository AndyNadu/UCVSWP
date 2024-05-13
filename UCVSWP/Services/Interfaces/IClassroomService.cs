using UCVSWP.Models;

namespace UCVSWP.Services.Interfaces
{
	public interface IClassroomService
	{
		List<Classroom> GetAllClassrooms();
		Classroom GetClassroomById(int id);
		bool ClassroomExists(int id);
		void AddClassroom(Classroom classroom);
		void UpdateClassroom(Classroom classroom);
		void DeleteClassroom(int id);
	}
}
