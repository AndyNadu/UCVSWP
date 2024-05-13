using Microsoft.EntityFrameworkCore;
using UCVSWP.Data;
using UCVSWP.Models;
using UCVSWP.Repositories.Interfaces;

namespace UCVSWP.Repositories
{
	public class ClassroomRepository : IClassroomRepository
	{
		private readonly UCVSWPContext _context;
		public ClassroomRepository(UCVSWPContext context)
		{
			_context = context;
		}

		public bool ClassroomExists(int id)
		{
			return _context.Classroom.Any(c => c.ClassroomID == id);
		}

		public void Create(Classroom classroom)
		{
			_context.Classroom.Add(classroom);
		}

		public void Delete(Classroom classroom)
		{
			_context.Remove(classroom);
		}

		public IEnumerable<Classroom> GetAll()
		{
			return _context.Classroom.ToList();
		}

        public Classroom GetById(int id)
        {
            return _context.Classroom
                .Include(c => c.Assignments) // Include sarcinile asociate cu clasa
                .Include(c => c.Announcements)  // Include anunțurile asociate cu clasa
                .FirstOrDefault(c => c.ClassroomID == id);
        }


        public void Save()
		{
			_context.SaveChanges();
		}

		public void Update(Classroom classroom)
		{
			_context.Update(classroom);
		}
	}
}
