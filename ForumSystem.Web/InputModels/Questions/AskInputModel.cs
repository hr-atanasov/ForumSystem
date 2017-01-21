using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ForumSystem.Web.InputModels.Questions
{
    public class AskInputModel
    { 
        [DisplayName("Username")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Title")]
        [StringLength(100, MinimumLength = 15)]
        [DataType(DataType.Text)]
        public string Title { get; set; }

        [Required]
        [StringLength(10000, MinimumLength = 30)]
        [AllowHtml]
        [Display(Name = "Content")]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        [Display(Name = "Tags")]
        [DataType(DataType.Text)]
        public string Tags { get; set; }
    }
}