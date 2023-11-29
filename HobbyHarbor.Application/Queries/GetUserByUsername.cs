using HobbyHarbor.Core.Entities;
using MediatR;

namespace HobbyHarbor.Application.Queries
{
	public class GetUserByUsername : IRequest<User>
	{
		public string Username { get; set; }
	}
}
