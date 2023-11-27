using HobbyHarbor.Application.DTOs;
using HobbyHarbor.WebUI.Models;

namespace HobbyHarbor.WebUI.Mapper.MappingProfiles
{
	public class PublicMessageProfile : MessageProfile
	{
		public PublicMessageProfile()
		{
			CreateMap<PublicMessageDTO, PublicMessageViewModel>();
			CreateMap<PublicMessageViewModel, PublicMessageDTO>();
			CreateMap<PublicMessageInputModel, PublicMessageDTO>();
		}
	}
}
