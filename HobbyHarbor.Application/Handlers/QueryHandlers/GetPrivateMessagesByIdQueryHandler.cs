using HobbyHarbor.Application.Interfaces;
using HobbyHarbor.Application.Queries;
using HobbyHarbor.Core.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HobbyHarbor.Application.Handlers.QueryHandlers
{
	public class GetPrivateMessagesByIdQueryHandler : IRequestHandler<GetPrivateMessagesById, ICollection<PrivateMessage>>
	{
		private readonly IHobbyHarborDbContext _context;

		public GetPrivateMessagesByIdQueryHandler(IHobbyHarborDbContext context)
		{
			_context = context;
		}

		public async Task<ICollection<PrivateMessage>> Handle(GetPrivateMessagesById request, CancellationToken cancellationToken)
		{
			IQueryable<PrivateMessage> query = _context.PrivateMessages.Where(x => x.CreatorId == request.CreatorId && x.CompanionId == request.CompanionId)
				.Include(x => x.MessageAuthor).ThenInclude(x => x.Profile).ThenInclude(x => x.Images)
				.Include(x => x.ReplyTo)
				.Include(x => x.AttachmentType)
				.OrderBy(x => x.Time);

			return await query.ToListAsync();
		}
	}
}
