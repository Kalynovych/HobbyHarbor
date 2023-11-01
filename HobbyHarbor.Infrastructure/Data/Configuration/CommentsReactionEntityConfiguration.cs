using HobbyHarbor.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HobbyHarbor.Infrastructure.Data.Configuration
{
	public class CommentsReactionEntityConfiguration : IEntityTypeConfiguration<CommentsReaction>
	{
		public void Configure(EntityTypeBuilder<CommentsReaction> builder)
		{
			builder.HasKey(x => new { x.UserId, x.CommentId });

			builder.HasOne(x => x.User)
				.WithMany(x => x.CommentsReactions)
				.HasForeignKey(x => x.UserId)
				.OnDelete(DeleteBehavior.NoAction);

			builder.HasOne(x => x.Comment)
				.WithMany(x => x.Reactions)
				.HasForeignKey(x => x.CommentId)
				.OnDelete(DeleteBehavior.NoAction);
		}
	}
}
