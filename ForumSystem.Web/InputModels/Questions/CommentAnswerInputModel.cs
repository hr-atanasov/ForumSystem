using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ForumSystem.Web.InputModels.Questions
{
    public class CommentAnswerInputModel
    {
        public CommentAnswerInputModel()
        {

        }

        public CommentAnswerInputModel(int answerId)
        {
            this.AnswerId = answerId;
        }

        public int AnswerId{ get; set; }

        [DisplayName("Content")]
        public string CommentContent { get; set; }
    }
}