using ForumSystem.Data;
using ForumSystem.Data.Base;
using ForumSystem.Data.Common.Contracts;
using ForumSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using ForumSystem.Web.ViewModels.Home;

namespace ForumSystem.Web.Controllers
{
    public class HomeController : Controller
    {
        private IDeletableEntityRepository<Post> posts;

        public HomeController(IDeletableEntityRepository<Post> posts)
        {
            this.posts = posts;
        }


        public ActionResult Index()
        {
            var posts = this.posts
                .All()
                .OrderByDescending(p=>p.CreatedOn)
                .Take(10)
                .ProjectTo<IndexPostViewModel>()
                .ToList();
            return View(posts);
        }
    }
}