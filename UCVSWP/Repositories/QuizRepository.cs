using Microsoft.EntityFrameworkCore;
using UCVSWP.Data;
using UCVSWP.Models;
using UCVSWP.Repositories.Interfaces;

namespace UCVSWP.Repositories
{
	public class QuizRepository : IQuizRepository
	{
		private readonly UCVSWPContext _context;

		public QuizRepository(UCVSWPContext context)
		{
			_context = context;

		}
		public void Create(Quiz quiz)
		{
			_context.Quiz.Add(quiz);
		}

		public void Delete(Quiz quiz)
		{
			_context.Remove(quiz);
		}

		public IEnumerable<Quiz> GetAll()
		{
			return _context.Quiz.Include(p => p.Classroom).ToList();
		}

		public List<Classroom> GetAllCategories()
		{
			return _context.Classroom.ToList();
		}

		public List<Classroom> GetAllClassrooms()
		{
			throw new NotImplementedException();
		}

		public Quiz GetById(int id)
		{
			return _context.Quiz.Find(id);
		}

		public Quiz GetByIdWithRelatedEntities(int id)
		{
			return _context.Quiz.Include(p => p.Classroom).FirstOrDefault(p => p.QuizID == id);
		}

		public bool QuizExists(int id)
		{
			return _context.Quiz.Any(c => c.QuizID == id);
		}

		public void Save()
		{
			_context.SaveChanges();
		}

		public void Update(Quiz quiz)
		{
			_context.Update(quiz);
		}
	}
}
