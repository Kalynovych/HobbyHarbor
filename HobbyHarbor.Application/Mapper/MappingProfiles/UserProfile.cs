using HobbyHarbor.Application.DTOs;
using HobbyHarbor.Core.Entities;

namespace HobbyHarbor.Application.Mapper.MappingProfiles
{
    public class UserProfile : AutoMapper.Profile
    {
        public UserProfile()
        {
            CreateMap<User, ProfileDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Profile.Name))
                .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Profile.Surname))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.Profile.Age))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Profile.Country))
                .ForMember(dest => dest.Sex, opt => opt.MapFrom(src => src.Profile.Sex))
                .ForMember(dest => dest.Birthdate, opt => opt.MapFrom(src => src.Profile.Birthdate))
                .ForMember(dest => dest.About, opt => opt.MapFrom(src => src.Profile.About))
                .ForMember(dest => dest.PublicChatsAmount, opt => opt.MapFrom(src => src.PublicChats != null ? src.PublicChats.Count : 0))
                .ForMember(dest => dest.PrivateChatsAmount, opt => opt.MapFrom(src => src.PrivateChats != null ? src.PrivateChats.Count : 0))
                .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Profile.Images))
                .ForMember(dest => dest.OnlineStatus, opt => opt.MapFrom(src => src.LastActivity));
        }
    }
}
