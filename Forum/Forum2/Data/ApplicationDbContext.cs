using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using static Humanizer.In;

namespace Forum2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Forum2.Models.ForumTopic> ForumTopics { get; set; }
        public DbSet<Forum2.Models.ForumInvite> ForumInvites { get; set; }
        public DbSet<Forum2.Models.ForumMessage> ForumMessages { get; set; }
        public DbSet<Forum2.Models.UserForums> UserForums { get; set; }
    }
}