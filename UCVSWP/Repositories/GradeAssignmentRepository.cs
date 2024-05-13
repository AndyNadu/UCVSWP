using Microsoft.EntityFrameworkCore;
using UCVSWP.Data;
using UCVSWP.Models;
using UCVSWP.Repositories.Interfaces;

namespace UCVSWP.Repositories
{
	public class GradeAssignmentRepository : IGradeAssignmentRepository
	{
		private readonly UCVSWPContext _context;

		public GradeAssignmentRepository(UCVSWPContext context)
		{
			_context = context;

		}
		public void Create(GradeAssignment gradeAssignment)
		{
			_context.GradeAssignment.Add(gradeAssignment);
		}

		public void Delete(GradeAssignment gradeAssignment)
		{
			_context.Remove(gradeAssignment);
		}

		public IEnumerable<GradeAssignment> GetAll()
		{
			return _context.GradeAssignment.Include(p => p.Assignment).Include(p => p.Grade).ToList();
		}

		public List<Assignment> GetAllAssignments()
		{
			return _context.Assignment.ToList();
		}

		public List<Grade> GetAllGrades()
		{
			return _context.Grade.ToList();
		}

		public GradeAssignment GetById(int id)
		{
			return _context.GradeAssignment.Find(id);
		}

		public GradeAssignment GetByIdWithRelatedEntities(int id)
		{
			return _context.GradeAssignment.Include(p => p.Assignment).Include(p => p.Grade).FirstOrDefault(p => p.GradeAssignmentID == id);
		}

		public bool GradeAssignmentExists(int id)
		{
			return _context.GradeAssignment.Any(c => c.GradeAssignmentID == id);
		}

		public void Save()
		{
			_context.SaveChanges();
		}

		public void Update(GradeAssignment gradeAssignment)
		{
			_context.Update(gradeAssignment);
		}
	}
}
