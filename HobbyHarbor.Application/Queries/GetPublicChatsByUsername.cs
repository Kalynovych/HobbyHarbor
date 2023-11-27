using HobbyHarbor.Core.Entities;
using MediatR;

namespace HobbyHarbor.Application.Queries
{
	public class GetPublicChatsByUsername : IRequest<ICollection<PublicChat>>
	{
		public string Username { get; set; }
	}
}
