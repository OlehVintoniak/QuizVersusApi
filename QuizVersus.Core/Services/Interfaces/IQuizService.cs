using QuizVersus.Core.Data.Entities;
using QuizVersus.Core.Services.Abstract;
using System.Collections.Generic;

namespace QuizVersus.Core.Services.Interfaces
{
    public interface IQuizService : IEntityService<Quiz>
    {
        Quiz CreateQuickQuiz(string userId);
        List<Quiz> GetSended(string userId);
        List<Quiz> GetRecived(string userId);
        int CommitQuiz(Quiz quiz);
    }
}
