using App.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace App.DAL
{
    /// <summary>
    /// This class contains methos to interact with the DB
    /// </summary>
    public class NewsRepository
    {
        #region Instance Members
        /// <summary>
        /// Instance of IntegrateDBContext (Contains methods of entity framework)
        /// </summary>
        private MindDBContext _context;
        #endregion

        #region Constructor
        /// <summary>
        /// Initialize _context instance
        /// </summary>
        public NewsRepository()
        {
            _context = new MindDBContext();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Insert news in the DB
        /// </summary>
        /// <param name="news">News object to insert in the DB</param>
        public void InsertNews(News news)
        {
            _context.News.Add(news);
            _context.SaveChanges();
        }
        /// <summary>
        /// Update news in the DB
        /// </summary>
        /// <param name="news">News objecto to update</param>
        public void UpdateNews(News news)
        {
            News n = _context.News.FirstOrDefault(x => x.Id == news.Id);
            n.Title = news.Title;
            n.Body = news.Body;
            n.Update = DateTime.Now;
            n.IsImportant = news.IsImportant;
            n.ImageName = news.ImageName;
            _context.SaveChanges();
        }
        /// <summary>
        /// Delete news
        /// </summary>
        /// <param name="news">News object to delete</param>
        public void DeleteNews(News news)
        {
            _context.News.Remove(news);
            _context.SaveChanges();
        }
        /// <summary>
        /// Consult all news at DB
        /// </summary>
        /// <returns>Returns a news list object</returns>
        public List<News> GetAll()
        {
            return _context.News.OrderBy(x => x.IsImportant).ThenBy(x => x.CreateDate).ToList();
        }
        /// <summary>
        /// Consults news filtered by title
        /// </summary>
        /// <param name="title">Title of news to consult</param>
        /// <returns>Returns a news item object</returns>
        public News GetNewsByTitle(string title)
        {
            return _context.News.FirstOrDefault(x => x.Title == title);
        }
        /// <summary>
        /// Consults news filtered by Id
        /// </summary>
        /// <param name="id">Id of news to consult</param>
        /// <returns>Returns a news item object</returns>
        public News GetById(int id)
        {
            return _context.News.FirstOrDefault(x => x.Id == id);
        }
        public List<News> GetAllImportant()
        {
            return _context.News.Where(x => x.IsImportant).OrderBy(x => x.CreateDate).ToList();
        }
        #endregion
    }
}
