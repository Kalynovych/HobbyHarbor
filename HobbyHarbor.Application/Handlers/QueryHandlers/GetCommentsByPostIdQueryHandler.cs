using HobbyHarbor.Application.Interfaces;
using HobbyHarbor.Application.Queries;
using HobbyHarbor.Core.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HobbyHarbor.Application.Handlers.QueryHandlers
{
	public class GetCommentsByPostIdQueryHandler : IRequestHandler<GetCommentsByPostId, IEnumerable<Comment>>
	{
		private readonly IHobbyHarborDbContext _context;

		public GetCommentsByPostIdQueryHandler(IHobbyHarborDbContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Comment>> Handle(GetCommentsByPostId request, CancellationToken cancellationToken)
		{
			IQueryable<Comment> query = _context.Comments.Where(x => x.PostId == request.Id).Include(x => x.Author).ThenInclude(x => x.Profile).ThenInclude(x => x.Images)
				.Skip(request.Skip).Take(request.Take);
			return await query.ToListAsync();
		}
	}
}
