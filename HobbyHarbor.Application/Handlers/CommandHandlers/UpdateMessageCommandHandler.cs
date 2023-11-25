using HobbyHarbor.Application.Commands;
using HobbyHarbor.Application.Interfaces;
using HobbyHarbor.Core.Entities;
using MediatR;

namespace HobbyHarbor.Application.Handlers.CommandHandlers
{
	public class UpdateMessageCommandHandler : IRequestHandler<UpdateMessage, int>
	{
		private readonly IHobbyHarborDbContext _context;

		public UpdateMessageCommandHandler(IHobbyHarborDbContext context)
		{
			_context = context;
		}

		public async Task<int> Handle(UpdateMessage request, CancellationToken cancellationToken)
		{
			_context.Messages.Update(request.Message);
			return await _context.SaveChangesAsync(cancellationToken);
		}
	}
}
