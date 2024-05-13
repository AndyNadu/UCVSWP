using Microsoft.EntityFrameworkCore;
using UCVSWP.Data;
using UCVSWP.Models;
using UCVSWP.Repositories.Interfaces;

namespace UCVSWP.Repositories
{
	public class AssignmentRepository : IAssignmentRepository
	{
		private readonly UCVSWPContext _context;

		public AssignmentRepository(UCVSWPContext context)
		{
			_context = context;
		}

		public bool AssignmentExists(int id)
		{
			return _context.Assignment.Any(o => o.AssignmentID == id);
		}

		public void Create(Assignment assignment)
		{
			_context.Assignment.Add(assignment);
		}

		public void Delete(Assignment assignment)
		{
			_context.Remove(assignment);
		}

		public IEnumerable<Assignment> GetAll()
		{
			return _context.Assignment.Include(o => o.Classroom);
		}

		public List<Classroom> GetAllClassrooms()
		{
			return _context.Classroom.ToList();
		}

		public Assignment GetById(int id)
		{
			return _context.Assignment.Find(id);
		}

		public Assignment GetByIdWithRelatedEntities(int id)
		{
			return _context.Assignment.Include(o => o.Classroom).FirstOrDefault(o => o.AssignmentID == id);
		}

		public void Save()
		{
			 _context.SaveChanges();
		}

		public void Update(Assignment assignment)
		{
			_context.Update(assignment);
		}
	}
}
