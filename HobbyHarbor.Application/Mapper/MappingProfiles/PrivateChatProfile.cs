using HobbyHarbor.Application.DTOs;
using HobbyHarbor.Application.Mapper.ValueConverters;
using HobbyHarbor.Core.Entities;

namespace HobbyHarbor.Application.Mapper.MappingProfiles
{
    public class PrivateChatProfile : AutoMapper.Profile
	{
		public PrivateChatProfile()
		{
			CreateMap<PrivateChat, PrivateChatDTO>()
				.ForMember(dist => dist.CompanionUsername, opt => opt.MapFrom(src => src.Companion.Username))
				.ForMember(dist => dist.CompanionName, opt => opt.ConvertUsing<FullNameValueConverter, Profile>(src => src.Companion.Profile))
				.ForMember(dist => dist.CompanionProfileImage,
					opt => opt.ConvertUsing<FileToBase64ValueConverter, string>(src => src.Companion.Profile.Images.ElementAt(0).Image))
				.ForMember(dist => dist.LastMessageTime, opt => opt.MapFrom(src => src.Messages.LastOrDefault().Time))
				.ForMember(dist => dist.LastMessage, opt => opt.MapFrom(src => src.Messages.LastOrDefault().MessageText))
				.ForMember(dist => dist.LastMessageAuthor, opt => opt.MapFrom(src => src.Messages.LastOrDefault().MessageAuthor.Username));
		}
	}
}
