using QuizVersus.Core.Repositories.Interfaces;

namespace QuizVersus.Core.Repositories.Factory
{
    public interface IRepositoryManager
    {
        IApplicationUserRepository ApplicationUsers { get; }
        ICategoryRepository Categories { get; }
        IQuestionRepository Questions { get; }
        IQuizRepository Quizes { get; }
    }
}
