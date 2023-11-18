using System.Diagnostics.Contracts;
using HobbyHarbor.Application.DTOs;
using HobbyHarbor.Core.Entities;

namespace HobbyHarbor.Application.Mapper.MappingProfiles
{
    public class PrivateMessageProfile : MessageProfile
	{
		public PrivateMessageProfile()
		{
			CreateMap<PrivateMessage, PrivateMessageDTO>();
		}
	}
}
