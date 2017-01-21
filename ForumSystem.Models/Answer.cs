namespace ForumSystem.Models
{
    using Data.Common.Contracts;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Answer : BaseModel, IDeletableEntity
    {
        public Answer()
        {
            this.Comments = new HashSet<Comment>();
            this.Votes = new HashSet<Vote>();
        }

        [Required]
        [StringLength(10000, MinimumLength = 30)]
        public string Content { get; set; }

        public int PostId { get; set; }

        public virtual Post Post { get; set; }

        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }
    }
}
