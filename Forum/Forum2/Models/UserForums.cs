using Microsoft.AspNetCore.Identity;

namespace Forum2.Models
{
    public class UserForums
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public virtual IdentityUser User { get; set; }
        public int ForumTopicId { get; set; }
        public virtual ForumTopic ForumTopic { get; set; }
    }

}
