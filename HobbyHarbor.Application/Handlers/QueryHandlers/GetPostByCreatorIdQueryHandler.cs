using HobbyHarbor.Application.Interfaces;
using HobbyHarbor.Application.Queries;
using HobbyHarbor.Core.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HobbyHarbor.Application.Handlers.QueryHandlers
{
	public class GetPostByCreatorIdQueryHandler : IRequestHandler<GetPostByCreatorId, Post>
	{
		private readonly IHobbyHarborDbContext _context;

		public GetPostByCreatorIdQueryHandler(IHobbyHarborDbContext context)
		{
			_context = context;
		}

		public async Task<Post> Handle(GetPostByCreatorId request, CancellationToken cancellationToken)
		{
			IQueryable<Post> query = _context.Posts.Where(x => x.CreatorId == request.Id).Include(x => x.Creator).ThenInclude(x => x.Profile).ThenInclude(x => x.Images);
			return await query.FirstAsync();
		}
	}
}
