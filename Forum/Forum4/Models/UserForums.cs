using Microsoft.AspNetCore.Identity;

namespace Forum4.Models
{
    public class UserForums
    {
        public string Id { get; set; }

        public IdentityUser User { get; set; }
        public List<ForumTopic> Forums { get; set; }
    }
}
