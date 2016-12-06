using App.Entities;
using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace App.Security
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeRoleAttribute: AuthorizeAttribute
    {
        public bool IsAdminExclusive { get; set; }
        public bool IsCollaboratorExclusive { get; set; }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            var user = filterContext.HttpContext.Session["user"] as User;

            if(user == null)
            {
                base.HandleUnauthorizedRequest(filterContext);
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Login", action = "Index" }));
                return;
            }

            bool isAuthorized = user != null;

            if(isAuthorized && !IsAdminExclusive && !user.isAdmin)
            {
                return;
            }

            if(user.isAdmin == IsAdminExclusive)
            {
                return;
            }

            bool notAuthorized = user != null;

            if(notAuthorized && !IsCollaboratorExclusive && user.isAdmin)
            {
                return;
            }

            base.HandleUnauthorizedRequest(filterContext);
            filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Dashboard", action = "GoToDashboard" }));
        }
    }
}