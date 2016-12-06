using App.DAL;
using App.Entities;
using System;
using System.Collections.Generic;

namespace App.BLL
{
    /// <summary>
    /// Class to interact with data layer on news module
    /// </summary>
    public class NewsBusiness
    {
        #region Instance Members
        /// <summary>
        /// News repository instance to interact with data layer
        /// </summary>
        private NewsRepository _newsRepo;
        #endregion

        #region Constructor
        /// <summary>
        /// Initialize News, File and NewsFile repository instances
        /// </summary>
        public NewsBusiness()
        {
            _newsRepo = new NewsRepository();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Sends a news object to data layer to insert into the DB
        /// </summary>
        /// <param name="news">News object to insert in the DB</param>
        public void AddNews(News news)
        {
            if (NewsExists(news))
            {
                throw new NewsAlreadyExistException();
            }

            news.CreateBy = "ArkusNexus";
            news.UpdateBy = "ArkusNexus";
             news.CreateDate = DateTime.Now;
            news.Update = DateTime.Now;
            _newsRepo.InsertNews(news);
        }
        /// <summary>
        /// Sends news object to data layer to delete from DB
        /// </summary>
        /// <param name="camelCase">Id of news to delete from the DB</param>
        public void RemoveNews(int id)
        {
            News news = _newsRepo.GetById(id);
            if (NewsExistsId(news))
            {
                _newsRepo.DeleteNews(news);

            }
        }
        /// <summary>
        /// Sends news object to data layer to update in the DB
        /// </summary>
        /// <param name="news">news object to update in the DB</param>
        public void EditNews(News news)
        {
            if (NewsExistsId(news))
            {
                _newsRepo.UpdateNews(news);
            }
        }
        /// <summary>
        /// Sends a request to data layer to consult all news
        /// </summary>
        /// <returns>News list object</returns>
        public List<News> GetAll()
        {
            return _newsRepo.GetAll();
        }
        /// <summary>
        /// Validate if news exists in the DB searched by Title
        /// </summary>
        /// <param name="news">News object to consult if exists</param>
        /// <returns>Returns true or false to request if exists or not</returns>
        private bool NewsExists(News news)
        {
            var newsBLA = _newsRepo.GetNewsByTitle(news.Title);
            return newsBLA != null;

        }
        /// <summary>
        /// Validate if news exists in the DB searched by Id
        /// </summary>
        /// <param name="news">News object to consult if exists</param>
        /// <returns>Returns true or false to request if exists or not</returns>
        private bool NewsExistsId(News news)
        {
            var newsbLA = _newsRepo.GetById(news.Id);
            return newsbLA != null;
        }
        /// <summary>
        /// Sends request to data layer to consult a news item
        /// </summary>
        /// <param name="id">Id of news to consult</param>
        /// <returns>A news object</returns>
        public News GetNews(int id)
        {
            News news = _newsRepo.GetById(id);
            return news;
        }

        public List<News> GetImportantNews()
        {
            List<News> news = _newsRepo.GetAllImportant();
            
            return news;
        }

        #endregion

    }
}
