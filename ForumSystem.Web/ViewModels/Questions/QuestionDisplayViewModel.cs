namespace ForumSystem.Web.ViewModels.Questions
{
    using System.Collections.Generic;

    public class QuestionDisplayViewModel
    {
        public PostViewModel Question { get; set; }

        public ICollection<AnswerViewModel> Answers { get; set; }
    }
}