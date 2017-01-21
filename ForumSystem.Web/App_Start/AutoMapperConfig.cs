using System;
using AutoMapper;
using ForumSystem.Models;
using ForumSystem.Web.InputModels.Questions;
using ForumSystem.Web.ViewModels.Home;
using ForumSystem.Web.ViewModels.Questions;

namespace ForumSystem.Web
{
    public class AutoMapperConfig
    {
        public static void Init()
        {
            Mapper.Initialize(cfg =>
            {
                CommentToCommentViewModel(cfg);
                PostToIndexPostViewModel(cfg);
                PostToAskInputModel(cfg);
                PostToPostViewModel(cfg);
                AnswerToAnswerViewModel(cfg);
                AnswerToAnswerInputModel(cfg);
                CommentToCommentInputModel(cfg);
                CommentToCommentAnswerInputModel(cfg);
            });
        }

        private static void CommentToCommentAnswerInputModel(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Comment, CommentAnswerInputModel>()
                .ForMember(caim => caim.CommentContent, opt => opt.MapFrom(c => c.Content))
                .ReverseMap();
        }

        private static void CommentToCommentInputModel(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Comment, CommentQuestionInputModel>()
                .ForMember(cqim => cqim.CommentContent, opt => opt.MapFrom(c => c.Content))
                .ReverseMap();
        }

        private static void AnswerToAnswerInputModel(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Answer, AnswerInputModel>()
                .ForMember(aim => aim.UserName, opt => opt.MapFrom(p => p.Author.UserName))
                .ReverseMap();
        }

        private static void AnswerToAnswerViewModel(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Answer, AnswerViewModel>().ForMember(avm => avm.UserName, opt => opt.MapFrom(a => a.Author.UserName))
                .ForMember(avm => avm.Comments, opt => opt.MapFrom(a => a.Comments))
                .ReverseMap();
        }

        private static void PostToPostViewModel(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Post, PostViewModel>()
                .ForMember(pvm => pvm.UserName, opt => opt.MapFrom(p => p.Author.UserName))
                .ForMember(pvm => pvm.Comments, opt => opt.MapFrom(p => p.Comments))
                .ForMember(pvm => pvm.VoteCount, opt => opt.MapFrom(p => p.Votes.Count))
                .ReverseMap();
        }

        private static void PostToAskInputModel(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Post, AskInputModel>()
                .ForMember(aim => aim.UserName, opt => opt.MapFrom(p => p.Author.UserName))
                .ReverseMap();
        }

        private static void PostToIndexPostViewModel(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Post, IndexPostViewModel>()
                .ForMember(ipvm => ipvm.UserName, opt => opt.MapFrom(p => p.Author.UserName))
                .ForMember(ipvm => ipvm.AnswersCount, opt => opt.MapFrom(p => p.Answers.Count))
                .ForMember(ipvm => ipvm.VotesCount, opt => opt.MapFrom(p => p.Votes.Count))
                .ReverseMap();
        }

        private static void CommentToCommentViewModel(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Comment, CommentViewModel>()
                .ForMember(cvm => cvm.UserName, opt => opt.MapFrom(c => c.Author.UserName))
                .ReverseMap();
        }
    }
}
