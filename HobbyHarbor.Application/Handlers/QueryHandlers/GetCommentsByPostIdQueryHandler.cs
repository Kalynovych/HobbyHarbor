using HobbyHarbor.Application.Interfaces;
using HobbyHarbor.Application.Queries;
using HobbyHarbor.Core.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HobbyHarbor.Application.Handlers.QueryHandlers
{
	public class GetCommentsByPostIdQueryHandler : IRequestHandler<GetCommentsByPostId, ICollection<Comment>>
	{
		private readonly IHobbyHarborDbContext _context;

		public GetCommentsByPostIdQueryHandler(IHobbyHarborDbContext context)
		{
			_context = context;
		}

		public async Task<ICollection<Comment>> Handle(GetCommentsByPostId request, CancellationToken cancellationToken)
		{
			if (request.Skip < 0) request.Skip = 0;

			IQueryable<Comment> query = _context.Comments.Where(x => x.PostId == request.Id && x.ReplyCommentId == null).Include(x => x.Author).ThenInclude(x => x.Profile).ThenInclude(x => x.Images)
				.Include(x => x.Reactions).OrderByDescending(x => x.Time).Skip(request.Skip).Take(request.Take);
			return await query.ToListAsync();
		}
	}
}
