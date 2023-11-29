using HobbyHarbor.Application.Commands;
using HobbyHarbor.Application.Interfaces;
using MediatR;

namespace HobbyHarbor.Application.Handlers.CommandHandlers
{
	public class UpdateUserPostReactionCommandHandler : IRequestHandler<UpdateUserPostReaction, int>
	{
		private readonly IHobbyHarborDbContext _context;

		public UpdateUserPostReactionCommandHandler(IHobbyHarborDbContext context)
		{
			_context = context;
		}

		public async Task<int> Handle(UpdateUserPostReaction request, CancellationToken cancellationToken)
		{
			bool exist = _context.PostsReactions.Any(x => x.UserId == request.PostsReaction.UserId
				&& x.PostId == request.PostsReaction.PostId);

			if (exist)
			{
				_context.PostsReactions.Update(request.PostsReaction);
			}
			else
			{
				_context.PostsReactions.Add(request.PostsReaction);
			}

			await _context.SaveChangesAsync(cancellationToken);

			return request.PostsReaction.PostId;
		}
	}
}
