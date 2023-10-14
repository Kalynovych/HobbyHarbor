﻿using HobbyHarbor.Core.Entities;
using HobbyHarbor.WebUI.Models;

namespace HobbyHarbor.WebUI.MappingProfiles
{
	public class UserProfile : AutoMapper.Profile
	{
		public UserProfile()
		{
			CreateMap<User, ProfileViewModel>()
				.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Profile.Name))
				.ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Profile.Surname))
				.ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.Profile.Age))
				.ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Profile.Country))
				.ForMember(dest => dest.Sex, opt => opt.MapFrom(src => src.Profile.Sex))
				.ForMember(dest => dest.Birthdate, opt => opt.MapFrom(src => src.Profile.Birthdate))
				.ForMember(dest => dest.About, opt => opt.MapFrom(src => src.Profile.About))
				.ForMember(dest => dest.PublicChatsAmount, opt => opt.MapFrom(src => src.PublicChats != null ? src.PublicChats.Count : 0))
				.ForMember(dest => dest.PrivateChatsAmount, opt => opt.MapFrom(src => src.PrivateChats != null ? src.PrivateChats.Count : 0))
				.ForMember(dest => dest.ProfileImage, opt => opt.MapFrom(src => src.Profile.Images.ElementAt(0)))
				.ForMember(dest => dest.BannerImage, opt => opt.MapFrom(src => src.Profile.Images.ElementAt(1)))
				.ForMember(dest => dest.GalleryImages, opt => opt.MapFrom(src => src.Profile.Images.Count > 2 ? src.Profile.Images.Skip(2) : null));
		}
	}
}
