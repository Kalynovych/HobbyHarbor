using HobbyHarbor.Application.DTOs;
using HobbyHarbor.WebUI.Models;

namespace HobbyHarbor.WebUI.Mapper.MappingProfiles
{
	public class PostProfile : AutoMapper.Profile
	{
		public PostProfile()
		{
			CreateMap<PostDTO, PostViewModel>();
		}
	}
}
