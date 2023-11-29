using HobbyHarbor.Application.Interfaces;
using HobbyHarbor.Application.Queries;
using HobbyHarbor.Core.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HobbyHarbor.Application.Handlers.QueryHandlers
{
	public class GetUserByUsernameQueryHandler : IRequestHandler<GetUserByUsername, User>
	{
		private readonly IHobbyHarborDbContext _context;

		public GetUserByUsernameQueryHandler(IHobbyHarborDbContext context)
		{
			_context = context;
		}

		public async Task<User> Handle(GetUserByUsername request, CancellationToken cancellationToken)
		{
			IQueryable<User> query = _context.Users.Where(x => x.Username == request.Username)
				.Include(x => x.Profile).ThenInclude(x => x.Images)
				.Include(x => x.UserInterests).ThenInclude(x => x.Interest)
				.Include(x => x.PublicChats).Include(x => x.PrivateChats);

			return await query.FirstOrDefaultAsync();
		}
	}
}
