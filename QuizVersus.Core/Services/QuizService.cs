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
        public QuizService(IUnitOfWork unitOfWork, IRepositoryManager manager)
            : base(unitOfWork, manager.Quizes)
        {
            _userRepository = manager.ApplicationUsers;
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
