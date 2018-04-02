using QuizVersus.Core.Data;
using QuizVersus.Core.Data.Entities;
using QuizVersus.Core.Exceptions;
using QuizVersus.Core.Repositories.Abstract;
using QuizVersus.Core.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuizVersus.Core.Repositories
{
    public class QuestionRepository : GenericRepository<Question>, IQuestionRepository
    {
        public QuestionRepository(ApplicationDbContext context)
            : base(context) { }

        public List<Question> GetRandomQuestions(int count)
        {
            if (count > GetAll().Count())
                throw new CoreException("There are to few questions");

            var randomQuestions = new List<Question>();
            while(randomQuestions.Count < count)
            {
                var question = GetAll().OrderBy(x => Guid.NewGuid()).Take(1).SingleOrDefault();
                if (!randomQuestions.Contains(question))
                {
                    randomQuestions.Add(question);
                }
            }
            return randomQuestions;
        }
    }
}
