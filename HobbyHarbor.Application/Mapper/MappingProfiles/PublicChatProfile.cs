using HobbyHarbor.Application.DTOs;
using HobbyHarbor.Application.Mapper.ValueConverters;
using HobbyHarbor.Core.Entities;

namespace HobbyHarbor.Application.Mapper.MappingProfiles
{
	public class PublicChatProfile : AutoMapper.Profile
	{
		public PublicChatProfile()
		{
			CreateMap<PublicChat, PublicChatDTO>()
				.ForMember(dist => dist.Interests, opt => opt.MapFrom(src => src.ChatInterests))
				.ForMember(dist => dist.ChatImage, opt => opt.ConvertUsing<FileToBase64ValueConverter, string>(src => src.ChatImage))
				.ForMember(dist => dist.LastMessageTime, opt => opt.MapFrom(src => src.Messages.LastOrDefault().Time))
				.ForMember(dist => dist.LastMessage, opt => opt.MapFrom(src => src.Messages.LastOrDefault().MessageText))
				.ForMember(dist => dist.LastMessageAuthor, opt => opt.MapFrom(src => src.Messages.LastOrDefault().MessageAuthor.Username))
				.ForMember(dist => dist.LastMessageAuthorName, 
					opt => opt.ConvertUsing<FullNameValueConverter, Profile>(src => src.Messages.LastOrDefault().MessageAuthor.Profile));
		}
	}
}
