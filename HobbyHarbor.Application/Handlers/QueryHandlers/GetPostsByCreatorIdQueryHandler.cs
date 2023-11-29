using HobbyHarbor.Application.Interfaces;
using HobbyHarbor.Application.Queries;
using HobbyHarbor.Core.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HobbyHarbor.Application.Handlers.QueryHandlers
{
	public class GetPostsByCreatorIdQueryHandler : IRequestHandler<GetPostsByCreatorId, ICollection<Post>>
	{
		private readonly IHobbyHarborDbContext _context;

		public GetPostsByCreatorIdQueryHandler(IHobbyHarborDbContext context)
		{
			_context = context;
		}

		public async Task<ICollection<Post>> Handle(GetPostsByCreatorId request, CancellationToken cancellationToken)
		{
			if (request.Skip < 0) request.Skip = 0;

			IQueryable<Post> query = _context.Posts.Where(x => x.CreatorId == request.Id)
				.Include(x => x.Creator).ThenInclude(x => x.Profile).ThenInclude(x => x.Images)
				.Include(x => x.Reactions).Include(x => x.PostInterests).ThenInclude(x => x.Interest)
				.Include(x => x.Comments).OrderByDescending(x => x.PublicationTime)
				.Skip(request.Skip).Take(request.Take);

			return await query.ToListAsync();
		}
	}
}
