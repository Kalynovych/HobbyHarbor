using HobbyHarbor.Application.Interfaces;
using HobbyHarbor.Application.Queries;
using HobbyHarbor.Core.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HobbyHarbor.Application.Handlers.QueryHandlers
{
	public class GetPrivateChatByIdQueryHandler : IRequestHandler<GetPrivateChatById, PrivateChat>
	{
		private readonly IHobbyHarborDbContext _context;

		public GetPrivateChatByIdQueryHandler(IHobbyHarborDbContext context)
		{
			_context = context;
		}

		public async Task<PrivateChat> Handle(GetPrivateChatById request, CancellationToken cancellationToken)
		{
			IQueryable<PrivateChat> query = _context.PrivateChats.Where(x => x.CreatorId == request.CreatorId && x.CompanionId == request.CompanionId)
				.Include(x => x.Companion).ThenInclude(x => x.Profile).ThenInclude(x => x.Images)
				.Include(x => x.Messages).ThenInclude(x => x.MessageAuthor)
				.OrderBy(x => x.CompanionId);

			return await query.FirstOrDefaultAsync();
		}
	}
}
