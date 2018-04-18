using QuizVersus.Core.Data.Enums;
using System.Collections.Generic;
using System.Linq;

namespace QuizVersusApi.Models.Quiz
{
    public class QuizViewModel
    {
        public QuizViewModel(QuizVersus.Core.Data.Entities.Quiz quiz)
        {
            Id = quiz.Id;
            ReciverFullName = $"{quiz.Receiver.FirstName} {quiz.Receiver.LastName}";
            SenderFullName = $"{quiz.Sender.FirstName} {quiz.Sender.LastName}";
            Questions = quiz.Questions.Select(q => new QuestionViewModel(q));
        }
        public int Id { get; set; }
        public string ReciverFullName { get; set; }
        public string SenderFullName { get; set; }
        public IEnumerable<QuestionViewModel> Questions { get; set; }
    }

    public class SendedQuizSimpleViewModel
    {
        public SendedQuizSimpleViewModel(QuizVersus.Core.Data.Entities.Quiz quiz)
        {
            Id = quiz.Id;
            ReciverFullName = $"{quiz.Receiver.FirstName} {quiz.Receiver.LastName}";
            QuestionCount = quiz.Questions.Count;
            ReciverResult = quiz.ReciverResult;
            SenderResult = quiz.SenderResult;
        }

        public int Id { get; set; }
        public string ReciverFullName { get; set; }
        public int QuestionCount { get; set; }
        public int? ReciverResult { get; set; }
        public int? SenderResult { get; set; }
    }

    public class RecivedQuizSimpleViewModel
    {
        public RecivedQuizSimpleViewModel(QuizVersus.Core.Data.Entities.Quiz quiz)
        {
            Id = quiz.Id;
            SenderFullName = $"{quiz.Sender.FirstName} {quiz.Sender.LastName}";
            QuestionCount = quiz.Questions.Count;
            ReciverResult = quiz.ReciverResult;
            SenderResult = quiz.SenderResult;
        }

        public int Id { get; set; }
        public string SenderFullName { get; set; }
        public int QuestionCount { get; set; }
        public int? ReciverResult { get; set; }
        public int? SenderResult { get; set; }
    }

    public class CommitedQuiz
    {
        public int Id { get; set; }
        public List<CommitedQuestion> Questions { get; set; }
    }

    public class CommitedQuestion
    {
        public int Id { get; set; }
        public CorrectAnswer CheckedAnswer { get; set; }
    }

}