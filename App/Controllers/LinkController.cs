using App.BLL;
using App.Entities;
using System.Web.Mvc;
using System.Linq;
using App.ViewModels;
using App.Security;
using System;
using PagedList;

namespace App.Controllers
{
    /// <summary>
    /// Class to interact with benefit bussiness layer and link views
    /// </summary>
    public class LinkController : BaseSecurityController
    {
        #region Instances
        /// <summary>
        /// LinkBusiness instance to interact to link business layer
        /// </summary>
        private LinkBusiness _linksBll;
        #endregion

        #region Constructor
        /// <summary>
        /// Initialize LinkBusiness and FileBusiness instances
        /// </summary>
        public LinkController()
        {
            _linksBll = new LinkBusiness();
        }
        #endregion

        #region Public Methods
      //  [AuthorizeRole]
        public ActionResult Index()
        {
            if(CurrentUser.isAdmin)
            {
                return RedirectToAction("ListLinks");
            }
            else
            {
                return RedirectToAction("Links");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
       // [AuthorizeRole(IsAdminExclusive = true)]
        public ActionResult CreateLink()
        {

            return View();
        }
        /// <summary>
        /// Gets a petition of create link view to create a new link
        /// </summary>
        /// <param name="model">LinkViewModel object with data to create a new link</param>
        /// <returns>Redirects to Links List View</returns>
        [HttpPost]
      //  [AuthorizeRole(IsAdminExclusive = true)]
        public ActionResult CreateLink(LinkViewModel model)
        {
            Link link = new Link();

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
                    link = model.LinkModel;
                    Guid imageName = Guid.NewGuid();
                    link.ImageName = imageName + System.IO.Path.GetExtension(model.ImageUpload.FileName);
                    
                    model.ImageUpload.SaveAs(System.IO.Path.Combine(Server.MapPath(link.ImagePath), link.ImageName));

                    _linksBll.AddLink(link);
                    return RedirectToAction("ListLinks");
                }
                catch (LinkAlreadyExistException)
                {
                    ModelState.AddModelError("Name", "Name Already Exist");
                }
            }

            return View();
        }
        /// <summary>
        /// Load a link list view
        /// </summary>
        /// <returns>Returns link list view</returns>
       // [AuthorizeRole(IsAdminExclusive = true)]
        public ActionResult ListLinks()
        {
            var links = _linksBll.GetAll();
            return View(links);
        }
        /// <summary>
        /// Gets a link id to delete link 
        /// </summary>
        /// <param name="id">id of link to delete</param>
        /// <returns>Redirects to links list view</returns>
       // [AuthorizeRole(IsAdminExclusive = true)]
        public ActionResult DeleteLink(int id)
        {
            if (id != 0)
            {
                var link = _linksBll.GetLink(id);
                if (System.IO.File.Exists(System.IO.Path.Combine(Server.MapPath(link.ImagePath), link.ImageName)))
                {
                    System.IO.File.Delete(System.IO.Path.Combine(Server.MapPath(link.ImagePath), link.ImageName));
                }
                _linksBll.RemoveLink(id);
            }
            return RedirectToAction("ListLinks");
        }
        /// <summary>
        /// Gets a petition of update link view to update a link
        /// </summary>
        /// <param name="id">Link Id to update a the link</param>
        /// <returns>Redirects to link edith view</returns>
       // [AuthorizeRole(IsAdminExclusive = true)]
        public ActionResult UpdateLink(int id)
        {
            if (id != 0)
            {
                Link link = _linksBll.GetLink(id);
                var linkViewModel = new LinkViewModel();
                linkViewModel.LinkToUpdate = link;
                return View(linkViewModel);
            }
            else
            {
                return RedirectToAction("ListLinks");
            }
        }
        /// <summary>
        /// Gets request from a view to edit a link
        /// </summary>
        /// <param name="link">Link with data to update</param>
        /// <returns>Redirects to a links list view</returns>
       // [AuthorizeRole(IsAdminExclusive = true)]
        public ActionResult EditLink(LinkViewModel model)
        {
            var link = new Link();
            link = model.LinkToUpdate;

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

            if (link.Id != 0)
            {
                try
                {
                    if (model.ImageUpload != null)
                    {
                        if (System.IO.File.Exists(System.IO.Path.Combine(Server.MapPath(link.ImagePath), link.ImageName)))
                        {
                            System.IO.File.Delete(System.IO.Path.Combine(Server.MapPath(link.ImagePath), link.ImageName));
                        }

                        var imageName = Guid.NewGuid();
                        link.ImageName = imageName + System.IO.Path.GetExtension(model.ImageUpload.FileName);

                        model.ImageUpload.SaveAs(System.IO.Path.Combine(Server.MapPath(link.ImagePath), link.ImageName));
                    }

                    _linksBll.EditLink(link);
                }
                catch (LinkAlreadyExistException)
                {
                    ModelState.AddModelError("Link", "Link Already Exist");
                }
            }
            return RedirectToAction("ListLinks");
        }
        /// <summary>
        /// This method displays a list of link
        /// </summary>
        /// <returns>Returns a view with all link</returns>
       // [AuthorizeRole(IsCollaboratorExclusive = true)]
        public ActionResult Links(int page=1, int pageSize=6)
        {
            var link = _linksBll.GetAll();
            PagedList<Link> model = new PagedList<Link>(link, page, pageSize);
            return View(model);
        }
        #endregion

    }
}
