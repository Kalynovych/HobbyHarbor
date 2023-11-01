using HobbyHarbor.Core.Entities;
using MediatR;

namespace HobbyHarbor.Application.Queries
{
	public class GetPostsByCreatorId : IRequest<ICollection<Post>>
	{
		public int Id { get; set; }

		public int Take { get; set; } = 1;

		public int Skip { get; set; }
	}
}
