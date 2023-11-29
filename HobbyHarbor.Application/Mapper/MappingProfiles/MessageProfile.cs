using HobbyHarbor.Application.DTOs;
using HobbyHarbor.Application.Mapper.ValueConverters;
using HobbyHarbor.Core.Entities;

namespace HobbyHarbor.Application.Mapper.MappingProfiles
{
    public class MessageProfile : AutoMapper.Profile
	{
		public MessageProfile()
		{
			CreateMap<Message, MessageDTO>()
				.ForMember(dist => dist.AuthorUsername, opt => opt.MapFrom(src => src.MessageAuthor.Username))
				.ForMember(dist => dist.AttachmentType, opt => opt.MapFrom(src => src.AttachmentType.Name))
				.ForMember(dist => dist.AuthorName, opt => opt.ConvertUsing<FullNameValueConverter, Profile>(src => src.MessageAuthor.Profile))
				.ForMember(dist => dist.Attachment, opt => opt.ConvertUsing<FileToBase64ValueConverter, string?>(src => src.Attachment))
				.ForMember(dist => dist.AuthorProfileImage,
					opt => opt.ConvertUsing<FileToBase64ValueConverter, string?>(src => src.MessageAuthor.Profile.Images.ElementAt(0).Image))
				.ForMember(dist => dist.ReplyMessageText, opt => opt.MapFrom(src => src.ReplyTo.MessageText));
		}
	}
}
