using HobbyHarbor.Core.Entities;
using HobbyHarbor.WebUI.Models;

namespace HobbyHarbor.WebUI.MappingProfiles
{
	public class PostProfile : AutoMapper.Profile
	{
		public PostProfile()
		{
			CreateMap<Post, PostViewModel>()
				.ForMember(dest => dest.Attachment, opt => opt.MapFrom(src => src.Attachment != null ? this.FileToBase64String(src.Attachment) : null))
				.ForMember(dest => dest.AttachmentType, opt => opt.MapFrom(src => src.AttachmentType != null ? src.AttachmentType.Name : null))
				.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Creator.Profile.Name))
				.ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Creator.Profile.Surname))
				.ForMember(dest => dest.ProfileImage, opt => opt.MapFrom(src => src.Creator.Profile.Images.ElementAt(0)));
		}
	}
}
