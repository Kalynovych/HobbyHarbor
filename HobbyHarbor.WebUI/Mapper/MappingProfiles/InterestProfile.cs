using HobbyHarbor.Application.DTOs;
using HobbyHarbor.WebUI.Models;

namespace HobbyHarbor.WebUI.Mapper.MappingProfiles
{
    public class InterestProfile : AutoMapper.Profile
    {
        public InterestProfile()
        {
            CreateMap<InterestDTO, InterestModel>();
        }
    }
}
