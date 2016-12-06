using App.BLL;
using App.Entities;
using App.Security;
using System.Collections.Generic;
using System.Web.Mvc;

namespace App.Controllers
{
    public class DirectoryController : BaseSecurityController
    {
        DirectoryBusiness _directoryBll;
        
        public DirectoryController()
        {
            _directoryBll = new DirectoryBusiness();
        }

        // GET: Direcotry
        public ActionResult Index()
        {
            return View();
        }
        [AuthorizeRole]
        public ActionResult Directory()
        {
            List<User> directory =_directoryBll.GetDirectorys(CurrentUser.Token);

            return View(directory);
        }
        [AuthorizeRole]
        public ActionResult DirectoryDetail(User user)
        {
            return View(user);
        }
    }
}