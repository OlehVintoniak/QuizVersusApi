using QuizVersus.Core.Services.Interfaces;

namespace QuizVersus.Core.Services.Factory
{
    public interface IServiceManager
    {
        IApplicationUserService ApplicationUserService { get; }
        ICategoryService CategoryService { get; }
        IQuestionService QuestionService { get; }
        IQuizService QuizService { get; }
    }
}