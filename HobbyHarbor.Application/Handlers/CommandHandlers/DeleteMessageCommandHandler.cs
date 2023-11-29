using HobbyHarbor.Application.Commands;
using HobbyHarbor.Application.Interfaces;
using MediatR;

namespace HobbyHarbor.Application.Handlers.CommandHandlers
{
	public class DeleteMessageCommandHandler : IRequestHandler<DeleteMessage, int>
	{
		private readonly IHobbyHarborDbContext _context;

		public DeleteMessageCommandHandler(IHobbyHarborDbContext context)
		{
			_context = context;
		}

		public async Task<int> Handle(DeleteMessage request, CancellationToken cancellationToken)
		{
			_context.Messages.Remove(request.Message);
			await _context.SaveChangesAsync(cancellationToken);

			return request.Message.Id;
		}
	}
}
