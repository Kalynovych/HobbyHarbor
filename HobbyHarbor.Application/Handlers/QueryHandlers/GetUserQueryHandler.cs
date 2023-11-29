using HobbyHarbor.Application.Interfaces;
using HobbyHarbor.Application.Queries;
using HobbyHarbor.Core.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HobbyHarbor.Application.Handlers.QueryHandlers
{
	public class GetUserQueryHandler : IRequestHandler<GetUser, User>
	{
		private readonly IHobbyHarborDbContext _context;

		public GetUserQueryHandler(IHobbyHarborDbContext context)
		{
			_context = context;
		}

		public async Task<User> Handle(GetUser request, CancellationToken cancellationToken)
		{
			IQueryable<User> query = _context.Users.Where(x => x.Username != request.Except)
				.Include(x => x.Profile).ThenInclude(x => x.Images)
				.Include(x => x.UserInterests).ThenInclude(x => x.Interest)
				.Skip(request.Skip);

			return await query.FirstOrDefaultAsync();
		}
	}
}
