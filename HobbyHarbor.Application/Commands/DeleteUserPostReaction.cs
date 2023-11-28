using HobbyHarbor.Core.Entities;
using MediatR;

namespace HobbyHarbor.Application.Commands
{
	public class DeleteUserPostReaction : IRequest<int>
	{
		public PostsReaction PostsReaction { get; set; }
	}
}
