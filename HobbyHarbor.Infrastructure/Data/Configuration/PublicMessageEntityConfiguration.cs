using HobbyHarbor.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HobbyHarbor.Infrastructure.Data.Configuration
{
	public class PublicMessageEntityConfiguration : IEntityTypeConfiguration<PublicMessage>
	{
		public void Configure(EntityTypeBuilder<PublicMessage> builder)
		{
			builder.HasKey(x => x.Id);

			builder.HasOne(x => x.PublicChat)
				.WithMany(x => x.Messages)
				.HasForeignKey(x => x.PublicChatId)
				.OnDelete(DeleteBehavior.NoAction);

			builder.HasOne(x => x.MessageAuthor)
				.WithMany(x => x.PublicMessages)
				.HasForeignKey(x => x.MessageAuthorId)
				.OnDelete(DeleteBehavior.NoAction);

			builder.HasOne(x => x.ReplyTo)
				.WithMany()
				.HasForeignKey(x => x.ReplyMessageId)
				.OnDelete(DeleteBehavior.NoAction);
		}
	}
}
