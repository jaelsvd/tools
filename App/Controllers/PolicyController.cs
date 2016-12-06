using App.BLL;
using App.Entities;
using App.Security;
using App.ViewModels;
using PagedList;
using System;
using System.Linq;
using System.Web.Mvc;

namespace App.Controllers
{

    /// <summary>
    /// Class to interact with policy business layer and news views
    /// </summary>
    public class PolicyController : BaseSecurityController
    {
        #region Instance Members
        /// <summary>
        /// PolicyBusiness instance to interact to policy business layer
        /// </summary>
        public PolicyBusiness _policyBll;
        #endregion

        #region Constructor
        /// <summary>
        /// Initialize PolicyBusiness and FileBusiness instances
        /// </summary>
        public PolicyController()
        {
            _policyBll = new PolicyBusiness();
        }
        #endregion

        #region Public Methods
        [AuthorizeRole]
        public ActionResult Index()
        {
            if(CurrentUser.isAdmin)
            {
                return RedirectToAction("ListPolicy");
            }
            else
            {
                return RedirectToAction("Policy");
            }
        }
        /// <summary>
        /// Load create policy view
        /// </summary>
        /// <returns>Returns a create policy view</returns>
       // [AuthorizeRole(IsAdminExclusive = true)]
        public ActionResult Createpolicy()
        {
            return View();
        }
        [HttpPost]
        //[AuthorizeRole(IsAdminExclusive = true)]
        public ActionResult CreatePolicy(PolicyViewModel model)
        {
            var validImageTypes = new string[]
            {
                "image/gif",
                "image/jpeg",
                "image/pjpeg",
                "image/png"
            };
            if (model.ImageUpload == null || model.ImageUpload.ContentLength == 0)
            {
                ModelState.AddModelError("ImageUpload", "This field is required");
            }
            else if (!validImageTypes.Contains(model.ImageUpload.ContentType))
            {
                ModelState.AddModelError("ImageUpload", "Please choose either a GIF, JPG or PNG image.");
            }
            if (ModelState.IsValid)
            {
                try
                {
                    var policy = new Policy();
                    policy = model.PolicyModel;
                    Guid imageName = Guid.NewGuid();
                    policy.ImageName = imageName + System.IO.Path.GetExtension(model.ImageUpload.FileName);
                    model.ImageUpload.SaveAs(System.IO.Path.Combine(Server.MapPath(policy.ImagePath), policy.ImageName));

                    _policyBll.AddPolicy(policy);

                    return RedirectToAction("ListPolicy");
                }
                catch (PolicyAlreadyExistException)
                {
                    ModelState.AddModelError("Title", "Title Already Exists");
                }
            }
            return View();
        }
        /// <summary>
        /// Load a policy list view
        /// </summary>
        /// <returns>Returns policy list view</returns>
        //[AuthorizeRole(IsAdminExclusive = true)]
        public ActionResult ListPolicy()
        {
            var policy = _policyBll.GetAll();
            return View(policy);
        }
        /// <summary>
        /// Gets a policy id to delete the policy
        /// </summary>
        /// <param name="id">id of policy to delete</param>
        /// <returns>Redirects to policy lits view</returns>
       // [AuthorizeRole(IsAdminExclusive = true)]
        public ActionResult DeletePolicy(int id)
        {
            if(id !=0)
            {
                var policy = _policyBll.GetPolicy(id);
                if (System.IO.File.Exists(System.IO.Path.Combine(Server.MapPath(policy.ImagePath), policy.ImageName)))
                {
                    System.IO.File.Delete(System.IO.Path.Combine(Server.MapPath(policy.ImagePath), policy.ImageName));
                }
                _policyBll.RemovePolicy(id);
            }
            return RedirectToAction("ListPolicy");
        }
        /// <summary>
        /// Gets a petition of update policy view to update a policy
        /// </summary>
        /// <param name="id">Policy id to update a policy</param>
        /// <returns>Redirects to a policy edith view</returns>
       // [AuthorizeRole(IsAdminExclusive = true)]
        public ActionResult UpdatePolicy(int id)
        {
            if(id !=0)
            {
                Policy policy = _policyBll.GetPolicy(id);
                var policyViewModel = new PolicyViewModel();
                policyViewModel.PolicyToUpdate = policy;
                return View(policyViewModel);
            }
            else
            {
                return RedirectToAction("ListPolicy");
            }
        }
        /// <summary>
        /// Gets request from a view to edtih a policy
        /// </summary>
        /// <param name="policy">Policy with data to update</param>
        /// <returns>Redirects to a policy list view</returns>
       // [AuthorizeRole(IsAdminExclusive = true)]
        public ActionResult EditPolicy(PolicyViewModel model)
        {
            var policy = new Policy();
            policy = model.PolicyToUpdate;

            var validImageTypes = new string[]
            {
                "image/gif",
                "image/jpeg",
                "image/pjpeg",
                "image/png"
            };

            if (model.ImageUpload != null && !validImageTypes.Contains(model.ImageUpload.ContentType))
            {
                ModelState.AddModelError("ImageUpload", "Please choose either a GIF, JPG or PNG image.");
            }

            if (policy.Id != 0)
            {
                try
                {
                    if (model.ImageUpload != null)
                    {
                        if (System.IO.File.Exists(System.IO.Path.Combine(Server.MapPath(policy.ImagePath), policy.ImageName)))
                        {
                            System.IO.File.Delete(System.IO.Path.Combine(Server.MapPath(policy.ImagePath), policy.ImageName));
                        }

                        var imageName = Guid.NewGuid();
                        policy.ImageName = imageName + System.IO.Path.GetExtension(model.ImageUpload.FileName);

                        model.ImageUpload.SaveAs(System.IO.Path.Combine(Server.MapPath(policy.ImagePath), policy.ImageName));
                    }

                    _policyBll.EditPolicy(policy);
                }
                catch (PolicyAlreadyExistException)
                {
                    ModelState.AddModelError("Title", "Title Already Exist");
                }
            }

            return RedirectToAction("ListPolicy");
        }
       // [AuthorizeRole(IsCollaboratorExclusive = true)]
        public ActionResult Policy(int page=1, int pageSize=6)
        {
            var policy = _policyBll.GetAll();
            PagedList<Policy> model = new PagedList<Policy>(policy, page, pageSize);
            return View(model);
        }
       // [AuthorizeRole(IsCollaboratorExclusive = true)]
        public ActionResult PolicyDetail(int id)
        {
            var policyDetail = _policyBll.GetPolicy(id);
            return View(policyDetail);
        }
        #endregion

    }
}