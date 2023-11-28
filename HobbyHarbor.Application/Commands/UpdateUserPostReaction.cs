using HobbyHarbor.Core.Entities;
using MediatR;

namespace HobbyHarbor.Application.Commands
{
	public class UpdateUserPostReaction : IRequest<int>
	{
		public PostsReaction PostsReaction { get; set; }
	}
}
