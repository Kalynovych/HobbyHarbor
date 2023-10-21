using HobbyHarbor.Application.Interfaces;
using HobbyHarbor.Application.Queries;
using HobbyHarbor.Core.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HobbyHarbor.Application.Handlers.QueryHandlers
{
	public class GetUserByIdQueryHandler : IRequestHandler<GetUserById, User>
	{
		private readonly IHobbyHarborDbContext _context;

		public GetUserByIdQueryHandler(IHobbyHarborDbContext context)
		{
			_context = context;
		}

		public async Task<User> Handle(GetUserById request, CancellationToken cancellationToken)
		{
			IQueryable<User> query = _context.Users.Where(x => x.Id == request.Id).Include(x => x.UserInterests).ThenInclude(x => x.Interest).Include(x => x.PublicChats).Include(x => x.PrivateChats);
			return await query.FirstAsync();
		}
	}
}
