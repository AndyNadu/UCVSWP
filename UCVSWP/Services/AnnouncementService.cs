using UCVSWP.Models;
using UCVSWP.Repositories.Interfaces;
using UCVSWP.Services.Interfaces;

namespace UCVSWP.Services
{
	public class AnnouncementService : IAnnouncementService
	{
		private readonly IAnnouncementRepository _announcementRepository;

		public AnnouncementService(IAnnouncementRepository announcementRepository)
		{
			_announcementRepository = announcementRepository;
		}

		public void AddAnnouncement(Announcement announcement)
		{
			_announcementRepository.Create(announcement);
			_announcementRepository.Save();
		}

		public bool AnnouncementExists(int id)
		{
			return _announcementRepository.AnnouncementExists(id);
		}

		public void DeleteAnnouncement(int id)
		{
			var announcement = _announcementRepository.GetById(id);
			if (announcement != null)
			{
				_announcementRepository.Delete(announcement);
				_announcementRepository.Save();
			}
		}

		public List<Announcement> GetAllAnnouncements()
		{
			return _announcementRepository.GetAll().ToList();
		}

		public List<Classroom> GetAllClassrooms()
		{
			return _announcementRepository.GetAllClassrooms();
		}

		public Announcement GetAnnouncementAndRelatedById(int id)
		{
			return _announcementRepository.GetByIdWithRelatedEntities(id);
		}

		public Announcement GetAnnouncementById(int id)
		{
			return _announcementRepository.GetById(id);
		}

		public void UpdateAnnouncement(Announcement announcement)
		{
			_announcementRepository.Update(announcement);
			_announcementRepository.Save();
		}
	}
}
