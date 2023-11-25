using HobbyHarbor.Core.Entities;
using MediatR;

namespace HobbyHarbor.Application.Commands
{
	public class UpdateMessage : IRequest<int>
	{
		public Message Message { get; set; }
	}
}
