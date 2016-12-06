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
    /// Class to interact with news business layer and news views
    /// </summary>
    public class NewsController : BaseSecurityController
    {
        #region Instance Members
        /// <summary>
        /// NewsBusiness instance to interact to news business layer
        /// </summary>
        private NewsBusiness _newsBll;
        #endregion

        #region Constructor
        /// <summary>
        /// Initialize NewsBusiness and FileBusiness instances
        /// </summary>
        public NewsController()
        {
            _newsBll = new NewsBusiness();
        }
        #endregion

       
        [AuthorizeRole]
        public ActionResult Index()
        {
            if(CurrentUser.isAdmin)
            {
                return RedirectToAction("ListNews");
            }
            else
            {
                return RedirectToAction("News");
            }
        }

        #region Public Methods
        /// <summary>
        /// Load create news view
        /// </summary>
        /// <returns>Returns a create news view</returns>
        //[AuthorizeRole(IsAdminExclusive = true)]
        public ActionResult CreateNews()
        {
            return View();
        }
        
        [HttpPost]
       // [AuthorizeRole(IsAdminExclusive =true)]
        public ActionResult CreateNews(NewsViewModel model)
        {
            News news = new News();

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
                    news = model.NewsModel;
                    Guid imageName = Guid.NewGuid();
                    news.ImageName = imageName + System.IO.Path.GetExtension(model.ImageUpload.FileName);

                    model.ImageUpload.SaveAs(System.IO.Path.Combine(Server.MapPath(news.ImagePath), news.ImageName));
                    
                    _newsBll.AddNews(news);

                    return RedirectToAction("ListNews");
                }
                catch (NewsAlreadyExistException)
                {
                    ModelState.AddModelError("Title", "Title Already Exists");
                }
            }
            return View();
        }
        /// <summary>
        /// Loads a list of news view
        /// </summary>
        /// <returns>News view list</returns>
        //[AuthorizeRole(IsAdminExclusive = true)]
        public ActionResult ListNews()
        {
            var news = _newsBll.GetAll();
            return View(news);
        }
        /// <summary>
        /// Gets a news id to delete news
        /// </summary>
        /// <param name="id">Id of news to delete</param>
        /// <returns>Redirects to a list of news view</returns>
       // [AuthorizeRole(IsAdminExclusive = true)]
        public ActionResult DeleteNews(int id)
        {
            if (id != 0)
            {
                var news = _newsBll.GetNews(id);
                if (System.IO.File.Exists(System.IO.Path.Combine(Server.MapPath(news.ImagePath), news.ImageName)))
                {
                    System.IO.File.Delete(System.IO.Path.Combine(Server.MapPath(news.ImagePath), news.ImageName));
                }
                _newsBll.RemoveNews(id);
            }
            return RedirectToAction("ListNews");
        }
        /// <summary>
        /// Gets a petition of a news update view to update the news
        /// </summary>
        /// <param name="id">News Id to update a news item</param>
        /// <returns>Redirects to an edith news view</returns>
        //[AuthorizeRole(IsAdminExclusive = true)]
        public ActionResult UpdateNews(int id)
        {
            if (id != 0)
            {
                News news = _newsBll.GetNews(id);
                NewsViewModel newsViewModel = new NewsViewModel();
                newsViewModel.NewsToUpdate = news;
                return View(newsViewModel);
            }
            else
            {
                return RedirectToAction("ListNews");
            }
        }
        /// <summary>
        /// Gets a request from a view to edith a news item
        /// </summary>
        /// <param name="news">News with data to update</param>
        /// <returns>Redirects to a news list view</returns>
        //[AuthorizeRole(IsAdminExclusive = true)]
        public ActionResult EditNews(NewsViewModel model)
        {
            var news = new News();
            news = model.NewsToUpdate;

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

            if (news.Id != 0)
            {
                try
                {
                    if (model.ImageUpload != null)
                    {
                        if (System.IO.File.Exists(System.IO.Path.Combine(Server.MapPath(news.ImagePath), news.ImageName)))
                        {
                            System.IO.File.Delete(System.IO.Path.Combine(Server.MapPath(news.ImagePath), news.ImageName));
                        }

                        var imageName = Guid.NewGuid();
                        news.ImageName = imageName + System.IO.Path.GetExtension(model.ImageUpload.FileName);

                        model.ImageUpload.SaveAs(System.IO.Path.Combine(Server.MapPath(news.ImagePath), news.ImageName));
                    }

                    _newsBll.EditNews(news);
                }
                catch (NewsAlreadyExistException)
                {
                    ModelState.AddModelError("Title", "Title Already Exist");
                }
            }

            return RedirectToAction("ListNews");
        }

        /// <summary>
        /// This method displays a list of news
        /// </summary>
        /// <returns>Returns a view with all news</returns>
        //[AuthorizeRole(IsCollaboratorExclusive = true)]
        public ActionResult News(int page=1, int pageSize=6)
        {
            var news = _newsBll.GetAll();
            PagedList<News> model = new PagedList<News>(news, page, pageSize);
            return View(model);

        }
        /// <summary>
        /// Displays a specifict news item
        /// </summary>
        /// <param name="id">Selects the Id of the news item to display</param>
        /// <returns>A view with the news item content </returns>
        //[AuthorizeRole(IsCollaboratorExclusive = true)]
        public ActionResult View(int id)
        {
            var view = _newsBll.GetNews(id);
            return View(view);
        }
       
        #endregion
    }
}
