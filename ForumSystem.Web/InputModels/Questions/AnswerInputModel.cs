using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ForumSystem.Web.InputModels.Questions
{
    public class AnswerInputModel
    {
        public AnswerInputModel()
        {

        }

        public AnswerInputModel(int postId)
        {
            this.PostId = postId;
        }
        [DisplayName("Username")]
        public string UserName { get; set; }

        [Required]
        [StringLength(10000, MinimumLength = 30)]
        [AllowHtml]
        [Display(Name = "Answer")]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        public int PostId { get; set; }
    }
}