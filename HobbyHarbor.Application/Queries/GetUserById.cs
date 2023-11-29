using HobbyHarbor.Core.Entities;
using MediatR;

namespace HobbyHarbor.Application.Queries
{
	public class GetUserById : IRequest<User>
	{
		public int Id { get; set; }
	}
}
