using HobbyHarbor.Core.Entities;
using HobbyHarbor.WebUI.Models;

namespace HobbyHarbor.WebUI.MappingProfiles
{
	public class InterestProfile : AutoMapper.Profile
	{
		public InterestProfile()
		{
			CreateMap<Interest, InterestModel>()
				.ForMember(dist => dist.Category, opt => opt.MapFrom(src => src.Category.CategoryName));
			CreateMap<PostInterest, InterestModel>()
				.ForMember(dist => dist.Id, opt => opt.MapFrom(src => src.InterestId))
				.ForMember(dist => dist.CategoryId, opt => opt.MapFrom(src => src.Interest.CategoryId))
				.ForMember(dist => dist.Category, opt => opt.MapFrom(src => src.Interest.Category.CategoryName))
				.ForMember(dist => dist.Title, opt => opt.MapFrom(src => src.Interest.Title));
			CreateMap<UserInterest, InterestModel>()
				.ForMember(dist => dist.Id, opt => opt.MapFrom(src => src.InterestId))
				.ForMember(dist => dist.CategoryId, opt => opt.MapFrom(src => src.Interest.CategoryId))
				.ForMember(dist => dist.Category, opt => opt.MapFrom(src => src.Interest.Category.CategoryName))
				.ForMember(dist => dist.Title, opt => opt.MapFrom(src => src.Interest.Title));
		}
	}
}
