using HobbyHarbor.Core.Entities;
using MediatR;

namespace HobbyHarbor.Application.Queries
{
	public class GetCommentsByPostId : IRequest<ICollection<Comment>>
	{
		public int Id { get; set; }

		public int Take { get; set; } = 1;

		public int Skip { get; set; }
	}
}
