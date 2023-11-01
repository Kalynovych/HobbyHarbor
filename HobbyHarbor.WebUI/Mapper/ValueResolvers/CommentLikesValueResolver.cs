using AutoMapper;
using HobbyHarbor.Core.Entities;
using HobbyHarbor.WebUI.Models;

namespace HobbyHarbor.WebUI.Mapper.ValueResolvers
{
	public class CommentLikesValueResolver : IValueResolver<Comment, CommentViewModel, int>
	{
		public int Resolve(Comment source, CommentViewModel destination, int destMember, ResolutionContext context)
		{
			return source.Reactions == null ? 0 : source.Reactions.Count(x => x.IsLiked);
		}
	}
}
