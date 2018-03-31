using System.Web.Mvc;
using QuizVersus.Core.Data.Consts;

namespace QuizVersusApi.Areas.Admin.Controllers
{
    [Authorize(Roles = Role.Admin)]
    public class AdminController : Controller
    {
        // GET: Admin/Admin
        public ActionResult Index()
        {
            return View();
        }
    }
}