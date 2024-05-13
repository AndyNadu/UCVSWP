using Microsoft.EntityFrameworkCore;
using UCVSWP.Data;
using UCVSWP.Models;
using UCVSWP.Repositories.Interfaces;

namespace UCVSWP.Repositories
{
	public class CommentRepository : ICommentRepository
	{
		private readonly UCVSWPContext _context;

		public CommentRepository(UCVSWPContext context)
		{
			_context = context;
		}
		public bool CommentExists(int id)
		{
			return _context.Comment.Any(c => c.CommentID == id);
		}

		public void Create(Comment comment)
		{
			_context.Comment.Add(comment);
		}

		public void Delete(Comment comment)
		{
			_context.Remove(comment);
		}

		public IEnumerable<Comment> GetAll()
		{
			return _context.Comment.Include(o => o.Assignement);
		}

		public List<Assignment> GetAllAssignments()
		{
			return _context.Assignment.ToList();
		}

		public Comment GetById(int id)
		{
			return _context.Comment.FirstOrDefault(c => c.AssignmentID == id);
		}

		public Comment GetByIdWithRelatedEntities(int id)
		{
			return _context.Comment.Include(o => o.Assignement).FirstOrDefault(o => o.AssignmentID == id);

		}

		public void Save()
		{
			_context.SaveChanges();
		}

		public void Update(Comment comment)
		{
			_context.Update(comment);
		}
	}
}
