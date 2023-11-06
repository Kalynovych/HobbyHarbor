using AutoMapper;
using HobbyHarbor.Core.Entities;
using HobbyHarbor.WebUI.Models;

namespace HobbyHarbor.WebUI.Mapper.ValueResolvers
{
	public class ProfileImageValueResolver : IValueResolver<User, ProfileViewModel, ImageModel>
	{
		public ImageModel Resolve(User source, ProfileViewModel destination, ImageModel destMember, ResolutionContext context)
		{
			FileToBase64ValueConverter converter = new FileToBase64ValueConverter();
			ICollection<ProfileImage> images = source.Profile.Images;
			ImageModel bannerImage;

			if (images.Count == 0)
			{
				var directory = Directory.GetCurrentDirectory();
				bannerImage = new ImageModel { Image = converter.Convert($"{directory}/wwwroot/images/ProfileStubImage.jpg", context) };
				return bannerImage;
			}

			bannerImage = new ImageModel
			{
				Id = images.ElementAt(0).Id,
				Image = converter.Convert(images.ElementAt(0).Image, context)
			};

			return bannerImage;
		}
	}
}
