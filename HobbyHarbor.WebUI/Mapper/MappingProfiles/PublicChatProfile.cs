using HobbyHarbor.Application.DTOs;
using HobbyHarbor.WebUI.Models;

namespace HobbyHarbor.WebUI.Mapper.MappingProfiles
{
	public class PublicChatProfile : AutoMapper.Profile
	{
		public PublicChatProfile()
		{
			CreateMap<PublicChatDTO, PublicChatViewModel>();
		}
	}
}
