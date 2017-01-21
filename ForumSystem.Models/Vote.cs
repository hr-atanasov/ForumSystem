namespace ForumSystem.Models
{
    using Data.Common.Contracts;
    public class Vote : BaseModel, IDeletableEntity
    {
        public string VotedById { get; set; }
        public virtual User VotedBy { get; set; }

        public int? AnswerId { get; set; }
        public virtual Answer Answer { get; set; }

        public int? PostId { get; set; }
        public virtual Post Post { get; set; }

        public int? CommentId { get; set; }
        public virtual Comment Comment { get; set; }
    }
}
