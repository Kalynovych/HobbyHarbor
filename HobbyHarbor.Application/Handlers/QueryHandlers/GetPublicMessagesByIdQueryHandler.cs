﻿using HobbyHarbor.Application.Interfaces;
using HobbyHarbor.Application.Queries;
using HobbyHarbor.Core.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HobbyHarbor.Application.Handlers.QueryHandlers
{
	public class GetPublicMessagesByIdQueryHandler : IRequestHandler<GetPublicMessagesById, ICollection<PublicMessage>>
	{
		private readonly IHobbyHarborDbContext _context;

		public GetPublicMessagesByIdQueryHandler(IHobbyHarborDbContext context)
		{
			_context = context;
		}


		public async Task<ICollection<PublicMessage>> Handle(GetPublicMessagesById request, CancellationToken cancellationToken)
		{
			IQueryable<PublicMessage> query = _context.PublicMessages.Where(x => x.PublicChatId == request.Id)
				.Include(x => x.MessageAuthor).ThenInclude(x => x.Profile).ThenInclude(x => x.Images)
				.Include(x => x.ReplyTo)
				.Include(x => x.AttachmentType)
				.OrderBy(x => x.Time);

			return await query.ToListAsync();
		}
	}
}
