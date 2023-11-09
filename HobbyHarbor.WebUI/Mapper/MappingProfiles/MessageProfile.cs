using HobbyHarbor.Core.Entities;
using HobbyHarbor.WebUI.Mapper.ValueConverters;
using HobbyHarbor.WebUI.Models;

namespace HobbyHarbor.WebUI.Mapper.MappingProfiles
{
	public class MessageProfile : AutoMapper.Profile
	{
		public MessageProfile()
		{
			CreateMap<PrivateMessage, MessageViewModel>()
				.ForMember(dist => dist.AttachmentType, opt => opt.MapFrom(src => src.AttachmentType.Name))
				.ForMember(dist => dist.AuthorName, opt => opt.ConvertUsing<FullNameValueConverter, Profile>(src => src.MessageAuthor.Profile))
				.ForMember(dist => dist.Attachment, opt => opt.ConvertUsing<FileToBase64ValueConverter, string?>(src => src.Attachment))
				.ForMember(dist => dist.AuthorProfileImage, 
					opt => opt.ConvertUsing<FileToBase64ValueConverter, string?>(src => src.MessageAuthor.Profile.Images.ElementAt(0).Image));
		}
	}
}
