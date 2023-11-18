﻿using AutoMapper;
using HobbyHarbor.Application.DTOs;
using HobbyHarbor.Application.Interfaces;
using HobbyHarbor.Application.Mapper.ValueConverters;
using HobbyHarbor.WebUI.Models;

namespace HobbyHarbor.WebUI.Mapper.ValueResolvers
{
    public class BannerImageValueResolver : IValueResolver<ProfileDTO, ProfileViewModel, ImageModel>
	{
		private readonly IFileStorageService _fileStorageService;

		public BannerImageValueResolver(IFileStorageService fileStorageService)
		{
			_fileStorageService = fileStorageService;
		}

		public ImageModel Resolve(ProfileDTO source, ProfileViewModel destination, ImageModel destMember, ResolutionContext context)
		{
			FileToBase64ValueConverter converter = new FileToBase64ValueConverter(_fileStorageService);
			ICollection<ImageDTO> images = source.Images;
			ImageModel bannerImage;

			if (images.Count == 0)
			{
				bannerImage = new ImageModel { Image = converter.Convert("/shared/BannerStubImage.jpg", context) };
				return bannerImage;
			}

			bannerImage = new ImageModel
			{
				Id = images.ElementAt(1).Id,
				Image = images.ElementAt(1).Image
			};

			return bannerImage;
		}
	}
}
