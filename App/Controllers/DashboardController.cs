using App.BLL;
using App.Entities;
using App.ViewModels;
using App.Security;
using System.Web.Mvc;

namespace App.Controllers
{
    public class DashboardController : BaseSecurityController
    {
        private DashboardBusiness _dashboardBll;
        private NewsBusiness _newsBll;
        private EventBusiness _eventBll;
        private LinkBusiness _linkBll;

        #region Constructor
        public DashboardController()
        {
            _dashboardBll = new DashboardBusiness();
            _newsBll = new NewsBusiness();
            _eventBll = new EventBusiness();
            _linkBll = new LinkBusiness();
        }
        #endregion
        [AuthorizeRole]
        public ActionResult Index()
        {
            return View();
        }
      //  [AuthorizeRole(IsCollaboratorExclusive=true, IsAdminExclusive=false)]
        public ActionResult Dashboard()
        {
            DashboardViewModel dashboard = new DashboardViewModel();
            //dashboard.PayrollSlip = _dashboardBll.GetPayrollSlip(CurrentUser.Email, CurrentUser.Pin);
            //dashboard.Calendar = _dashboardBll.GetCarWashBreak(CurrentUser.Token);
            //dashboard.NextCarWash = _dashboardBll.GetNextCarWash(CurrentUser.Token).Date;
            dashboard.News = _newsBll.GetImportantNews();
            dashboard.Events = _eventBll.GetAll();
            dashboard.Links = _linkBll.GetFrequentLinks();

            foreach (Event evento in dashboard.Events)
            {
                dashboard.Calendar.Add(new Calendar { start = evento.EventDate, className = "fa fa-fw fa-calendar mr" });
            }

            return View(dashboard);
        }
        [AuthorizeRole]
        public ActionResult GoToDashboard()
        {
            if (CurrentUser.isAdmin)
                return RedirectToAction("AdminDashboard", "AdminDashboard");
            else
                return RedirectToAction("Dashboard");
        }
       
    }
}