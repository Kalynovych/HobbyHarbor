using HobbyHarbor.Application.Interfaces;
using HobbyHarbor.Application.Queries;
using HobbyHarbor.Core.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HobbyHarbor.Application.Handlers.QueryHandlers
{
	public class GetFullUserByIdQueryHandler : IRequestHandler<GetFullUserById, User>
	{
		IHobbyHarborDbContext _context;

		public GetFullUserByIdQueryHandler(IHobbyHarborDbContext context)
		{
			_context = context;
		}

		public async Task<User> Handle(GetFullUserById request, CancellationToken cancellationToken)
		{
			IQueryable<User> query = _context.Users.Where(x => x.Id == request.Id).Include(x => x.UserInterests).Include(x => x.PublicChats).Include(x => x.PrivateChats)
				.Include(x => x.Posts).ThenInclude(x => x.Comments).Include(x => x.Profile).ThenInclude(x => x.Images).Include(x => x.Choices).ThenInclude(x => x.Target).Include(x => x.Messages);
			return await Task.FromResult(query.First());
		}
	}
}
