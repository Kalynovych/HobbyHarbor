using HobbyHarbor.Application.Interfaces;
using HobbyHarbor.Application.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HobbyHarbor.Application.Handlers.QueryHandlers
{
	public class GetUserPostReactionQueryHandler : IRequestHandler<GetUserPostReaction, bool?>
	{
		private readonly IHobbyHarborDbContext _context;

		public GetUserPostReactionQueryHandler(IHobbyHarborDbContext context)
		{
			_context = context;
		}

		public async Task<bool?> Handle(GetUserPostReaction request, CancellationToken cancellationToken)
		{
			//IQueryable<bool?> query = _context.Posts.Where(x => x.Id == request.Id).Where(x => x.Reactions.Where(x => x.User.Username == request.Username).);
			IQueryable<bool> query = _context.PostsReactions
				.Where(x => x.PostId == request.Id)
				.Where(x => x.User.Username == request.Username)
				.Select(x => x.IsLiked);

			return await query.FirstOrDefaultAsync();
		}
	}
}
