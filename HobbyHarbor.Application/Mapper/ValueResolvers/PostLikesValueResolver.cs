using AutoMapper;
using HobbyHarbor.Application.DTOs;
using HobbyHarbor.Core.Entities;

namespace HobbyHarbor.Application.Mapper.ValueResolvers
{
    public class PostLikesValueResolver : IValueResolver<Post, PostDTO, int>
	{
		public int Resolve(Post source, PostDTO destination, int destMember, ResolutionContext context)
		{
			return source.Reactions == null ? 0 : source.Reactions.Count(x => x.IsLiked);
		}
	}
}
