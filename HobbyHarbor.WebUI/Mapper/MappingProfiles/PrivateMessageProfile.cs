using System.Diagnostics.Contracts;
using HobbyHarbor.Core.Entities;
using HobbyHarbor.WebUI.Models;

namespace HobbyHarbor.WebUI.Mapper.MappingProfiles
{
	public class PrivateMessageProfile : MessageProfile
	{
		public PrivateMessageProfile()
		{
			CreateMap<PrivateMessage, PrivateMessageViewModel>();
		}
	}
}
