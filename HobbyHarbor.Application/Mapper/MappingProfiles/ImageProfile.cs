using HobbyHarbor.Application.DTOs;
using HobbyHarbor.Application.Mapper.ValueConverters;
using HobbyHarbor.Core.Entities;

namespace HobbyHarbor.Application.Mapper.MappingProfiles
{
    public class ImageProfile : AutoMapper.Profile
    {
        public ImageProfile()
        {
            CreateMap<ProfileImage, ImageDTO>()
                .ForMember(dist => dist.Image, opt => opt.ConvertUsing<FileToBase64ValueConverter, string?>(src => src.Image));
        }
    }
}
