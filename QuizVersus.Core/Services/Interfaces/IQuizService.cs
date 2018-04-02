﻿using QuizVersus.Core.Data.Entities;
using QuizVersus.Core.Services.Abstract;

namespace QuizVersus.Core.Services.Interfaces
{
    public interface IQuizService : IEntityService<Quiz>
    {
        Quiz CreateQuickQuiz(string senderId);
    }
}