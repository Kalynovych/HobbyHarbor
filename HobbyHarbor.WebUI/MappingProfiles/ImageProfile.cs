using HobbyHarbor.Core.Entities;
using HobbyHarbor.WebUI.Models;

namespace HobbyHarbor.WebUI.MappingProfiles
{
	public class ImageProfile : AutoMapper.Profile
	{
		public ImageProfile()
		{
			CreateMap<ProfileImage, ImageModel>()
				.ForMember(dist => dist.Image, opt => opt.MapFrom(src => this.FileToBase64String(src.Image)));
		}
	}
}
