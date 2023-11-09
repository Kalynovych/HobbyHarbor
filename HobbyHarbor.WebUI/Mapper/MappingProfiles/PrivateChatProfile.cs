using HobbyHarbor.Core.Entities;
using HobbyHarbor.WebUI.Mapper.ValueConverters;
using HobbyHarbor.WebUI.Models;

namespace HobbyHarbor.WebUI.Mapper.MappingProfiles
{
	public class PrivateChatProfile : AutoMapper.Profile
	{
		public PrivateChatProfile()
		{
			CreateMap<PrivateChat, PrivateChatViewModel>()
				.ForMember(dist => dist.CompanionName, opt => opt.ConvertUsing<FullNameValueConverter, Profile>(src => src.Companion.Profile))
				.ForMember(dist => dist.CompanionProfileImage,
					opt => opt.ConvertUsing<FileToBase64ValueConverter, string>(src => src.Companion.Profile.Images.ElementAt(0).Image))
				.ForMember(dist => dist.LastMessageTime, opt => opt.MapFrom(src => src.Messages.Last().Time))
				.ForMember(dist => dist.LastMessage, opt => opt.MapFrom(src => src.Messages.Last().MessageText))
				.ForMember(dist => dist.LastMessageAuthor, opt => opt.MapFrom(src => src.Messages.Last().MessageAuthor.Username));
		}
	}
}
