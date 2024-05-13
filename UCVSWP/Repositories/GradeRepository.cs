using UCVSWP.Data;
using UCVSWP.Models;
using UCVSWP.Repositories.Interfaces;

namespace UCVSWP.Repositories
{
	public class GradeRepository : IGradeRepository
	{
		private readonly UCVSWPContext _context;
		public GradeRepository(UCVSWPContext context)
		{
			_context = context;
		}

		public void Create(Grade grade)
		{
			_context.Grade.Add(grade);
		}

		public void Delete(Grade grade)
		{
			_context.Grade.Remove(grade);

		}

		public IEnumerable<Grade> GetAll()
		{
			return _context.Grade.ToList();
		}

		public Grade GetById(int id)
		{
			return _context.Grade.FirstOrDefault(c => c.GradeID == id);
		}

		public bool GradeExists(int id)
		{
			return _context.Grade.Any(c => c.GradeID == id);
		}

		public void Save()
		{
			_context.SaveChanges();
		}

		public void Update(Grade grade)
		{
			_context.Update(grade);
		}
	}
}
