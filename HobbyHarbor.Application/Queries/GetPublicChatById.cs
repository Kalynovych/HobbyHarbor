using HobbyHarbor.Core.Entities;
using MediatR;

namespace HobbyHarbor.Application.Queries
{
	public class GetPublicChatById : IRequest<PublicChat>
	{
		public int Id { get; set; }
	}
}
