using AutoMapper;
using AutoMapper.QueryableExtensions;
using ForumSystem.Data.Common.Contracts;
using ForumSystem.Data.UnitOfWork;
using ForumSystem.Models;
using ForumSystem.Web.Infrastructure;
using ForumSystem.Web.InputModels.Questions;
using ForumSystem.Web.ViewModels.Questions;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ForumSystem.Web.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly ISanitizer sanitizer;
        private readonly IUnitOfWork Data;

        public QuestionsController(IUnitOfWork data, ISanitizer sanitizer)
        {
            this.Data = data;
            this.sanitizer = sanitizer;
        }

        public ActionResult Display(string url, int id, int page = 1)
        {
            var userId = this.User.Identity.GetUserId();
            var postViewModel = this.Data.Posts.All()
                .Where(p => p.Id == id)
                .ProjectTo<PostViewModel>()
                .FirstOrDefault();
            var postCommentsViewModel = this.Data.Comments.All()
                .Where(c => c.PostId == postViewModel.Id)
                .ProjectTo<CommentViewModel>()
                .ToList();
            postViewModel.Comments = postCommentsViewModel;
            var answerViewModel = this.Data.Answers.All()
                .Where(a => a.PostId == postViewModel.Id)
                .OrderBy(a => a.CreatedOn)
                .ProjectTo<AnswerViewModel>()
                .ToList();
            foreach (var answer in answerViewModel)
            {
                var answerCommentsViewModel = this.Data.Comments.All()
                .Where(c => c.AnswerId == answer.Id)
                .ProjectTo<CommentViewModel>()
                .ToList();
                answer.Comments = answerCommentsViewModel;
            }
            var questionDisplayViewModel = new QuestionDisplayViewModel
            {
                Question = postViewModel,
                Answers = answerViewModel
            };
            var questionId = questionDisplayViewModel.Question.Id;
            questionDisplayViewModel.Question.UserCanVote = !(this.Data.Votes.All().Any(v => v.PostId == questionId && v.VotedById == userId));
            if (questionDisplayViewModel == null)
            {
                return this.HttpNotFound("No such post");
            }
            return View(questionDisplayViewModel);
        }

        public ActionResult GetByTag(string tag)
        {
            //TODO: Implement search by tags
            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult Ask()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Ask(AskInputModel input)
        {
            if (ModelState.IsValid)
            {
                var post = Mapper.Map<Post>(input);
                post.Content = sanitizer.Sanitize(input.Content);
                post.AuthorId = this.User.Identity.GetUserId();
                this.Data.Posts.Add(post);
                this.Data.SaveChanges();
                return RedirectToAction("Display", "Questions", new { id = post.Id, url = post.Title });
            }

            return View(input);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Vote(int id)
        {
            var userId = User.Identity.GetUserId();
            var canVote = !(this.Data.Votes.All().Any(v => v.PostId == id && v.VotedById == userId));

            if (canVote)
            {
                this.Data.Posts.GetById(id).Votes.Add(new Vote
                {
                    PostId = id,
                    VotedById = userId,
                });

                this.Data.SaveChanges();
            }

            var votesCount = this.Data.Posts.GetById(id).Votes.Count().ToString();

            return this.Content(votesCount);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Answer(AnswerInputModel input)
        {
            if (ModelState.IsValid)
            {
                var username = this.User.Identity.GetUserName();
                var userId = this.User.Identity.GetUserId();
                var dbAnswer = Mapper.Map<Answer>(input);
                dbAnswer.Content = sanitizer.Sanitize(input.Content);
                dbAnswer.AuthorId = userId;
                var post = this.Data.Posts.GetById(dbAnswer.PostId);
                if (post == null)
                {
                    throw new HttpException(404, "Question not found.");
                }
                post.Answers.Add(dbAnswer);
                this.Data.SaveChanges();
                var viewModel = Mapper.Map<AnswerViewModel>(dbAnswer);
                viewModel.UserName = username;
                return PartialView("_DisplayAnswersPartial", viewModel);
            }

            throw new HttpException(400, "Invalid answer");
        }

        public ActionResult CommentQuestion(CommentQuestionInputModel input)
        {
            if (ModelState.IsValid)
            {
                var username = this.User.Identity.GetUserName();
                var userId = this.User.Identity.GetUserId();
                var dbComment = Mapper.Map<Comment>(input);
                dbComment.Content = sanitizer.Sanitize(input.CommentContent);
                dbComment.AuthorId = userId;
                var postDb = this.Data.Posts.GetById(input.PostId);
                if (postDb == null)
                {
                    throw new HttpException(404, "Question not found.");
                }
                postDb.Comments.Add(dbComment);
                this.Data.SaveChanges();
                var viewModel = Mapper.Map<CommentViewModel>(dbComment);
                viewModel.UserName = username;
                return PartialView("_DisplayCommentsPartial", viewModel);
            }

            throw new HttpException(400, "Invalid comment.");
        }

        public ActionResult CommentAnswer(CommentAnswerInputModel input)
        {
            if (this.ModelState.IsValid)
            {
                var username = this.User.Identity.GetUserName();
                var userId = this.User.Identity.GetUserId();
                var dbComment = Mapper.Map<Comment>(input);
                dbComment.Content = sanitizer.Sanitize(input.CommentContent);
                dbComment.AuthorId = userId;
                var answerDb = this.Data.Answers.GetById(input.AnswerId);
                if (answerDb == null)
                {
                    throw new HttpException(404, "Answer not found.");
                }
                answerDb.Comments.Add(dbComment);
                this.Data.SaveChanges();
                var viewModel = Mapper.Map<CommentViewModel>(dbComment);
                viewModel.UserName = username;
                return PartialView("_DisplayCommentsPartial", viewModel);
            }

            throw new HttpException(400, "Invalid comment.");
        }
    }
}