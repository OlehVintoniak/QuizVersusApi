using Microsoft.AspNet.Identity;
using QuizVersus.Core.Services.Factory;
using QuizVersus.Core.Services.Interfaces;
using QuizVersusApi.Models.Quiz;
using System.Linq;
using System.Web.Http;

namespace QuizVersusApi.Controllers
{
    [Authorize]
    [RoutePrefix("api/Quiz")]
    public class QuizController : ApiController
    {
        private readonly IApplicationUserService _applicationUserService;
        private readonly IQuizService _quizService;
        private readonly IQuestionService _questionService;
        public QuizController(IServiceManager serviceManager)
        {
            _applicationUserService = serviceManager.ApplicationUserService;
            _quizService = serviceManager.QuizService;
            _questionService = serviceManager.QuestionService;
        }

        [HttpGet]
        [Route("Sended")]
        public IHttpActionResult SendedQuizes()
        {
            var quizes = _quizService.GetSended(User.Identity.GetUserId());
            return Ok(quizes.Select( q => new SendedQuizSimpleViewModel(q)));
        }

        [HttpGet]
        [Route("Recived")]
        public IHttpActionResult RecivedQuizes()
        {
            var quizes = _quizService.GetRecived(User.Identity.GetUserId());
            return Ok(quizes.Select(q => new RecivedQuizSimpleViewModel(q)));
        }

        [HttpGet]
        [Route("Passage/{quizId:int}")]
        public IHttpActionResult Passage(int quizId)
        {
            var quiz = _quizService.FindById(quizId);
            if (quiz == null)
                return BadRequest("Quiz not found");

            return Ok(new QuizViewModel(quiz));
        }

        [HttpPost]
        [Route("Quick")]
        public IHttpActionResult Quick()
        {
            var quiz = _quizService.CreateQuickQuiz(User.Identity.GetUserId());
            return Ok(new QuizViewModel(quiz));
        }

        [HttpPost]
        [Route("SenderCommit")]
        public IHttpActionResult SenderCommitQuiz(CommitedQuiz commitedQuiz)
        {
            var result = 0;
            var quizToCommit = _quizService.FindById(commitedQuiz.Id);
            if (quizToCommit == null)
                return BadRequest("Quiz not found");

            if (quizToCommit.SenderId != User.Identity.GetUserId())
                return BadRequest("Uncorrect sender");

            if (quizToCommit.Questions.Count != commitedQuiz.Questions.Count)
                return BadRequest("Questions couts does not correct");

            foreach (var commitedQusetion in commitedQuiz.Questions)
            {
                var question = _questionService.FindById(commitedQusetion.Id);
                if (question == null)
                    return BadRequest("Question not found");
                if (!quizToCommit.Questions.Contains(question))
                    return BadRequest($"Quiz not contain question Id:{question.Id}");

                if(question.CorrectAnswer == commitedQusetion.CheckedAnswer)
                {
                    result++;
                }
            }
            quizToCommit.SenderResult = result;
            _quizService.Update(quizToCommit);

            return Ok(result);
        }

        [HttpPost]
        [Route("ReciverCommit")]
        public IHttpActionResult ReciverCommitQuiz(CommitedQuiz commitedQuiz)
        {
            var result = 0;
            var quizToCommit = _quizService.FindById(commitedQuiz.Id);
            if (quizToCommit == null)
                return BadRequest("Quiz not found");

            if (quizToCommit.ReceiverId != User.Identity.GetUserId())
                return BadRequest("Uncorrect reciver");

            if (quizToCommit.Questions.Count != commitedQuiz.Questions.Count)
                return BadRequest("Questions couts does not correct");

            foreach (var commitedQusetion in commitedQuiz.Questions)
            {
                var question = _questionService.FindById(commitedQusetion.Id);
                if (question == null)
                    return BadRequest("Question not found");
                if (!quizToCommit.Questions.Contains(question))
                    return BadRequest($"Quiz not contain question Id:{question.Id}");

                if (question.CorrectAnswer == commitedQusetion.CheckedAnswer)
                {
                    result++;
                }
            }
            quizToCommit.ReciverResult = result;
            _quizService.Update(quizToCommit);

            return Ok(result);
        }
    }
}
