using HobbyHarbor.Core.Entities;
using MediatR;

namespace HobbyHarbor.Application.Queries
{
	public class GetPrivateMessageByMessageId : IRequest<PrivateMessage>
	{
		public int Id { get; set; }
	}
}
