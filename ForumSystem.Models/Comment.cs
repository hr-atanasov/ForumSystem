namespace ForumSystem.Models
{
    using System.ComponentModel.DataAnnotations;
    using Data.Common.Contracts;
    using System.Collections.Generic;

    public class Comment : BaseModel, IDeletableEntity
    {
        public Comment()
        {
            this.Votes = new HashSet<Vote>();
        }
        [Required]
        [StringLength(1000, MinimumLength = 30)]
        public string Content { get; set; }

        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        public int? PostId { get; set; }

        public virtual Post Post { get; set; }

        public int? AnswerId { get; set; }

        public virtual Answer Answer { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }
    }
}
