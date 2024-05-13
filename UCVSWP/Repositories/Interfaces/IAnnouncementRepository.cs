using UCVSWP.Models;

namespace UCVSWP.Repositories.Interfaces
{
	public interface IAnnouncementRepository
	{
		IEnumerable<Announcement> GetAll();
		Announcement GetByIdWithRelatedEntities(int id);
		Announcement GetById(int id);

		bool AnnouncementExists(int id);
		void Create(Announcement announcement);
		void Update(Announcement announcement);
		void Delete(Announcement announcement);

		void Save();

		List<Classroom> GetAllClassrooms();

 	}
}
