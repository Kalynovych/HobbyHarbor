using HobbyHarbor.Core.Entities;
using MediatR;

namespace HobbyHarbor.Application.Queries
{
	public class GetPublicMessageById : IRequest<PublicMessage>
	{
		public int Id { get; set; }
	}
}
