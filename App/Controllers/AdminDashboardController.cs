using App.BLL;
using App.Security;
using App.ViewModels;
using System.Web.Mvc;

namespace App.Controllers
{
    public class AdminDashboardController : BaseSecurityController
    {
        #region Instances
        /// <summary>
        /// EventBusiness instance to interact to event business layer
        /// </summary>
        private EventBusiness _eventBll;
        /// <summary>
        /// BenefitBusiness instance to interact to benefit business layer
        /// </summary>
        private BenefitBusiness _benefitBll;
        /// <summary>
        /// LinkBusiness instance to interact to link business layer
        /// </summary>
        private LinkBusiness _linksBll;
        /// <summary>
        /// NewsBusiness instance to interact to news business layer
        /// </summary>
        private NewsBusiness _newsBll;
        /// <summary>
        /// PolicyBusiness instance to interact to policy business layer
        /// </summary>
        public PolicyBusiness _policyBll;        
        #endregion

        #region Constructor
        public AdminDashboardController()
        {
            _eventBll = new EventBusiness();
            _benefitBll = new BenefitBusiness();
            _linksBll = new LinkBusiness();
            _newsBll = new NewsBusiness();
            _policyBll = new PolicyBusiness();
        }
        #endregion

        #region Methods
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// This methods brings all the elements of Events, Benefits, Links, News and Policy
        /// </summary>
        /// <returns>Returns a View with all the data mentioned above</returns>
       // [AuthorizeRole(IsAdminExclusive = true)]
        public ActionResult AdminDashboard()
        {
            AdminDashboardViewModel adminDash = new AdminDashboardViewModel();

            adminDash.Event = _eventBll.GetAll();
            adminDash.Benefit = _benefitBll.GetAll();
            adminDash.Link = _linksBll.GetAll();
            adminDash.News = _newsBll.GetAll();
            adminDash.Policy = _policyBll.GetAll();

            return View(adminDash);
        }
        #endregion
    }
}