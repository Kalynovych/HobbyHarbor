using HobbyHarbor.Application.Interfaces;
using HobbyHarbor.Application.Queries;
using HobbyHarbor.Core.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HobbyHarbor.Application.Handlers.QueryHandlers
{
	public class GetPrivateMessageByMessageIdQueryHandler : IRequestHandler<GetPrivateMessageByMessageId, PrivateMessage>
	{
		private readonly IHobbyHarborDbContext _context;

		public GetPrivateMessageByMessageIdQueryHandler(IHobbyHarborDbContext context)
		{
			_context = context;
		}

		public async Task<PrivateMessage> Handle(GetPrivateMessageByMessageId request, CancellationToken cancellationToken)
		{
			IQueryable<PrivateMessage> query = _context.PrivateMessages.Where(x => x.Id == request.Id)
				.Include(x => x.MessageAuthor).ThenInclude(x => x.Profile).ThenInclude(x => x.Images)
				.Include(x => x.PrivateChat).ThenInclude(x => x.Companion)
				.Include(x => x.ReplyTo)
				.Include(x => x.Replies)
				.Include(x => x.AttachmentType);

			return await query.FirstOrDefaultAsync(cancellationToken);
		}
	}
}
