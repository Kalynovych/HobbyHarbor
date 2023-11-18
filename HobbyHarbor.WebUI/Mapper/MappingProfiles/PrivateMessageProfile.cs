﻿using HobbyHarbor.Application.DTOs;
using HobbyHarbor.Core.Entities;

namespace HobbyHarbor.WebUI.Mapper.MappingProfiles
{
    public class PrivateMessageProfile : MessageProfile
	{
		public PrivateMessageProfile()
		{
			CreateMap<PrivateMessage, PrivateMessageDTO>();
		}
	}
}
