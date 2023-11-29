using HobbyHarbor.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HobbyHarbor.Infrastructure.Data.Configuration
{
	public class PostsReactionEntityConfiguration : IEntityTypeConfiguration<PostsReaction>
	{
		public void Configure(EntityTypeBuilder<PostsReaction> builder)
		{
			builder.HasKey(x => new { x.UserId, x.PostId });

			builder.HasOne(x => x.User)
				.WithMany(x => x.PostsReactions)
				.HasForeignKey(x => x.UserId)
				.OnDelete(DeleteBehavior.NoAction);

			builder.HasOne(x => x.Post)
				.WithMany(x => x.Reactions)
				.HasForeignKey(x => x.PostId)
				.OnDelete(DeleteBehavior.NoAction);
		}
	}
}
