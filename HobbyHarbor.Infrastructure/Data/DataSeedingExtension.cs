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
            SeedInterests(builder);
            SeedInterestCategories(builder);
            SeedMessages(builder);
            SeedPayments(builder);
            SeedPosts(builder);
            SeedPostInterests(builder);
            SeedPrivateChats(builder);
            SeedProfiles(builder);
            SeedProfileImages(builder);
            SeedPublicChats(builder);
            SeedPublicChatInterests(builder);
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
                new Comment { Id = 1, AuthorId = 1, Dislikes = 10, Likes = 15, PostId = 1, Text = "comment text1", Time = DateTime.Now },
                new Comment { Id = 2, AuthorId = 2, Dislikes = 10, Likes = 15, PostId = 1, Text = "comment text2", Time = DateTime.Now },
                new Comment { Id = 3, AuthorId = 1, Dislikes = 10, Likes = 15, PostId = 2, Text = "comment text3", ReplyCommentId = 2, Time = DateTime.Now });
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

        private static void SeedMessages(ModelBuilder builder)
        {
            builder.Entity<Message>().HasData(
                new Message { Id = 1, AttachmentTypeId = 1, Attachment = "pathToAttachment", CreatorId = 1, CompanionId = 2,
                    MessageText = "message1", IsPrivateChat = true, Time = DateTime.Now, MessageAuthorId = 1 },
                new Message { Id = 2, CreatorId = 1, CompanionId = 2, MessageText = "message2", IsPrivateChat = true, Time = DateTime.Now, MessageAuthorId = 2, ReplyMessageId = 1 },
                new Message { Id = 3, MessageText = "message3", IsPrivateChat = false, Time = DateTime.Now, PublicChatId = 1, MessageAuthorId = 1 });
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
                new Post { Id = 1, AttachmentTypeId = 1, CreatorId = 1, Dislikes = 50, Likes = 17, PostContent = "post content1", PostTitle = "title1", PublicationTime = DateTime.Now },
                new Post { Id = 2, AttachmentTypeId = 2, CreatorId = 1, Dislikes = 50, Likes = 17, PostContent = "post content2", PostTitle = "title2", PublicationTime = DateTime.Now },
                new Post { Id = 3, CreatorId = 2, Dislikes = 50, Likes = 17, PostContent = "post content3", PostTitle = "title3", PublicationTime = DateTime.Now });
        }

        private static void SeedPostInterests(ModelBuilder builder)
        {
            builder.Entity<PostInterest>().HasData(
                new PostInterest { PostId = 1, InterestId = 1},
                new PostInterest { PostId = 1, InterestId = 3},
                new PostInterest { PostId = 2, InterestId = 1});
        }

        private static void SeedPrivateChats(ModelBuilder builder)
        {
            builder.Entity<PrivateChat>().HasData(
                new PrivateChat { CreatorId = 1, CompanionId = 2 },
                new PrivateChat { CreatorId = 1, CompanionId = 3 },
                new PrivateChat { CreatorId = 2, CompanionId = 3 });
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
            var directory = Directory.GetCurrentDirectory();
            builder.Entity<ProfileImage>().HasData(
                new ProfileImage { Id = 1, ProfileId = 1, Image = $"{directory}/wwwroot/images/ProfileStubImage.jpg" },
                new ProfileImage { Id = 2, ProfileId = 1, Image = $"{directory}/wwwroot/images/BannerStubImage.jpg" },
                new ProfileImage { Id = 3, ProfileId = 1, Image = $"{directory}/wwwroot/images/ProfileStubImage.jpg" },
				new ProfileImage { Id = 4, ProfileId = 1, Image = $"{directory}/wwwroot/images/ProfileStubImage.jpg" },
				new ProfileImage { Id = 5, ProfileId = 1, Image = $"{directory}/wwwroot/images/ProfileStubImage.jpg" },
				new ProfileImage { Id = 6, ProfileId = 2, Image = $"{directory}/wwwroot/images/ProfileStubImage.jpg" });
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

        private static void SeedUsers(ModelBuilder builder)
        {
            builder.Entity<User>().HasData(
                new User { Id = 1, Email = "mail@gmail.com", IsPremium = true, Password = "password", Username = "username1" },
                new User { Id = 2, Email = "mymail@gmail.com", IsPremium = false, Password = "password", Username = "username2" },
                new User { Id = 3, Email = "mail@ukr.net", IsPremium = false, Password = "password", Username = "username3" },
                new User { Id = 4, Email = "mail@gmail.com", IsPremium = true, Password = "password", Username = "username4" },
                new User { Id = 5, Email = "anothermail@gmail.com", IsPremium = false, Password = "password", Username = "username5" });
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
