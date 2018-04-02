using QuizVersus.Core.Data.Entities;
using QuizVersus.Core.Repositories.Abstract;
using System.Collections.Generic;

namespace QuizVersus.Core.Repositories.Interfaces
{
    public interface IQuestionRepository : IGenericRepository<Question>
    {
        List<Question> GetRandomQuestions(int count);
    }
}
