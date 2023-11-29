using HobbyHarbor.Application.Commands;
using HobbyHarbor.Application.Interfaces;
using MediatR;

namespace HobbyHarbor.Application.Handlers.CommandHandlers
{
	public class DeletePrivateChatCommandHandler : IRequestHandler<DeletePrivateChat, (int, int)>
	{
		private readonly IHobbyHarborDbContext _context;

		public DeletePrivateChatCommandHandler(IHobbyHarborDbContext context)
		{
			_context = context;
		}

		public async Task<(int, int)> Handle(DeletePrivateChat request, CancellationToken cancellationToken)
		{
			_context.PrivateChats.Remove(request.PrivateChat);
			await _context.SaveChangesAsync(cancellationToken);

			return (request.PrivateChat.CreatorId, request.PrivateChat.CompanionId);
		}
	}
}
