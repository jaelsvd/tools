using App.Entities;
using System.Collections.Generic;
using System.Linq;

namespace App.DAL
{
    /// <summary>
    /// Class contains methods to interact with DB
    /// </summary>
    public class EventCategoryRepository
    {
        #region Instance Members
        /// <summary>
        /// Instance of IntegrateDBContext(Contains methods of entity framework)
        /// </summary>
        private MindDBContext _context;
        #endregion

        #region Constructors
        /// <summary>
        /// Initialize _context instance
        /// </summary>
        public EventCategoryRepository()
        {
            _context = new MindDBContext();
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Insert a event category at DB
        /// </summary>
        /// <param name="category">EventCategory object to insert at DB</param>
        public void InsertCategory(EventCategory category)
        {
            _context.EventCategories.Add(category);
            _context.SaveChanges();

        }
        /// <summary>
        /// Update a event category at DB
        /// </summary>
        /// <param name="category">eventcategory object to update</param>
        public void UpdateCategory(EventCategory category)
        {
            EventCategory ec = _context.EventCategories.FirstOrDefault(x => x.Id == category.Id);
            ec.Name = category.Name;
            _context.SaveChanges();
        }
        /// <summary>
        /// Delete a specific event category 
        /// </summary>
        /// <param name="category">eventcategory object to delete</param>
        public void DeleteCategory(EventCategory category)
        {
            _context.EventCategories.Remove(category);
            _context.SaveChanges();

        }
        /// <summary>
        /// Consult all event categories at DB
        /// </summary>
        /// <returns>Returns a object eventcategory list</returns>
        public List<EventCategory> GetAll()
        {
            return _context.EventCategories.ToList();
        }
        /// <summary>
        /// Consults a eventcategory filtered by name
        /// </summary>
        /// <param name="name">Name of event category to consult</param>
        /// <returns>Returns a eventcategory object</returns>
        public EventCategory GetByName(string name)
        {
            return _context.EventCategories.FirstOrDefault(x => x.Name == name);
        }
        /// <summary>
        /// Consults a eventcategory filtered by id
        /// </summary>
        /// <param name="id">Id of event category to consult</param>
        /// <returns>Returns a eventcategory object</returns>
        public EventCategory GetById(int id)
        {
            return _context.EventCategories.FirstOrDefault(x => x.Id == id);
        }
        #endregion
    }
}
