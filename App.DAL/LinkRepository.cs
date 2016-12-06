using App.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace App.DAL
{
    /// <summary>
    /// Class contains methods to interact with DB
    /// </summary>
    public class LinkRepository
    {
        #region Instance Members
        /// <summary>
        /// Instance of IntegrateDBContext(Contains methods of entity framework)
        /// </summary>
        private MindDBContext _context;
        #endregion

        #region Constructor
        /// <summary>
        /// Initialize _context instance
        /// </summary>
        public LinkRepository()
        {
            _context = new MindDBContext();
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Insert a link in the DB
        /// </summary>
        /// <param name="link">Link object to insert at DB</param>
        public void InsertLink(Link link)
        {
            _context.Links.Add(link);
            _context.SaveChanges();

        }
        /// <summary>
        /// Update a link at DB
        /// </summary>
        /// <param name="link">Link object to update</param>
        public void UpdateLink(Link link)
        {
            Link l = _context.Links.FirstOrDefault(x => x.Id == link.Id);
            l.Name = link.Name;
            l.Description = link.Description;
            l.AccessLink = link.AccessLink;
            l.IsFrequent = link.IsFrequent;
            l.ImageName = link.ImageName;
            _context.SaveChanges();
        }
        /// <summary>
        /// Delete a specific Link
        /// </summary>
        /// <param name="link">Link object to delete</param>
        public void DeleteLink(Link link)
        {
            _context.Links.Remove(link);
            _context.SaveChanges();
            
        }
        /// <summary>
        ///  Consult all links in the DB
        /// </summary>
        /// <returns>Returns link object list</returns>
        public List<Link> GetAll()
        {
            return _context.Links.ToList();
        }
        /// <summary>
        /// Consults a link filtered by link
        /// </summary>
        /// <param name="link">Name of link to consult</param>
        /// <returns>Returns a Link object</returns>
        public Link GetByLink(String link)
        {
            return _context.Links.FirstOrDefault(x => x.AccessLink == link);
        }
        /// <summary>
        /// Consults a link filtered by Id
        /// </summary>
        /// <param name="id">Id of link to consult</param>
        /// <returns>Returns a link object</returns>
        public Link GetById(int id)
        {
            return _context.Links.FirstOrDefault(x => x.Id == id);
        }
        public List<Link> GetAllFrequent()
        {
            return _context.Links.Where(x => x.IsFrequent).ToList();
        }    
        #endregion
    }
}
