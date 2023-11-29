using HobbyHarbor.Application.DTOs;
using HobbyHarbor.Core.Entities;

namespace HobbyHarbor.Application.Mapper.MappingProfiles
{
    public class PrivateMessageProfile : MessageProfile
	{
		public PrivateMessageProfile()
		{
			CreateMap<PrivateMessage, PrivateMessageDTO>()
				.IncludeBase<Message, MessageDTO>()
				.ForMember(dest => dest.CompanionUsername, opt => opt.MapFrom(src => src.PrivateChat.Companion.Username));
			CreateMap<PrivateMessageDTO, PrivateMessage>();
		}
	}
}
