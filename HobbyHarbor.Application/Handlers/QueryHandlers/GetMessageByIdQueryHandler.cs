using HobbyHarbor.Application.Interfaces;
using HobbyHarbor.Application.Queries;
using HobbyHarbor.Core.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HobbyHarbor.Application.Handlers.QueryHandlers
{
	public class GetMessageByIdQueryHandler : IRequestHandler<GetMessageById, Message>
	{
		private readonly IHobbyHarborDbContext _context;

		public GetMessageByIdQueryHandler(IHobbyHarborDbContext context)
		{
			_context = context;
		}

		public async Task<Message> Handle(GetMessageById request, CancellationToken cancellationToken)
		{
			IQueryable<Message> query = _context.Messages.Where(x => x.Id == request.Id)
				.Include(x => x.MessageAuthor).ThenInclude(x => x.Profile).ThenInclude(x => x.Images)
				.Include(x => x.ReplyTo)
				.Include(x => x.Replies)
				.Include(x => x.AttachmentType);

			return await query.FirstOrDefaultAsync(cancellationToken);
		}
	}
}
