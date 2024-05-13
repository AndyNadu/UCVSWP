using UCVSWP.Models;

namespace UCVSWP.Services.Interfaces
{
	public interface ICommentService
	{
		List<Comment> GetAllComments();
		Comment GetCommentAndRelatedById(int id);

		bool CommentExists(int id);
		void AddComment(Comment comment);
		void UpdateComment(Comment comment);
		void DeleteComment(int id);

		List<Assignment> GetAllAssignments();
		Comment GetCommentById(int id);
	}
}
