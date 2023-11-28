using HobbyHarbor.Application.Commands;
using HobbyHarbor.Application.Interfaces;
using MediatR;

namespace HobbyHarbor.Application.Handlers.CommandHandlers
{
	public class DeleteUserPostReactionCommandHandler : IRequestHandler<DeleteUserPostReaction, int>
	{
		private readonly IHobbyHarborDbContext _context;

		public DeleteUserPostReactionCommandHandler(IHobbyHarborDbContext context)
		{
			_context = context;
		}

		public async Task<int> Handle(DeleteUserPostReaction request, CancellationToken cancellationToken)
		{
			_context.PostsReactions.Remove(request.PostsReaction);
			await _context.SaveChangesAsync(cancellationToken);

			return request.PostsReaction.PostId;
		}
	}
}
