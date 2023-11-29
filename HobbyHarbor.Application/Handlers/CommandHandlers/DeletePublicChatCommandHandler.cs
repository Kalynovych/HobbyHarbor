using HobbyHarbor.Application.Commands;
using HobbyHarbor.Application.Interfaces;
using MediatR;

namespace HobbyHarbor.Application.Handlers.CommandHandlers
{
	public class DeletePublicChatCommandHandler : IRequestHandler<DeletePublicChat, int>
	{
		private readonly IHobbyHarborDbContext _context;

		public DeletePublicChatCommandHandler(IHobbyHarborDbContext context)
		{
			_context = context;
		}

		public async Task<int> Handle(DeletePublicChat request, CancellationToken cancellationToken)
		{
			_context.PublicChats.Remove(request.PublicChat);
			await _context.SaveChangesAsync(cancellationToken);

			return (request.PublicChat.Id);
		}
	}
}
