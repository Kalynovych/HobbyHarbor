using HobbyHarbor.Core.Entities;
using MediatR;

namespace HobbyHarbor.Application.Commands
{
	public class DeletePrivateChat : IRequest<(int, int)>
	{
		public PrivateChat PrivateChat { get; set; }
	}
}
