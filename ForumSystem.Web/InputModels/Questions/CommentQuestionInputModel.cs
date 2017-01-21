using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ForumSystem.Web.InputModels.Questions
{
    public class CommentQuestionInputModel    {
        public CommentQuestionInputModel()
        {

        }

        public CommentQuestionInputModel(int postId)
        {
            this.PostId = postId;
        }
     
        public int PostId { get; set;}

        [DisplayName("Content")]
        public string CommentContent { get; set;}
    }
}