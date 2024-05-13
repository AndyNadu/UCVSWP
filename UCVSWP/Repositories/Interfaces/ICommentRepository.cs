using UCVSWP.Models;

namespace UCVSWP.Repositories.Interfaces
{
	public interface ICommentRepository
	{
		IEnumerable<Comment> GetAll();
		Comment GetByIdWithRelatedEntities(int id);
		Comment GetById(int id);

		bool CommentExists(int id);
		void Create(Comment comment);
		void Update(Comment comment);
		void Delete(Comment comment);

		void Save();

		List<Assignment> GetAllAssignments();
	}
}
