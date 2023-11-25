using HobbyHarbor.Core.Entities;
using MediatR;

namespace HobbyHarbor.Application.Queries
{
	public class GetPrivateMessagesById : IRequest<ICollection<PrivateMessage>>
	{
		public int CreatorId { get; set; }

		public int CompanionId { get; set; }
	}
}
