using MediatR;

namespace HobbyHarbor.Application.Queries
{
	public class GetReactions : IRequest<(int, int)>
	{
		public int PostId { get; set; }
	}
}
