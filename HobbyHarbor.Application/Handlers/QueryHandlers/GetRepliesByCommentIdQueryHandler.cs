using HobbyHarbor.Application.Interfaces;
using HobbyHarbor.Application.Queries;
using HobbyHarbor.Core.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HobbyHarbor.Application.Handlers.QueryHandlers
{
	public class GetRepliesByCommentIdQueryHandler : IRequestHandler<GetRepliesByCommentId, ICollection<Comment>>
	{
		private readonly IHobbyHarborDbContext _context;

		public GetRepliesByCommentIdQueryHandler(IHobbyHarborDbContext context)
		{
			_context = context;
		}

		public async Task<ICollection<Comment>> Handle(GetRepliesByCommentId request, CancellationToken cancellationToken)
		{
			var replyToRequested = _context.Comments.Where(x => x.ReplyCommentId == request.Id).Select(x => new { x.Id, x.ReplyCommentId }).AsNoTracking().ToList();
			var allReplies = _context.Comments.Where(x => x.ReplyCommentId != null).Select(x => new { x.Id, x.ReplyCommentId }).AsNoTracking().ToList();
			List<int> nestedIds = replyToRequested.Select(x => x.Id).ToList();
			
			GetHierarchy(replyToRequested, allReplies, nestedIds);
			IQueryable<Comment> query = _context.Comments.Where(x => nestedIds.Contains(x.Id)).Include(x => x.Author).ThenInclude(x => x.Profile).ThenInclude(x => x.Images)
				.Include(x => x.ReplyTo).OrderBy(x => x.Time);
			return await query.ToListAsync();
		}

		private void GetHierarchy(IEnumerable<dynamic> replyToRequested, IEnumerable<dynamic> allComments, List<int> nestedIds)
		{
			var replies = allComments.Where(x => replyToRequested.Any(y => y.Id == x.ReplyCommentId));
			if (replies.Any())
			{
				nestedIds.AddRange(replies.Select(x => (int)x.Id));
				GetHierarchy(replies, allComments, nestedIds);
			}
		}
	}
}
