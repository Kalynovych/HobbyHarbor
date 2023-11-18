using HobbyHarbor.Application.DTOs;
using HobbyHarbor.WebUI.Models;

namespace HobbyHarbor.Application.Mapper.MappingProfiles
{
    public class PrivateChatProfile : AutoMapper.Profile
	{
		public PrivateChatProfile()
		{
			CreateMap<PrivateChatDTO, PrivateChatViewModel>();
		}
	}
}
