using HobbyHarbor.Application.DTOs;
using HobbyHarbor.WebUI.Models;

namespace HobbyHarbor.WebUI.Mapper.MappingProfiles
{
    public class CommentProfile : AutoMapper.Profile
    {
        public CommentProfile()
        {
            CreateMap<CommentDTO, CommentViewModel>();
        }
    }
}
