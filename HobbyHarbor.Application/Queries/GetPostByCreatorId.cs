using HobbyHarbor.Core.Entities;
using MediatR;

namespace HobbyHarbor.Application.Queries
{
	public class GetPostByCreatorId : IRequest<Post>
	{
		public int Id { get; set; }
	}
}
