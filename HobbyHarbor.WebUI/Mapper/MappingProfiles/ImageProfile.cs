using HobbyHarbor.Core.Entities;
using HobbyHarbor.WebUI.Models;

namespace HobbyHarbor.WebUI.Mapper.MappingProfiles
{
    public class ImageProfile : AutoMapper.Profile
    {
        public ImageProfile()
        {
            CreateMap<ProfileImage, ImageModel>()
                .ForMember(dist => dist.Image, opt => opt.ConvertUsing<FileToBase64ValueConverter, string?>(src => src.Image));
        }
    }
}
