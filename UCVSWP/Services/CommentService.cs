using UCVSWP.Models;
using UCVSWP.Repositories;
using UCVSWP.Repositories.Interfaces;
using UCVSWP.Services.Interfaces;

namespace UCVSWP.Services
{
	public class CommentService : ICommentService
	{
		private readonly ICommentRepository _commentRepository;

		public CommentService(ICommentRepository commentRepository)
		{
			_commentRepository = commentRepository;
		}
		public void AddComment(Comment comment)
		{
			_commentRepository.Create(comment);
			_commentRepository.Save();
		}

		public bool CommentExists(int id)
		{
			return _commentRepository.CommentExists(id);
		}

		public void DeleteComment(int id)
		{
			var comment = _commentRepository.GetById(id);
			if (comment != null)
			{
				_commentRepository.Delete(comment);
				_commentRepository.Save();
			}
		}

		public List<Assignment> GetAllAssignments()
		{
			return _commentRepository.GetAllAssignments();
		}

		public List<Comment> GetAllComments()
		{
			return _commentRepository.GetAll().ToList();
		}

		public Comment GetCommentAndRelatedById(int id)
		{
			return _commentRepository.GetByIdWithRelatedEntities(id);
		}

		public Comment GetCommentById(int id)
		{
			return _commentRepository.GetById(id);
		}

		public void UpdateComment(Comment comment)
		{
			_commentRepository.Update(comment);
			_commentRepository.Save();
		}
	}
}
