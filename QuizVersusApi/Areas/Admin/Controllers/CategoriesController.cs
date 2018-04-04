using QuizVersus.Core.Data.Entities;
using QuizVersus.Core.Services.Factory;
using QuizVersus.Core.Services.Interfaces;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using QuizVersus.Core.Data.Consts;

namespace QuizVersusApi.Areas.Admin.Controllers
{
    [Authorize(Roles = Role.Admin)]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(IServiceManager serviceManager)
        {
            _categoryService = serviceManager.CategoryService;
        }

        public ActionResult Index()
        {
            var categories = _categoryService.GetAll().ToList();
            return View(categories);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var category = _categoryService.FindById(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryService.Add(category);
                return RedirectToAction("Index");
            }

            return View(category);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var category = _categoryService.FindById(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryService.Update(category);
                return RedirectToAction("Index");
            }
            return View(category);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var category = _categoryService.FindById(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            ViewBag.CanBeDeleted = category.Questions.Count == 0;
            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _categoryService.DeleteById(id);
            return RedirectToAction("Index");
        }
    }
}
