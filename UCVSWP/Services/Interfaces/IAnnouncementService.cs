using UCVSWP.Models;

namespace UCVSWP.Services.Interfaces
{
	public interface IAnnouncementService
	{
		List<Announcement> GetAllAnnouncements();
		Announcement GetAnnouncementAndRelatedById(int id);

		bool AnnouncementExists(int id);
		void AddAnnouncement(Announcement announcement);
		void UpdateAnnouncement(Announcement announcement);
		void DeleteAnnouncement(int id);

		List<Classroom> GetAllClassrooms();
		Announcement GetAnnouncementById(int id);

	}
}
