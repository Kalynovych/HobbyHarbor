using HobbyHarbor.Application.Interfaces;
using HobbyHarbor.Application.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HobbyHarbor.Application.Handlers.QueryHandlers
{
	public class GetReactionsQueryHandler : IRequestHandler<GetReactions, (int, int)>
	{
		private readonly IHobbyHarborDbContext _context;

		public GetReactionsQueryHandler(IHobbyHarborDbContext context)
		{
			_context = context;
		}

		public async Task<(int, int)> Handle(GetReactions request, CancellationToken cancellationToken)
		{
			IQueryable<bool> query = _context.PostsReactions.Where(x => x.PostId == request.PostId).Select(x => x.IsLiked);
			int likes = await query.Where(x => x).CountAsync();
			int dislikes = await query.Where(x => !x).CountAsync();

			return (likes, dislikes);
		}
	}
}
