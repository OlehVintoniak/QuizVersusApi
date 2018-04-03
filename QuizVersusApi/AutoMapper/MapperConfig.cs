using AutoMapper;
using QuizVersus.Core.Data.Entities;
using QuizVersusApi.Models.Quiz;

namespace QuizVersusApi.AutoMapper
{
    public class MapperConfig
    {
        private static MapperConfiguration _mapperConfig = new MapperConfiguration(cfg =>
        {
            //cfg.CreateMap<Question, QuestionViewModel>();

            //cfg.CreateMap<Quiz, QuizViewModel>();

            //cfg.CreateMap<Quiz, SendedQuizSimpleViewModel>()
            //.ForMember(dest => dest.Id, src => src.MapFrom(opt => opt.Id))
            //.ForMember(dest => dest.QuestionCount, src => src.MapFrom(opt => opt.Questions.Count))
            //.ForMember(dest => dest.ReciverFullName, src => src.MapFrom(opt => $"{opt.Receiver.FirstName} {opt.Receiver.LastName}"))
            //.ForAllOtherMembers(d => d.Ignore());

            //cfg.CreateMap<Quiz, RecivedQuizSimpleViewModel>()
            //.ForMember(dest => dest.Id, src => src.MapFrom(opt => opt.Id))
            //.ForMember(dest => dest.QuestionCount, src => src.MapFrom(opt => opt.Questions.Count))
            //.ForMember(dest => dest.SenderFullName, src => src.MapFrom(opt => $"{opt.Sender.FirstName} {opt.Sender.LastName}"))
            //.ForAllOtherMembers(d => d.Ignore());
        });
    }
}