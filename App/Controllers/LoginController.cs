using App.BLL;
using App.Entities;
using App.ViewModels;
using System.Web.Mvc;

namespace App.Controllers
{
    public class LoginController : BaseSecurityController
    {
        private LoginBusiness _loginBll;

        #region Constructor
        public LoginController()
        {
            _loginBll = new LoginBusiness();
        }
        #endregion
        // GET: Login
        public ActionResult Index()
        {
            if (Session["user"] == null)
                return View();
            else
                return RedirectToAction("GoToDashboard","Dashboard");
        }
        
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            User user = _loginBll.getToken(model.Email, model.Password, model.isAdmin);

            if(user.Token != null)
            {
                CurrentUser = user;
                if(CurrentUser.isAdmin)
                {
                    return RedirectToAction("AdminDashboard", "AdminDashboard");
                }
                else
                {
                    return RedirectToAction("Dashboard", "Dashboard");
                }
            }
            else
            {
                Session["user"] = user;
                ModelState.AddModelError(string.Empty, "Invalid Username");
                return View("Index");
            }
           
        }
        public ActionResult Logout()
        {
            ViewBag.User = null;
            Session["user"] = null;
            return RedirectToAction("Index");
        }

    }
}