using HobbyHarbor.Application.DTOs;
using HobbyHarbor.WebUI.Models;

namespace HobbyHarbor.WebUI.Mapper.MappingProfiles
{
    public class ImageProfile : AutoMapper.Profile
    {
        public ImageProfile()
        {
            CreateMap<ImageDTO, ImageModel>();
        }
    }
}
