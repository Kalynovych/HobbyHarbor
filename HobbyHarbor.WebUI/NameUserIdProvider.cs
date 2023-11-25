using Microsoft.AspNetCore.SignalR;

namespace HobbyHarbor.WebUI
{
	public class NameUserIdProvider : IUserIdProvider
	{
		public string? GetUserId(HubConnectionContext connection)
		{
			return connection.User?.Claims.Where(x => x.Type == "name").Select(x => x.Value).FirstOrDefault();
		}
	}
}
