using App.BLL;
using App.Entities;
using App.Security;
using App.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace App.Controllers
{
    /// <summary>
    /// Class to interact with benefit eventcategory layer and category views
    /// </summary>
    public class EventCategoryController : Controller
    {
        #region Instances
        /// <summary>
        /// EventCategoryBusiness instance to interact to eventcategory business layer
        /// </summary>
        EventCategoryBusiness _categoryBll;
        #endregion

        #region Constructors
        /// <summary>
        /// Initialize EventCategoryBusiness instance
        /// </summary>
        public EventCategoryController()
        {
            _categoryBll = new EventCategoryBusiness();
        }
        #endregion

        #region Public Methods
        //[AuthorizeRole(IsAdminExclusive = true)]
        public ActionResult ListCategories()
        {
            List<EventCategory> categories = _categoryBll.GetAll();
            return View(categories);
        }
       // [AuthorizeRole(IsAdminExclusive = true)]
        public ActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
       // [AuthorizeRole(IsAdminExclusive = true)]
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
                    ModelState.AddModelError("Name", "Name Already Exist");
                }
            }
            return View();
        }
       // [AuthorizeRole(IsAdminExclusive = true)]
        public ActionResult DeleteCategory(int id)
        {
            if (id != 0)
            {
                _categoryBll.RemoveCategoryt(id);
            }


            return RedirectToAction("ListCategories");
        }
       // [AuthorizeRole(IsAdminExclusive = true)]
        public ActionResult UpdateCategory(int id)
        {
            if (id != 0)
            {
                EventCategory category = _categoryBll.GetCategory(id);
                return View(category);
            }
            else
            {
                return RedirectToAction("ListCategories");
            }
        }
       // [AuthorizeRole(IsAdminExclusive = true)]
        public ActionResult EditCategory(EventCategory category)
        {
            if (category.Id != 0)
            {
                _categoryBll.EditCategory(category);
            }

            return RedirectToAction("ListCategories");
        }
        #endregion
    }
}