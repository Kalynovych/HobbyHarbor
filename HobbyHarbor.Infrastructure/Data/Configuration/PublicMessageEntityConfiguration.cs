using HobbyHarbor.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HobbyHarbor.Infrastructure.Data.Configuration
{
	public class PublicMessageEntityConfiguration : IEntityTypeConfiguration<PublicMessage>
	{
		public void Configure(EntityTypeBuilder<PublicMessage> builder)
		{
			builder.ToTable("PublicMessage");

			builder.HasOne(x => x.PublicChat)
				.WithMany(x => x.Messages)
				.HasForeignKey(x => x.PublicChatId)
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}
