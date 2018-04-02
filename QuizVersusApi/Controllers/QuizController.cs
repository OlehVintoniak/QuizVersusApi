using AutoMapper;
using Microsoft.AspNet.Identity;
using QuizVersus.Core.Data.Entities;
using QuizVersus.Core.Services.Factory;
using QuizVersus.Core.Services.Interfaces;
using QuizVersusApi.Models.Quiz;
using System.Web.Http;

namespace QuizVersusApi.Controllers
{
    [Authorize]
    [RoutePrefix("api/Quiz")]
    public class QuizController : ApiController
    {
        private readonly IApplicationUserService _applicationUserService;
        private readonly IQuizService _quizService;
        public QuizController(IServiceManager serviceManager)
        {
            _applicationUserService = serviceManager.ApplicationUserService;
            _quizService = serviceManager.QuizService;
        }


        [HttpPost]
        [Route("Quick")]
        public IHttpActionResult Quick()
        {
            var quiz = _quizService.CreateQuickQuiz(User.Identity.GetUserId());
            return Ok(Mapper.Map<Quiz, QuizViewModel>(quiz));
        }
    }
}
