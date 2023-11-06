using HobbyHarbor.Core.Entities;
using MediatR;

namespace HobbyHarbor.Application.Commands
{
	public class CreateUser : IRequest<User>
	{
		public string UserName { get; set; }

		public string Email { get; set; }
	}
}
