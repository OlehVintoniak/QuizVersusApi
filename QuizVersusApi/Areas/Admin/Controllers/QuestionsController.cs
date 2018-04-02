using QuizVersus.Core.Data.Entities;
using QuizVersus.Core.Services.Factory;
using QuizVersus.Core.Services.Interfaces;
using System.Net;
using System.Web.Mvc;

namespace QuizVersusApi.Areas.Admin.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly IQuestionService _questionService;
        private readonly ICategoryService _categoryService;

        public QuestionsController(IServiceManager serviceManager)
        {
            _questionService = serviceManager.Questions;
            _categoryService = serviceManager.Categories;
        }

        public ActionResult Index()
        {
            var questions = _questionService.GetAll();
            return View(questions);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = _questionService.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(_categoryService.GetAll(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Question question)
        {
            if (ModelState.IsValid)
            {
                // Todo:  check if category id exist. Need to implement separately repositories...
                _questionService.Add(question);
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(_categoryService.GetAll(), "Id", "Name", question.CategoryId);
            return View(question);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = _questionService.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(_categoryService.GetAll(), "Id", "Name", question.CategoryId);
            return View(question);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Question question)
        {
            if (ModelState.IsValid)
            {
                _questionService.Update(question);
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(_categoryService.GetAll(), "Id", "Name", question.CategoryId);
            return View(question);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = _questionService.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _questionService.DeleteById(id);
            return RedirectToAction("Index");
        }
    }
}
