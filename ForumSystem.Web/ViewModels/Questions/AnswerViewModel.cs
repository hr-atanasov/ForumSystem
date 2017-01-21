namespace ForumSystem.Web.ViewModels.Questions
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    public class AnswerViewModel
    {
        public int Id { get; set; }

        public string Content { get; set; }

        [DisplayName("Username")]
        public string UserName { get; set; }

        public ICollection<CommentViewModel> Comments { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool UserCanVote { get; set; }
    }
}
