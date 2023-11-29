using HobbyHarbor.Application.DTOs;
using HobbyHarbor.WebUI.Models;

namespace HobbyHarbor.WebUI.Mapper.MappingProfiles
{
    public class PrivateMessageProfile : MessageProfile
	{
		public PrivateMessageProfile()
		{
			CreateMap<PrivateMessageDTO, PrivateMessageViewModel>();
			CreateMap<PrivateMessageViewModel, PrivateMessageDTO>();
			CreateMap<PrivateMessageInputModel, PrivateMessageDTO>();
		}
	}
}
