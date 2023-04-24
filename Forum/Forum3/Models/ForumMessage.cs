namespace Forum3.Models
{
    public class ForumMessage
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public int ForumTopicId { get; set; }
        public virtual ForumTopic ForumTopic { get; set; }
}
}
