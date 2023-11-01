using AutoMapper;
using HobbyHarbor.Core.Entities;
using HobbyHarbor.WebUI.Models;

namespace HobbyHarbor.WebUI.Mapper.ValueResolvers
{
	public class PostLikesValueResolver : IValueResolver<Post, PostViewModel, int>
	{
		public int Resolve(Post source, PostViewModel destination, int destMember, ResolutionContext context)
		{
			return source.Reactions == null ? 0 : source.Reactions.Count(x => x.IsLiked);
		}
	}
}
