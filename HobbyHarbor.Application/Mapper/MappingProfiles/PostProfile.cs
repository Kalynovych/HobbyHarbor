using HobbyHarbor.Application.DTOs;
using HobbyHarbor.Application.Mapper.ValueConverters;
using HobbyHarbor.Application.Mapper.ValueResolvers;
using HobbyHarbor.Core.Entities;

namespace HobbyHarbor.Application.Mapper.MappingProfiles
{
    public class PostProfile : AutoMapper.Profile
    {
        public PostProfile()
        {
            CreateMap<Post, PostDTO>()
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
