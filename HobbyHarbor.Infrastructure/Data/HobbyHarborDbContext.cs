using HobbyHarbor.Core.Entities;
using HobbyHarbor.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HobbyHarbor.Infrastructure.Data
{
    public class HobbyHarborDbContext : DbContext, IHobbyHarborDbContext
    {
        public HobbyHarborDbContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<PublicChat> PublicChats { get; set; }

        public DbSet<PrivateChat> PrivateChats { get; set; }

        public DbSet<AttachmentType> AttachmentTypes { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Interest> Interests { get; set; }

        public DbSet<InterestCategory> InterestCategories { get; set; }

        public DbSet<Message> Messages { get; set; }

		public DbSet<PrivateMessage> PrivateMessages { get; set; }

		public DbSet<PublicMessage> PublicMessages { get; set; }

		public DbSet<Payment> Payments { get; set; }

        public DbSet<PostInterest> PostInterests { get; set; }

        public DbSet<Profile> Profiles { get; set; }

        public DbSet<ProfileImage> ProfileImages { get; set; }

        public DbSet<PublicChatInterest> PublicChatInterests { get; set; }

        public DbSet<UserChoice> UserChoices { get; set; }

        public DbSet<UserInterest> UserInterests { get; set; }

        public DbSet<UsersPublicChat> UsersPublicChats { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HobbyHarborDbContext).Assembly);
            modelBuilder.Seed();

            base.OnModelCreating(modelBuilder);
        }
    }
}
