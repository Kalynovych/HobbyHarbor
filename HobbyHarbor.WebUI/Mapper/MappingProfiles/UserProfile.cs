using HobbyHarbor.Application.DTOs;
using HobbyHarbor.WebUI.Mapper.ValueResolvers;
using HobbyHarbor.WebUI.Models;

namespace HobbyHarbor.WebUI.Mapper.MappingProfile
{
    public class UserProfile : AutoMapper.Profile
	{
		public UserProfile()
		{
			CreateMap<ProfileDTO, ProfileViewModel>()
				.ForMember(dest => dest.ProfileImage, opt => opt.MapFrom<ProfileImageValueResolver>())
				.ForMember(dest => dest.BannerImage, opt => opt.MapFrom<BannerImageValueResolver>())
				.ForMember(dest => dest.GalleryImages, opt => opt.MapFrom(src => src.Images.Count > 2 ? src.Images.Skip(2) : null));
		}
	}
}
