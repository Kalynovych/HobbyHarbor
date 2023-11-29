using HobbyHarbor.Application.Interfaces;
using HobbyHarbor.Application.Queries;
using HobbyHarbor.Core.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HobbyHarbor.Application.Handlers.QueryHandlers
{
	public class GetPublicChatsByUsernameQueryHandler : IRequestHandler<GetPublicChatsByUsername, ICollection<PublicChat>>
	{
		IHobbyHarborDbContext _context;

		public GetPublicChatsByUsernameQueryHandler(IHobbyHarborDbContext context)
		{
			_context = context;
		}

		public async Task<ICollection<PublicChat>> Handle(GetPublicChatsByUsername request, CancellationToken cancellationToken)
		{
			IQueryable<PublicChat> query = _context.PublicChats.Where(x => x.Participants.Where(x => x.User.Username == request.Username).Any())
				.Include(x => x.Messages).ThenInclude(x => x.MessageAuthor).ThenInclude(x => x.Profile)
				.OrderBy(x => x.ChatTitle);

			return await query.ToListAsync();
		}
	}
}
