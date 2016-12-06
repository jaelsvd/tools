using App.BLL;
using App.Entities;
using App.Security;
using App.ViewModels;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace App.Controllers
{
    /// <summary>
    /// Class to interact with event bussiness layer and event views
    /// </summary>
    public class EventController : BaseSecurityController
    {
        #region Instance Members
        /// <summary>
        /// EventBusiness instance to interact to event business layer
        /// </summary>
        private EventBusiness _eventBll;
        /// <summary>
        /// EventCategoryBusiness instance to interact to eventcategory business layer
        /// </summary>
        private EventCategoryBusiness _categoryBll;
        #endregion

        #region Constructors
        /// <summary>
        /// Initialize EventBusiness and FileBusiness instances
        /// </summary>
        public EventController()
        {
            _eventBll = new EventBusiness();
            _categoryBll = new EventCategoryBusiness();
        }
        #endregion

        #region Public Methods
        [AuthorizeRole]
        public ActionResult Index()
        {
            if (CurrentUser.isAdmin)
            {
                return RedirectToAction("ListEvents");
            }
            else
            {
                return RedirectToAction("Events");
            }
        }
        /// <summary>
        /// Load create event view
        /// </summary>
        /// <returns>Returns create event view</returns>
       // [AuthorizeRole(IsAdminExclusive = true)]
        public ActionResult CreateEvent()
        {
            List<EventCategory> categories = _categoryBll.GetAll();
            var viewModel = new EventViewModel(categories);

            return View(viewModel);
        }
        [HttpPost]
        //[AuthorizeRole(IsAdminExclusive = true)]
        public ActionResult CreateEvent(EventViewModel model)
        {
            Event evento = new Event();

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
                    evento = model.EventModel;
                    Guid imageName = Guid.NewGuid();
                    evento.ImageName = imageName + System.IO.Path.GetExtension(model.ImageUpload.FileName);
                    //Save image on a file
                    model.ImageUpload.SaveAs(System.IO.Path.Combine(Server.MapPath(evento.ImagePath), evento.ImageName));

                    _eventBll.AddEvent(evento);

                    return RedirectToAction("ListEvents");
                }
                catch (EventAlreadyExistException)
                {
                    ModelState.AddModelError("Title", "Title Already Exist");
                }
            }

            List<EventCategory> categories = _categoryBll.GetAll();
            var viewModel = new EventViewModel(categories);

            return View(viewModel);
        }
        /// <summary>
        /// Load a event list view
        /// </summary>
        /// <returns>Returns event list view</returns>
        //[AuthorizeRole(IsAdminExclusive=true)]
        public ActionResult ListEvents()
        {
            var events = _eventBll.GetAll();
            return View(events);
        }
        /// <summary>
        /// Gets an event id to delete event 
        /// </summary>
        /// <param name="id">id of event to delete</param>
        /// <returns>Redirects to event list view</returns>
       // [AuthorizeRole(IsAdminExclusive=true)]
        public ActionResult DeleteEvent(int id)
        {
            if (id != 0)
            {
                var evento = _eventBll.GetEvent(id);
                if (System.IO.File.Exists(System.IO.Path.Combine(Server.MapPath(evento.ImagePath), evento.ImageName)))
                {
                    System.IO.File.Delete(System.IO.Path.Combine(Server.MapPath(evento.ImagePath), evento.ImageName));
                }
                _eventBll.RemoveEvent(id);
            }

            return RedirectToAction("ListEvents");

        }
        /// <summary>
        /// Gets a petition of update event view to update a event
        /// </summary>
        /// <param name="model">Event Id to update a the event</param>
        /// <returns>Redirects to event edit view</returns>
       // [AuthorizeRole(IsAdminExclusive = true)]
        public ActionResult UpdateEvent(int id)
        {
            if (id != 0)
            {
                Event evento = _eventBll.GetEvent(id);
                var categories = _categoryBll.GetAll();
                var viewModel = new EventViewModel(categories);
                viewModel.EventToUpdate = evento;

                return View(viewModel);
            }
            else
            {
                return RedirectToAction("ListEvents");
            }
        }
        /// <summary>
        /// Gets request from a view to edit a event
        /// </summary>
        /// <param name="evento">Event with data to update</param>
        /// <returns>Redirects to a event list view</returns>
       // [AuthorizeRole(IsAdminExclusive = true)]
        public ActionResult EditEvent(EventViewModel model)
        {
            var evento = new Event();
            evento = model.EventToUpdate;
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

            if (evento.Id != 0)
            {
                try
                {
                    if (model.ImageUpload != null)
                    {
                        if (System.IO.File.Exists(System.IO.Path.Combine(Server.MapPath(evento.ImagePath), evento.ImageName)))
                        {
                            System.IO.File.Delete(System.IO.Path.Combine(Server.MapPath(evento.ImagePath), evento.ImageName));
                        }

                        var imageName = Guid.NewGuid();
                        evento.ImageName = imageName + System.IO.Path.GetExtension(model.ImageUpload.FileName);

                        model.ImageUpload.SaveAs(System.IO.Path.Combine(Server.MapPath(evento.ImagePath), evento.ImageName));
                    }

                    _eventBll.EditEvent(evento);
                }
                catch (EventAlreadyExistException)
                {
                    ModelState.AddModelError("Title", "Title Already Exist");
                }
            }

            return RedirectToAction("ListEvents");
        }
        [HttpPost]
      //  [AuthorizeRole(IsAdminExclusive = true)]
        public ActionResult CreateCategory(EventViewModel model)
        {
            EventCategory eventCategory = new EventCategory();
            eventCategory.Name = model.CategoryName;

            if (model.CategoryName != "" && model.CategoryName != null)
            {
                try
                {
                    _categoryBll.AddCategory(eventCategory);

                    return RedirectToAction("CreateEvent", "Event");
                }
                catch (CategoryAlreadyExistException)
                {
                    ViewBag.AlreadyExist = "La categoria ya existe";
                    List<EventCategory> categories = _categoryBll.GetAll();
                    var viewModel = new EventViewModel(categories);
                    return View("CreateEvent", viewModel);
                }
            }
            return View();
        }
        //[AuthorizeRole(IsCollaboratorExclusive = true)]
        public ActionResult Events(int page=1, int pageSize=6)
        {
            var events = _eventBll.GetAll();
            PagedList<Event> model = new PagedList<Event>(events, page, pageSize);
            return View(model);
        }
        //[AuthorizeRole(IsCollaboratorExclusive=true)]
        public ActionResult EventDetail(int id)
        {
            var eventDetail = _eventBll.GetEvent(id);
            return View(eventDetail);
        }
        #endregion
    }
}
