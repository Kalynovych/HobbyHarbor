using HobbyHarbor.Core.Entities;
using MediatR;

namespace HobbyHarbor.Application.Queries
{
	public class GetPublicMessagesById : IRequest<ICollection<PublicMessage>>
	{
		public int Id { get; set; }
	}
}
