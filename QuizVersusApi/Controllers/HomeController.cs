using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using QuizVersusApi.Models.Account;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace QuizVersusApi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationSignInManager _signInManager = null;
        private ApplicationSignInManager SignInManager 
            => _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Login(LoginBindingModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }

        //    var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
        //    switch (result)
        //    {
        //        case SignInStatus.Success:
        //            return RedirectToAction("Index");
        //        default:
        //            ModelState.AddModelError("", "Invalid login attempt.");
        //            return View(model);
        //    }
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }

        #region Helpers
        private IAuthenticationManager AuthenticationManager 
            => HttpContext.GetOwinContext().Authentication;
        #endregion
    }
}
