using AutoMapper;
using HobbyHarbor.Application.DTOs;
using HobbyHarbor.Core.Entities;

namespace HobbyHarbor.Application.Mapper.ValueResolvers
{
    public class CommentLikesValueResolver : IValueResolver<Comment, CommentDTO, int>
	{
		public int Resolve(Comment source, CommentDTO destination, int destMember, ResolutionContext context)
		{
			return source.Reactions == null ? 0 : source.Reactions.Count(x => x.IsLiked);
		}
	}
}
