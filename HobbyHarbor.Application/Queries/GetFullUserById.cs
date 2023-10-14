using HobbyHarbor.Core.Entities;
using MediatR;

namespace HobbyHarbor.Application.Queries
{
	public class GetFullUserById : IRequest<User>
	{
		public int Id { get; set; }
	}
}
