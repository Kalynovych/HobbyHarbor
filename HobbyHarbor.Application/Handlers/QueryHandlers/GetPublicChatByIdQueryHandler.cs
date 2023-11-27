using HobbyHarbor.Application.Interfaces;
using HobbyHarbor.Application.Queries;
using HobbyHarbor.Core.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HobbyHarbor.Application.Handlers.QueryHandlers
{
	public class GetPublicChatByIdQueryHandler : IRequestHandler<GetPublicChatById, PublicChat>
	{
		private readonly IHobbyHarborDbContext _context;

		public GetPublicChatByIdQueryHandler(IHobbyHarborDbContext context)
		{
			_context = context;
		}

		public async Task<PublicChat> Handle(GetPublicChatById request, CancellationToken cancellationToken)
		{
			IQueryable<PublicChat> query = _context.PublicChats.Where(x => x.Id == request.Id)
				.Include(x => x.Messages).ThenInclude(x => x.MessageAuthor)
				.Include(x => x.Participants).ThenInclude(x => x.User);

			return await query.FirstOrDefaultAsync();
		}
	}
}
