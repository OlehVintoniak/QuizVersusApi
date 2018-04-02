using QuizVersus.Core.Data.Consts;
using QuizVersus.Core.Data.Entities;
using QuizVersus.Core.Exceptions;
using QuizVersus.Core.Repositories.Abstract;
using QuizVersus.Core.Repositories.Factory;
using QuizVersus.Core.Repositories.Interfaces;
using QuizVersus.Core.Services.Abstract;
using QuizVersus.Core.Services.Interfaces;

namespace QuizVersus.Core.Services
{
    public class QuizService : EntityService<IQuizRepository, Quiz>, IQuizService
    {
        private readonly IApplicationUserRepository _userRepository;
        private readonly IQuestionRepository _questionRepository;
        public QuizService(IUnitOfWork unitOfWork, IRepositoryManager manager)
            : base(unitOfWork, manager.Quizes)
        {
            _userRepository = manager.ApplicationUsers;
            _questionRepository = manager.Questions;
        }

        public Quiz CreateQuickQuiz(string senderId)
        {
            var quiz = new Quiz
            {
                SenderId = senderId,
                ReceiverId = _userRepository.GetRandomReceiversId(senderId),
                Questions = _questionRepository.GetRandomQuestions(Consts.QuizSize)
            };
            return base.Add(quiz);
        }

        public override Quiz Add(Quiz quiz)
        {
            ValidateQuiz(quiz);
            return base.Add(quiz);
        }

        public override void Update(Quiz quiz)
        {
            ValidateQuiz(quiz);
            base.Update(quiz);
        }

        private void ValidateQuiz(Quiz quiz)
        {
            var sender = _userRepository.FindById(quiz.SenderId);
            var receiver = _userRepository.FindById(quiz.ReceiverId);

            if (sender == null)
                throw new CoreException("Sender does not exist");
            if (receiver == null)
                throw new CoreException("Receiver does not exist");
        }
    }
}
