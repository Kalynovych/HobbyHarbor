using HobbyHarbor.Application.Commands;
using HobbyHarbor.Application.Interfaces;
using HobbyHarbor.Core.Entities;
using MediatR;

namespace HobbyHarbor.Application.Handlers.CommandHandlers
{
	public class CreatePublicMessageCommandHandler : IRequestHandler<CreatePublicMessage, PublicMessage>
	{
		private readonly IHobbyHarborDbContext _context;

		public CreatePublicMessageCommandHandler(IHobbyHarborDbContext context)
		{
			_context = context;
		}

		public async Task<PublicMessage> Handle(CreatePublicMessage request, CancellationToken cancellationToken)
		{
			var publicMessage = await _context.PublicMessages.AddAsync(request.Message);
			await _context.SaveChangesAsync(cancellationToken);

			return publicMessage.Entity;
		}
	}
}
