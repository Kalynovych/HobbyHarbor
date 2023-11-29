using HobbyHarbor.Core.Entities;
using MediatR;

namespace HobbyHarbor.Application.Commands
{
	public class CreatePrivateChat : IRequest<PrivateChat>
	{
		public PrivateChat PrivateChat { get; set; }
	}
}
