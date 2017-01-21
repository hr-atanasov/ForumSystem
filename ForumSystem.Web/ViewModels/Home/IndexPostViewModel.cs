using System;
using System.ComponentModel;

namespace ForumSystem.Web.ViewModels.Home
{
    public class IndexPostViewModel
    { 
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        [DisplayName("Posted on")]
        public DateTime CreatedOn { get; set; }

        [DisplayName("Username")]
        public string UserName { get; set; }

        public int AnswersCount { get; set; }

        public int VotesCount { get; set; }
    }
}