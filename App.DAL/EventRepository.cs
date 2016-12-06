using App.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System;

namespace App.DAL
{
    /// <summary>
    /// Class contains methods to interact with DB
    /// </summary>
    public class EventRepository
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
        public EventRepository()
        {
            _context = new MindDBContext();
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Insert a event at DB
        /// </summary>
        /// <param name="evento">Event object to insert at DB</param>
        public void InsertEvent(Event evento)
        {
            _context.Events.Add(evento);
            _context.SaveChanges();

        }
        /// <summary>
        /// Update a event at DB
        /// </summary>
        /// <param name="evento">event object to update</param>
        public void UpdateEvent(Event evento)
        {
            Event ev = _context.Events.FirstOrDefault(x => x.Id == evento.Id);
            ev.Body = evento.Body;
            ev.CategoryId = evento.CategoryId;
            ev.Title = evento.Title;
            ev.ImageName = evento.ImageName;
            if(evento.EventDate != new DateTime())
                ev.EventDate = evento.EventDate;
            _context.SaveChanges();
        }
        /// <summary>
        /// Delete a specific event 
        /// </summary>
        /// <param name="evento">event object to delete</param>
        public void DeleteEvent(Event evento)
        {
            _context.Events.Remove(evento);
            _context.SaveChanges();

        }
        /// <summary>
        /// Consult all events at DB
        /// </summary>
        /// <returns>Returns a object event list</returns>
        public List<Event> GetAll()
        {
            return _context.Events.Where(x => x.EventDate >= DateTime.Now).OrderBy(x => x.CreateDate).Include(x => x.Category).ToList();
        }
        /// <summary>
        /// Consults a event filtered by title
        /// </summary>
        /// <param name="title">Title of event to consult</param>
        /// <returns>Returns a event object</returns>
        public Event GetByTitle(string title)
        {
            return _context.Events.FirstOrDefault(x => x.Title == title);
        }
        /// <summary>
        /// Consults a event filtered by id
        /// </summary>
        /// <param name="id">Id of event to consult</param>
        /// <returns>Returns a event object</returns>
        public Event GetById(int id)
        {
            return _context.Events.FirstOrDefault(x => x.Id == id);
        }
        #endregion
    }
}
