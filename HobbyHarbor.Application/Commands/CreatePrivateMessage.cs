using HobbyHarbor.Core.Entities;
using MediatR;

namespace HobbyHarbor.Application.Commands
{
	public class CreatePrivateMessage : IRequest<PrivateMessage>
	{
		public PrivateMessage Message { get; set; }
	}
}
