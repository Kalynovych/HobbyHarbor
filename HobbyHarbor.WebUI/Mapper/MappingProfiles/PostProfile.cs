using HobbyHarbor.Core.Entities;
using HobbyHarbor.WebUI.Mapper.ValueResolvers;
using HobbyHarbor.WebUI.Models;

namespace HobbyHarbor.WebUI.Mapper.MappingProfiles
{
    public class PostProfile : AutoMapper.Profile
    {
        public PostProfile()
        {
            CreateMap<Post, PostViewModel>()
                .ForMember(dest => dest.Attachment, opt => opt.ConvertUsing<FileToBase64ValueConverter, string?>(src => src.Attachment))
                .ForMember(dest => dest.AttachmentType, opt => opt.MapFrom(src => src.AttachmentType != null ? src.AttachmentType.Name : null))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Creator.Profile.Name))
                .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Creator.Profile.Surname))
                .ForMember(dest => dest.ProfileImage, opt => opt.MapFrom(src => src.Creator.Profile.Images.ElementAt(0)))
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Creator.Username))
				.ForMember(dist => dist.Likes, opt => opt.MapFrom<PostLikesValueResolver>())
				.ForMember(dist => dist.Dislikes, opt => opt.MapFrom<PostDislikesValueResolver>());
        }
    }
}
