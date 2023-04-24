namespace Forum2.Models
{
    public class ForumInvite
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int ForumTopicId { get; set; }
        public virtual ForumTopic ForumTopic { get; set; }
    }

}
