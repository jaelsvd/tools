using App.Entities;
using System.Web.Mvc;

namespace App.Controllers
{
    public abstract class BaseSecurityController : Controller
    {
        #region Protected Class Members
        protected User CurrentUser
        {
            get
            {
                return (User)HttpContext.Session["User"];
            }
            set
            {
                HttpContext.Session["User"] = value;
            }
        }
        #endregion
    }
}