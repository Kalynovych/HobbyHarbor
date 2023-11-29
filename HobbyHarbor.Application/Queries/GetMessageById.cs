using HobbyHarbor.Core.Entities;
using MediatR;

namespace HobbyHarbor.Application.Queries
{
	public class GetMessageById : IRequest<Message>
	{
		public int? Id { get; set; }
	}
}
