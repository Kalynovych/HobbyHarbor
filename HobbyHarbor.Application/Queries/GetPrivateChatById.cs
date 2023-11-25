using HobbyHarbor.Core.Entities;
using MediatR;

namespace HobbyHarbor.Application.Queries
{
	public class GetPrivateChatById : IRequest<PrivateChat>
	{
		public int CreatorId { get; set; }

		public int CompanionId { get; set; }
	}
}
