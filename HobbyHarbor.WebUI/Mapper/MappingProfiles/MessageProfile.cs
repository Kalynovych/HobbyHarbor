using HobbyHarbor.Application.DTOs;
using HobbyHarbor.WebUI.Models;

namespace HobbyHarbor.WebUI.Mapper.MappingProfiles
{
    public class MessageProfile : AutoMapper.Profile
	{
		public MessageProfile()
		{
			CreateMap<MessageDTO, MessageViewModel>();
		}
	}
}
