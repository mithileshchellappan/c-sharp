using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Forum.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Forum.Models.ForumTopic> ForumTopics { get; set; }
        public DbSet<Forum.Models.ForumInvite> ForumInvites { get; set;}
        public DbSet<Forum.Models.ForumMessage> ForumMessages { get; set;}
        public DbSet<Forum.Models.UserForums> UserForums { get; set; }
    }
}