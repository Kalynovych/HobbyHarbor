using HobbyHarbor.Application.DTOs;
using HobbyHarbor.Core.Entities;

namespace HobbyHarbor.Application.Mapper.MappingProfiles
{
	public class PublicMessageProfile : MessageProfile
	{
		public PublicMessageProfile()
		{
			CreateMap<PublicMessage, PublicMessageDTO>()
				.IncludeBase<Message, MessageDTO>()
				.ForMember(dist => dist.Participants, opt => opt.MapFrom(src => src.PublicChat.Participants.Select(x => x.User.Username)));
			CreateMap<PublicMessageDTO, PublicMessage>();
		}
	}
}
