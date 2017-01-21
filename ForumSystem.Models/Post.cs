

namespace ForumSystem.Models
{
    using Data.Common.Contracts;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Post : BaseModel, IDeletableEntity
    {
        public Post()
        {
            this.Answers = new HashSet<Answer>();
            this.Comments = new HashSet<Comment>();
            this.Votes = new HashSet<Vote>();
        }

        [Required]
        [StringLength(100, MinimumLength = 15)]
        public string Title { get; set; }

        [Required]
        [StringLength(10000, MinimumLength = 30)]
        public string Content { get; set; }

        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }
    }
}
