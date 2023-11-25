using HobbyHarbor.Application.DTOs;
using HobbyHarbor.WebUI.Models;

namespace HobbyHarbor.WebUI.Mapper.MappingProfiles
{
    public class MessageProfile : AutoMapper.Profile
	{
		public MessageProfile()
		{
			CreateMap<MessageDTO, MessageViewModel>()
				.ForMember(dist => dist.Time, opt => opt.MapFrom(src => src.Time.ToShortTimeString()));
			CreateMap<MessageViewModel, MessageDTO>();
		}
	}
}
