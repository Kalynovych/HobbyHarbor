using HobbyHarbor.Application.Interfaces;
using HobbyHarbor.Application.Queries;
using HobbyHarbor.Core.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HobbyHarbor.Application.Handlers.QueryHandlers
{
	public class GetPrivateChatsByUsernameQueryHandler : IRequestHandler<GetPrivateChatsByUsername, ICollection<PrivateChat>>
	{
		IHobbyHarborDbContext _context;

		public GetPrivateChatsByUsernameQueryHandler(IHobbyHarborDbContext context)
		{
			_context = context;
		}

		public async Task<ICollection<PrivateChat>> Handle(GetPrivateChatsByUsername request, CancellationToken cancellationToken)
		{
			IQueryable<PrivateChat> query = _context.PrivateChats.Where(x => 
				x.Creator.Username == request.Username || x.Companion.Username == request.Username)
				.Include(x => x.Companion).ThenInclude(x => x.Profile).ThenInclude(x => x.Images)
				.Include(x => x.Messages).ThenInclude(x => x.MessageAuthor)
				.OrderBy(x => x.CompanionId);

			return await query.ToListAsync();
		}
	}
}
