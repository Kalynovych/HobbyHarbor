using HobbyHarbor.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace HobbyHarbor.Application.Interfaces
{
    public interface IHobbyHarborDbContext : IDisposable
    {
        DbSet<User> Users { get; set; }

        DbSet<Post> Posts { get; set; }

        DbSet<PublicChat> PublicChats { get; set; }

        DbSet<PrivateChat> PrivateChats { get; set; }

        DbSet<AttachmentType> AttachmentTypes { get; set; }

        DbSet<Comment> Comments { get; set; }

        DbSet<Interest> Interests { get; set; }

        DbSet<InterestCategory> InterestCategories { get; set; }

        DbSet<Message> Messages { get; set; }

        DbSet<PrivateMessage> PrivateMessages { get; set; }

        DbSet<PublicMessage> PublicMessages { get; set; }

        DbSet<Payment> Payments { get; set; }

        DbSet<PostInterest> PostInterests { get; set; }

        DbSet<Profile> Profiles { get; set; }

        DbSet<ProfileImage> ProfileImages { get; set; }

        DbSet<PublicChatInterest> PublicChatInterests { get; set; }

        DbSet<UserChoice> UserChoices { get; set; }

        DbSet<UserInterest> UserInterests { get; set; }

        DbSet<UsersPublicChat> UsersPublicChats { get; set; }

        int SaveChanges();

        Task<int> SaveChangesAsync(CancellationToken token);
    }
}
