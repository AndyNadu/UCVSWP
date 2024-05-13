using Microsoft.EntityFrameworkCore;
using UCVSWP.Data;
using UCVSWP.Models;
using UCVSWP.Repositories.Interfaces;

namespace UCVSWP.Repositories
{
	public class AnnouncementRepository : IAnnouncementRepository
	{
		private readonly UCVSWPContext _context;

		public AnnouncementRepository(UCVSWPContext context)
		{
			_context = context;
		}

		public bool AnnouncementExists(int id)
		{
			return _context.Announcement.Any(c => c.AnnouncementID == id);
		}

		public void Create(Announcement announcement)
		{
			_context.Announcement.Add(announcement);
		}

		public void Delete(Announcement announcement)
		{
			_context.Remove(announcement);
		}

		public IEnumerable<Announcement> GetAll()
		{
			return _context.Announcement.Include(o => o.Classroom);
		}

		public List<Classroom> GetAllClassrooms()
		{
			return _context.Classroom.ToList();
		}

		public Announcement GetById(int id)
		{
			return _context.Announcement.FirstOrDefault(c => c.AnnouncementID == id);
		}

		public Announcement GetByIdWithRelatedEntities(int id)
		{
			return _context.Announcement.Include(o => o.Classroom).FirstOrDefault(o => o.AnnouncementID == id);
		}

		public void Save()
		{
			_context.SaveChanges();
		}

		public void Update(Announcement announcement)
		{
			_context.Update(announcement);
		}
	}
}
