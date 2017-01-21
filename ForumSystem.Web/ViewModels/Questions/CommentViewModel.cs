namespace ForumSystem.Web.ViewModels.Questions
{
    using System;
    using System.ComponentModel;

    public class CommentViewModel
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        [DisplayName("Username")]
        public string UserName { get; set; }

        public bool UserCanVote { get; set; }
    }
}
