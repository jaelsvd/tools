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
    /// Class to interact with benefit bussiness layer and benefit views
    /// </summary>
    public class BenefitController : BaseSecurityController
    {
        #region Private Instance Members
        /// <summary>
        /// BenefitBusiness instance to interact to benefit business layer
        /// </summary>
        private BenefitBusiness _benefitBll;
        #endregion

        #region Constructors
        /// <summary>
        /// Initialize BenefitBusiness and FileBusiness instances
        /// </summary>
        public BenefitController()
        {
            _benefitBll = new BenefitBusiness();
        }
        #endregion

        #region Public Methods
        //[AuthorizeRole]
        public ActionResult Index()
        {
            if(CurrentUser.isAdmin)
            {
                return RedirectToAction("ListBenefits");
            }
            else
            {
                return RedirectToAction("Benefits");
            }
        }
        /// <summary>
        /// Load create benefit view
        /// </summary>
        /// <returns>Returns create benefit view</returns>
      // [AuthorizeRole(IsAdminExclusive = true)]
        public ActionResult CreateBenefit()
        {

            return View();
        }
        /// <summary>
        /// Gets a petition of create benefit view to create a new benefit
        /// </summary>
        /// <param name="model">BenefitViewModel object with data to create a new benefit</param>
        /// <returns>Redirects to benefits list view</returns>
        [HttpPost]
      // [AuthorizeRole(IsAdminExclusive = true)]
        public ActionResult CreateBenefit(BenefitViewModel model)
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
                    var benefit = new Benefit();
                    benefit = model.BenefitModel;
                    Guid imageName = Guid.NewGuid();
                    benefit.ImageName = imageName + System.IO.Path.GetExtension(model.ImageUpload.FileName);
                    
                    model.ImageUpload.SaveAs(System.IO.Path.Combine(Server.MapPath(benefit.ImagePath), benefit.ImageName));
                    
                    _benefitBll.AddBenefit(benefit);
                   
                    return RedirectToAction("ListBenefits");
                }
                catch (BenefitAlreadyExistException)
                {
                    ModelState.AddModelError("Title", "Title Already Exist");
                }
            }
            return View();
        }
        /// <summary>
        /// Load a benefit list view
        /// </summary>
        /// <returns>Returns benefits list view</returns>
       // [AuthorizeRole(IsAdminExclusive = true)]
        public ActionResult ListBenefits()
        {
            var benefits = _benefitBll.GetAll();
            return View(benefits);
        }
        /// <summary>
        /// Gets a benefit id to delete benefit 
        /// </summary>
        /// <param name="id">id of benefit to delete</param>
        /// <returns>Redirects to benefits list view</returns>
        //[AuthorizeRole(IsAdminExclusive = true)]
        public ActionResult DeleteBenefit(int id)
        {
            if (id != 0)
            {
                var benefit = _benefitBll.GetBenefit(id);
                if (System.IO.File.Exists(System.IO.Path.Combine(Server.MapPath(benefit.ImagePath), benefit.ImageName)))
                {
                    System.IO.File.Delete(System.IO.Path.Combine(Server.MapPath(benefit.ImagePath), benefit.ImageName));
                }
                _benefitBll.RemoveBenefit(id);
            }
            
            return RedirectToAction("ListBenefits");

        }
        /// <summary>
        /// Gets a petition of update benefit view to update a benefit
        /// </summary>
        /// <param name="model">Benefit Id to update a the benefit</param>
        /// <returns>Redirects to benefits edith view</returns>
       // [AuthorizeRole(IsAdminExclusive = true)]
        public ActionResult UpdateBenefit(int id)
        {
            if (id != 0)
            {
                Benefit benefit = _benefitBll.GetBenefit(id);
                var benefitViewModel = new BenefitViewModel();
                benefitViewModel.BenefitToUpdate = benefit;

                return View(benefitViewModel);
            }
            else
            {
                return RedirectToAction("ListBenefits");
            }
        }
        /// <summary>
        /// Gets request from a view to edit a benefit
        /// </summary>
        /// <param name="benefit">Benefit with data to update</param>
        /// <returns>Redirects to a benefits list view</returns>
       // [AuthorizeRole(IsAdminExclusive = true)]
        public ActionResult EditBenefit(BenefitViewModel model)
        {
            var benefit = new Benefit();
            benefit = model.BenefitToUpdate;

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
            
            if (benefit.Id != 0)
            {
                try
                {
                    if(model.ImageUpload != null)
                    {
                        if (System.IO.File.Exists(System.IO.Path.Combine(Server.MapPath(benefit.ImagePath), benefit.ImageName)))
                        {
                            System.IO.File.Delete(System.IO.Path.Combine(Server.MapPath(benefit.ImagePath), benefit.ImageName));
                        }

                        var imageName = Guid.NewGuid();
                        benefit.ImageName = imageName + System.IO.Path.GetExtension(model.ImageUpload.FileName);

                        model.ImageUpload.SaveAs(System.IO.Path.Combine(Server.MapPath(benefit.ImagePath), benefit.ImageName));
                    }

                    _benefitBll.EditBenefit(benefit);
                }
                catch (BenefitAlreadyExistException)
                {
                    ModelState.AddModelError("Title", "Title Already Exist");
                }
            }

            return RedirectToAction("ListBenefits");
        }
        ///<summary>
        // userbenefits
        /// </summary>
        /// <returns></returns>
       // [AuthorizeRole(IsCollaboratorExclusive=true)]
        public ActionResult Benefits(int page=1, int pageSize=6)
        {
            var benefits = _benefitBll.GetAll();
            PagedList<Benefit> model = new PagedList<Benefit>(benefits, page, pageSize);
            return View(model);
        }
      //  [AuthorizeRole(IsCollaboratorExclusive=true)]
        public ActionResult BenefitDetail(int id)
        {
            var benefitdetail = _benefitBll.GetBenefit(id);
            return View(benefitdetail);
        }
        #endregion
    }
}
