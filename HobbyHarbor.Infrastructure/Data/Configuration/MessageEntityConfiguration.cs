using HobbyHarbor.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HobbyHarbor.Infrastructure.Data.Configuration
{
	public class MessageEntityConfiguration : IEntityTypeConfiguration<Message>
	{
		public void Configure(EntityTypeBuilder<Message> builder)
		{
			builder.HasKey(x => x.Id);

			builder.HasOne(x => x.ReplyTo)
				.WithMany()
				.HasForeignKey(x => x.ReplyMessageId)
				.OnDelete(DeleteBehavior.NoAction);

			builder.HasOne(x => x.MessageAuthor)
				.WithMany(x => x.Messages)
				.HasForeignKey(x => x.MessageAuthorId)
				.OnDelete(DeleteBehavior.NoAction);
		}
	}
}
