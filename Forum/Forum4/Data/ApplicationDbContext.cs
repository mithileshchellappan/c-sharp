using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Forum4.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Forum4.Models.ForumTopic> ForumTopics { get; set; }
        public DbSet<Forum4.Models.ForumInvite> ForumInvites { get; set; }
        public DbSet<Forum4.Models.ForumMessage> ForumMessages { get; set; }
        public DbSet<Forum4.Models.UserForums> UserForums { get; set; }
    }
}