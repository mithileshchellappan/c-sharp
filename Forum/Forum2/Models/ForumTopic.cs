using Microsoft.AspNetCore.Identity;

namespace Forum2.Models
{
    public class ForumTopic
    {
        public int Id { get; set; }
        public string Topic { get; set; }
        public string Description { get; set; }
        public virtual IdentityUser CreatedBy { get; set; }
        public virtual ICollection<ForumMessage> Messages { get; set; }
        public virtual ICollection<ForumInvite> Invites { get; set; }
    }
}
}
