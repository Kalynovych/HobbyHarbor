using HobbyHarbor.Application.Commands;
using HobbyHarbor.Application.Interfaces;
using HobbyHarbor.Core.Entities;
using MediatR;

namespace HobbyHarbor.Application.Handlers.CommandHandlers
{
	public class CreatePrivateChatCommandHandler : IRequestHandler<CreatePrivateChat, PrivateChat>
	{
		private readonly IHobbyHarborDbContext _context;

		public CreatePrivateChatCommandHandler(IHobbyHarborDbContext context)
		{
			_context = context;
		}

		public async Task<PrivateChat> Handle(CreatePrivateChat request, CancellationToken cancellationToken)
		{
			var privateChat = await _context.PrivateChats.AddAsync(request.PrivateChat);
			await _context.SaveChangesAsync(cancellationToken);

			return privateChat.Entity;
		}
	}
}
