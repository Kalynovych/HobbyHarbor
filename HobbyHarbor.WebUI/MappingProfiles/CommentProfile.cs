using HobbyHarbor.Core.Entities;
using HobbyHarbor.WebUI.Models;

namespace HobbyHarbor.WebUI.MappingProfiles
{
	public class CommentProfile : AutoMapper.Profile
	{
		public CommentProfile()
		{
			CreateMap<Comment, CommentViewModel>()
				.ForMember(dist => dist.ProfileImage, opt => opt.MapFrom(src => src.Author.Profile.Images.ElementAt(0)))
				.ForMember(dist => dist.Name, opt => opt.MapFrom(src => src.Author.Profile.Name))
				.ForMember(dist => dist.Surname, opt => opt.MapFrom(src => src.Author.Profile.Surname));
		}
	}
}
