using Azure.Identity;
using Azure.Storage.Blobs;
using HobbyHarbor.Core.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace HobbyHarbor.Infrastructure.Data
{
    public static class DataSeedingExtension
    {
        public static async Task CreateDatabase(this IApplicationBuilder builder)
        {
            using (var scope = builder.ApplicationServices.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<HobbyHarborDbContext>();
                var database = dbContext.Database;

                await database.EnsureDeletedAsync();
                await database.EnsureCreatedAsync();
            }
        }

        public static void Seed(this ModelBuilder builder)
        {
			SeedAttachmentTypes(builder);
            SeedComments(builder);
            SeedCommentsReactions(builder);
            SeedInterests(builder);
            SeedInterestCategories(builder);
            SeedPayments(builder);
            SeedPosts(builder);
            SeedPostInterests(builder);
            SeedPostReactions(builder);
            SeedPrivateChats(builder);
			SeedPrivateMessages(builder);
			SeedProfiles(builder);
            SeedProfileImages(builder);
            SeedPublicChats(builder);
            SeedPublicChatInterests(builder);
            SeedPublicMessages(builder);
            SeedUsers(builder);
            SeedUserChoices(builder);
            SeedUserInterests(builder);
            SeedUsersPublicChats(builder);
        }

        private static void SeedAttachmentTypes(ModelBuilder builder)
        {
            builder.Entity<AttachmentType>().HasData(
                new AttachmentType { Id = 1, Name = "image" },
                new AttachmentType { Id = 2, Name = "video" },
                new AttachmentType { Id = 3, Name = "audio" });
        }

        private static void SeedComments(ModelBuilder builder)
        {
            builder.Entity<Comment>().HasData(
                new Comment { Id = 1, AuthorId = 1, PostId = 1, Text = "comment text1", Time = DateTime.Now },
                new Comment { Id = 2, AuthorId = 2, PostId = 1, Text = "comment text2", Time = DateTime.Now.Subtract(TimeSpan.FromDays(1)) },
                new Comment { Id = 3, AuthorId = 1, PostId = 1, Text = "comment text3", ReplyCommentId = 1, Time = DateTime.Now },
				new Comment { Id = 4, AuthorId = 1, PostId = 1, Text = "comment text4", ReplyCommentId = 1, Time = DateTime.Now },
				new Comment { Id = 5, AuthorId = 1, PostId = 1, Text = "comment text5", ReplyCommentId = 3, Time = DateTime.Now },
				new Comment { Id = 6, AuthorId = 1, PostId = 1, Text = "comment text6", ReplyCommentId = 5, Time = DateTime.Now },
				new Comment { Id = 7, AuthorId = 1, PostId = 1, Text = "comment text7", ReplyCommentId = 6, Time = DateTime.Now },
				new Comment { Id = 8, AuthorId = 1, PostId = 2, Text = "comment text8", Time = DateTime.Now },
				new Comment { Id = 9, AuthorId = 1, PostId = 2, Text = "comment text9", ReplyCommentId = 8, Time = DateTime.Now });
        }

		private static void SeedCommentsReactions(ModelBuilder builder)
		{
			builder.Entity<CommentsReaction>().HasData(
				new CommentsReaction { UserId = 1, CommentId = 1, IsLiked = true },
				new CommentsReaction { UserId = 1, CommentId = 2, IsLiked = true },
				new CommentsReaction { UserId = 1, CommentId = 3, IsLiked = false },
				new CommentsReaction { UserId = 2, CommentId = 1, IsLiked = true },
				new CommentsReaction { UserId = 2, CommentId = 2, IsLiked = false },
				new CommentsReaction { UserId = 2, CommentId = 3, IsLiked = false });
		}

		private static void SeedInterests(ModelBuilder builder)
        {
            builder.Entity<Interest>().HasData(
                new Interest { Id = 1, CategoryId = 1, Title = "JOJO" },
                new Interest { Id = 2, CategoryId = 2, Title = "Minecraft" },
                new Interest { Id = 3, CategoryId = 1, Title = "GTO" });
        }

        private static void SeedInterestCategories(ModelBuilder builder)
        {
            builder.Entity<InterestCategory>().HasData(
                new InterestCategory { Id = 1, CategoryName = "anime" },
                new InterestCategory { Id = 2, CategoryName = "games"},
                new InterestCategory { Id = 3, CategoryName = "books"});
        }

        private static void SeedPayments(ModelBuilder builder)
        {
            builder.Entity<Payment>().HasData(
                new Payment { Id = 1, Amount = 10, PaymentDate = DateTime.Now, PaymentStatus = "new", UserId = 2 },
                new Payment { Id = 2, Amount = 10, PaymentDate = DateTime.Now, PaymentStatus = "confirmed", UserId = 1 });
        }

        private static void SeedPosts(ModelBuilder builder)
        {
            builder.Entity<Post>().HasData(
                new Post { Id = 1, AttachmentTypeId = 1, CreatorId = 1, PostContent = "post content1", PostTitle = "title1", PublicationTime = DateTime.Now },
                new Post { Id = 2, AttachmentTypeId = 2, CreatorId = 1, PostContent = "post content2", PostTitle = "title2", PublicationTime = DateTime.Now },
                new Post { Id = 3, CreatorId = 2, PostContent = "post content3", PostTitle = "title3", PublicationTime = DateTime.Now });
        }

        private static void SeedPostInterests(ModelBuilder builder)
        {
            builder.Entity<PostInterest>().HasData(
                new PostInterest { PostId = 1, InterestId = 1},
                new PostInterest { PostId = 1, InterestId = 3},
                new PostInterest { PostId = 2, InterestId = 1});
        }

		private static void SeedPostReactions(ModelBuilder builder)
		{
			builder.Entity<PostsReaction>().HasData(
				new PostsReaction { UserId = 1, PostId = 1, IsLiked = true },
				new PostsReaction { UserId = 1, PostId = 2, IsLiked = false },
				new PostsReaction { UserId = 2, PostId = 2, IsLiked = true },
				new PostsReaction { UserId = 2, PostId = 1, IsLiked = false });
		}

		private static void SeedPrivateChats(ModelBuilder builder)
        {
            builder.Entity<PrivateChat>().HasData(
                new PrivateChat { CreatorId = 1, CompanionId = 2 },
                new PrivateChat { CreatorId = 1, CompanionId = 3 },
                new PrivateChat { CreatorId = 2, CompanionId = 3 });
        }

		private static void SeedPrivateMessages(ModelBuilder builder)
		{
			builder.Entity<PrivateMessage>().HasData(
				new PrivateMessage { Id = 1, AttachmentTypeId = 1, Attachment = "pathToAttachment", CreatorId = 1, 
                    CompanionId = 2, MessageText = "message1", Time = DateTime.Now, MessageAuthorId = 1 },
				new PrivateMessage { Id = 2, CreatorId = 1, CompanionId = 2, MessageText = "message2", Time = DateTime.Now, MessageAuthorId = 2, ReplyMessageId = 1 },
				new PrivateMessage { Id = 3, CreatorId = 1, CompanionId = 2, MessageText = "message3", Time = DateTime.Now, MessageAuthorId = 2 },
				new PrivateMessage { Id = 4, CreatorId = 1, CompanionId = 3, MessageText = "message4", Time = DateTime.Now, MessageAuthorId = 1 });
		}

		private static void SeedProfiles(ModelBuilder builder)
        {
            builder.Entity<Profile>().HasData(
                new Profile { Id = 1, UserId = 1, About = "about1", Age = 20, Birthdate = DateTime.Now, Country = "Ukraine", Name = "Name1", Sex = "male", Surname = "Surname" },
                new Profile { Id = 2, UserId = 2, About = "about2", Age = 21, Birthdate = DateTime.Now, Country = "Ukraine", Name = "Name2", Sex = "female", Surname = "Surname" },
                new Profile { Id = 3, UserId = 3, About = "about3", Age = 30, Birthdate = DateTime.Now, Country = "Ukraine", Name = "Name3", Sex = "male" },
                new Profile { Id = 4, UserId = 4, About = "about4", Age = 25, Birthdate = DateTime.Now, Country = "Ukraine", Name = "Name4", Sex = "female" },
                new Profile { Id = 5, UserId = 5, About = "about5", Age = 18, Birthdate = DateTime.Now, Country = "Ukraine", Name = "Name5", Sex = "male", Surname = "Surname" });
        }

        private static void SeedProfileImages(ModelBuilder builder)
        {
            builder.Entity<ProfileImage>().HasData(
                new ProfileImage { Id = 1, ProfileId = 1, Image = "/shared/ProfileStubImage.jpg" },
                new ProfileImage { Id = 2, ProfileId = 1, Image = "/shared/BannerStubImage.jpg" },
                new ProfileImage { Id = 3, ProfileId = 1, Image = "/shared/ProfileStubImage.jpg" },
				new ProfileImage { Id = 4, ProfileId = 1, Image = "/shared/ProfileStubImage.jpg" },
				new ProfileImage { Id = 5, ProfileId = 1, Image = "/shared/ProfileStubImage.jpg" },
				new ProfileImage { Id = 6, ProfileId = 2, Image = "/shared/ProfileStubImage.jpg" },
				new ProfileImage { Id = 7, ProfileId = 2, Image = "/shared/BannerStubImage.jpg" },
				new ProfileImage { Id = 8, ProfileId = 3, Image = "/shared/ProfileStubImage.jpg" });
        }

        private static void SeedPublicChats(ModelBuilder builder)
        {
            builder.Entity<PublicChat>().HasData(
                new PublicChat { Id = 1, ChatTitle = "title1" },
                new PublicChat { Id = 2, ChatTitle = "title2" },
                new PublicChat { Id = 3, ChatTitle = "title3" });
        }

        private static void SeedPublicChatInterests(ModelBuilder builder)
        {
            builder.Entity<PublicChatInterest>().HasData(
                new PublicChatInterest { PublicChatId = 1, InterestId = 1 },
                new PublicChatInterest { PublicChatId = 1, InterestId = 2 },
                new PublicChatInterest { PublicChatId = 2, InterestId = 1 });
        }

		private static void SeedPublicMessages(ModelBuilder builder)
		{
			builder.Entity<PublicMessage>().HasData(
				new PublicMessage { Id = 5, AttachmentTypeId = 1, Attachment = "pathToAttachment", MessageText = "message1", Time = DateTime.Now, MessageAuthorId = 1, PublicChatId = 1 },
				new PublicMessage { Id = 6, MessageText = "message2", Time = DateTime.Now, MessageAuthorId = 2, ReplyMessageId = 1, PublicChatId = 1 },
				new PublicMessage { Id = 7, MessageText = "message3", Time = DateTime.Now, MessageAuthorId = 3, PublicChatId = 1 });
		}

		private static void SeedUsers(ModelBuilder builder)
        {
            builder.Entity<User>().HasData(
                new User { Id = 1, Email = "mail@gmail.com", IsPremium = true, Username = "username1", LastActivity = DateTime.Now.AddDays(-1).AddHours(-2).AddMinutes(-10) },
                new User { Id = 2, Email = "mymail@gmail.com", IsPremium = false,  Username = "username2", LastActivity = DateTime.Now },
                new User { Id = 3, Email = "mail@ukr.net", IsPremium = false, Username = "username3", LastActivity = DateTime.Now },
                new User { Id = 4, Email = "mail@gmail.com", IsPremium = true, Username = "username4", LastActivity = DateTime.Now },
                new User { Id = 5, Email = "anothermail@gmail.com", IsPremium = false, Username = "username5", LastActivity = DateTime.Now });
        }

        private static void SeedUserChoices(ModelBuilder builder)
        {
            builder.Entity<UserChoice>().HasData(
                new UserChoice { UserId = 1, TargetId = 2, IsLiked = true, Time = DateTime.Now },
                new UserChoice { UserId = 1, TargetId = 3, IsLiked = true, Time = DateTime.Now },
                new UserChoice { UserId = 2, TargetId = 5, IsLiked = false, Time = DateTime.Now });
        }

        private static void SeedUserInterests(ModelBuilder builder)
        {
            builder.Entity<UserInterest>().HasData(
                new UserInterest { UserId = 1, InterestId = 1 },
                new UserInterest { UserId = 2, InterestId = 2 },
                new UserInterest { UserId = 1, InterestId = 2 });
        }

        private static void SeedUsersPublicChats(ModelBuilder builder)
        {
            builder.Entity<UsersPublicChat>().HasData(
                new UsersPublicChat { UserId = 1, PublicChatId = 1, IsCreator = true },
                new UsersPublicChat { UserId = 2, PublicChatId = 1, IsCreator = false },
                new UsersPublicChat { UserId = 3, PublicChatId = 1, IsCreator = false },
                new UsersPublicChat { UserId = 4, PublicChatId = 1, IsCreator = false },
                new UsersPublicChat { UserId = 5, PublicChatId = 1, IsCreator = false });
        }
    }
}
