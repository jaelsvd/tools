using App.DAL;
using App.Entities;
using System;
using System.Collections.Generic;

namespace App.BLL
{
    /// <summary>
    /// Class to interact with data layer on event module
    /// </summary>
    public class EventBusiness
    {
        #region Instance Members
        /// <summary>
        /// Event repository instance to interact with data layer
        /// </summary>
        private EventRepository _eventRepo;
        #endregion

        #region Constructors
        /// <summary>
        /// Initialize repository instances
        /// </summary>
        public EventBusiness()
        {
            _eventRepo = new EventRepository();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Sends event object to data layer to insert at DB
        /// </summary>
        /// <param name="evento">Event object to insert at DB</param>
        public void AddEvent(Event evento)
        {
            if (EventExists(evento))
            {
                throw new EventAlreadyExistException();
            }

            //insert event
            evento.CreateDate = DateTime.Now;
            _eventRepo.InsertEvent(evento);
        }
        /// <summary>
        /// Sends event object to data layer to delete from DB
        /// </summary>
        /// <param name="id">Id of event to delete from DB</param>
        public void RemoveEvent(int id)
        {
            Event evento = _eventRepo.GetById(id);
            if (EventExistsId(evento))
            {
                _eventRepo.DeleteEvent(evento);
            }
        }
        /// <summary>
        /// Sends event object to data layer to update at DB
        /// </summary>
        /// <param name="evento">evento object to update at DB</param>
        public void EditEvent(Event evento)
        {
            if (EventExistsId(evento))
            {
                _eventRepo.UpdateEvent(evento);
            }
        }
        /// <summary>
        /// sends a request to data layer to consult all events
        /// </summary>
        /// <returns>Returns a event object list</returns>
        public List<Event> GetAll()
        {
            return _eventRepo.GetAll();
        }
        /// <summary>
        /// Validate if event exists at DB searching by title
        /// </summary>
        /// <param name="evento">Event object to consult if exist</param>
        /// <returns>Returns true or false to request if exists or not</returns>
        private bool EventExists(Event evento)
        {
            var eventbLA = _eventRepo.GetByTitle(evento.Title);
            return eventbLA != null;
        }
        /// <summary>
        /// Validate if event exists at DB searching by id
        /// </summary>
        /// <param name="evento">Event object to consult if exist</param>
        /// <returns>Returns true or false to request if exists or not</returns>
        private bool EventExistsId(Event evento)
        {
            var eventbLA = _eventRepo.GetById(evento.Id);
            return eventbLA != null;
        }
        /// <summary>
        /// Sends request to data layer to consult a event
        /// </summary>
        /// <param name="id">Id of event to consult</param>
        /// <returns></returns>
        public Event GetEvent(int id)
        {
            Event evento = _eventRepo.GetById(id);

            return evento;
        }
        #endregion
    }
}

