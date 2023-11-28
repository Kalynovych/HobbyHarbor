using MediatR;

namespace HobbyHarbor.Application.Queries
{
	public class GetUserPostReaction : IRequest<bool?>
	{
		public int Id { get; set; }

		public string Username { get; set; }
	}
}
