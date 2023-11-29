using HobbyHarbor.Core.Entities;
using MediatR;

namespace HobbyHarbor.Application.Queries
{
	public class GetPrivateChatsByUsername : IRequest<ICollection<PrivateChat>>
	{
		public string Username { get; set; }
	}
}
