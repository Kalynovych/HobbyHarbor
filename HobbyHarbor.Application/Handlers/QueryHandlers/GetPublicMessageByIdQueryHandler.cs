using HobbyHarbor.Application.Interfaces;
using HobbyHarbor.Application.Queries;
using HobbyHarbor.Core.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HobbyHarbor.Application.Handlers.QueryHandlers
{
	public class GetPublicMessageByIdQueryHandler : IRequestHandler<GetPublicMessageById, PublicMessage>
	{
		private readonly IHobbyHarborDbContext _context;

		public GetPublicMessageByIdQueryHandler(IHobbyHarborDbContext context)
		{
			_context = context;
		}


		public async Task<PublicMessage> Handle(GetPublicMessageById request, CancellationToken cancellationToken)
		{
			IQueryable<PublicMessage> query = _context.PublicMessages.Where(x => x.Id == request.Id)
				.Include(x => x.MessageAuthor).ThenInclude(x => x.Profile).ThenInclude(x => x.Images)
				.Include(x => x.PublicChat).ThenInclude(x => x.Participants).ThenInclude(x => x.User)
				.Include(x => x.ReplyTo)
				.Include(x => x.Replies)
				.Include(x => x.AttachmentType)
				.OrderBy(x => x.Time);

			return await query.FirstOrDefaultAsync();
		}
	}
}
