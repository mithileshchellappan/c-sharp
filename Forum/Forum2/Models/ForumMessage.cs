using Microsoft.AspNetCore.Identity;

namespace Forum2.Models
{
    public class ForumMessage
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public virtual IdentityUser CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int ForumTopicId { get; set; }
        public virtual ForumTopic ForumTopic { get; set; }
    }
}
