using Microsoft.AspNetCore.Identity;

namespace Forum4.Models
{
    public class ForumTopic
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedById { get; set; }
        public virtual IdentityUser CreatedBy { get; set; }
        public virtual ICollection<ForumMessage> Messages { get; set; }
        public virtual ICollection<ForumInvite> Invites { get; set; }
        public virtual ICollection<IdentityUser> Members { get; set; }
    }
}
