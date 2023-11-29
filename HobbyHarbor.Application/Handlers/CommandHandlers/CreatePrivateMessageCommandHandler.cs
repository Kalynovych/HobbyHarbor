using HobbyHarbor.Application.Commands;
using HobbyHarbor.Application.Interfaces;
using HobbyHarbor.Core.Entities;
using MediatR;

namespace HobbyHarbor.Application.Handlers.CommandHandlers
{
	public class CreatePrivateMessageCommandHandler : IRequestHandler<CreatePrivateMessage, PrivateMessage>
	{
		private readonly IHobbyHarborDbContext _context;

		public CreatePrivateMessageCommandHandler(IHobbyHarborDbContext context)
		{
			_context = context;
		}

		public async Task<PrivateMessage> Handle(CreatePrivateMessage request, CancellationToken cancellationToken)
		{
			var privateMessage = await _context.PrivateMessages.AddAsync(request.Message);
			await _context.SaveChangesAsync(cancellationToken);

			return privateMessage.Entity;
		}
	}
}
