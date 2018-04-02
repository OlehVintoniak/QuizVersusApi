using AutoMapper;
using QuizVersus.Core.Data.Entities;
using QuizVersusApi.Models.Quiz;

namespace QuizVersusApi.AutoMapper
{
    public class MapperConfig
    {
        private static MapperConfiguration _mapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Category, CategoryViewModel>();
            cfg.CreateMap<Question, QuestionViewModel>();

            cfg.CreateMap<Quiz, QuizViewModel>();
        });
    }
}