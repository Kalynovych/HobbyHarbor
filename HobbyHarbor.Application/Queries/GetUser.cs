using HobbyHarbor.Core.Entities;
using MediatR;

namespace HobbyHarbor.Application.Queries
{
	public class GetUser : IRequest<User> 
	{
		public int Skip {  get; set; }

		public string Except { get; set; }
	}
}
