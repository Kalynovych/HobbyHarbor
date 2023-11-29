using HobbyHarbor.Application.DTOs;
using HobbyHarbor.Core.Entities;

namespace HobbyHarbor.Application.Mapper.MappingProfiles
{
    public class InterestProfile : AutoMapper.Profile
    {
        public InterestProfile()
        {
            CreateMap<Interest, InterestDTO>()
                .ForMember(dist => dist.Category, opt => opt.MapFrom(src => src.Category.CategoryName));
            CreateMap<PostInterest, InterestDTO>()
                .ForMember(dist => dist.Id, opt => opt.MapFrom(src => src.InterestId))
                .ForMember(dist => dist.CategoryId, opt => opt.MapFrom(src => src.Interest.CategoryId))
                .ForMember(dist => dist.Category, opt => opt.MapFrom(src => src.Interest.Category.CategoryName))
                .ForMember(dist => dist.Title, opt => opt.MapFrom(src => src.Interest.Title));
            CreateMap<UserInterest, InterestDTO>()
                .ForMember(dist => dist.Id, opt => opt.MapFrom(src => src.InterestId))
                .ForMember(dist => dist.CategoryId, opt => opt.MapFrom(src => src.Interest.CategoryId))
                .ForMember(dist => dist.Category, opt => opt.MapFrom(src => src.Interest.Category.CategoryName))
                .ForMember(dist => dist.Title, opt => opt.MapFrom(src => src.Interest.Title));
        }
    }
}
