using HobbyHarbor.Core.Entities;
using MediatR;

namespace HobbyHarbor.Application.Queries
{
	public class GetRepliesByCommentId : IRequest<ICollection<Comment>>
	{
		public int Id { get; set; }
	}
}
