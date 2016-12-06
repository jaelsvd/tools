using App.DAL;
using App.Entities;
using System.Collections.Generic;

namespace App.BLL
{
    /// <summary>
    /// Class to interact with data layer on eventcategory module
    /// </summary>
    public class EventCategoryBusiness
    {
        #region Instance Members
        /// <summary>
        /// EventCategory repository instance to interact with data layer
        /// </summary>
        private EventCategoryRepository _categoryRepo;
        #endregion

        #region Constructors
        /// <summary>
        /// Initialize event category repository instance
        /// </summary>
        public EventCategoryBusiness()
        {
            _categoryRepo = new EventCategoryRepository();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Sends eventCategory object to data layer to insert at DB
        /// </summary>
        /// <param name="category">EventCategory object to insert at DB</param>
        public void AddCategory(EventCategory category)
        {
            if(CategoryExists(category))
                throw new CategoryAlreadyExistException();

            //insert eventcategory
            _categoryRepo.InsertCategory(category);
        }
        /// <summary>
        /// Sends eventCategory object to data layer to delete from DB
        /// </summary>
        /// <param name="id">Id of eventCategory to delete from DB</param>
        public void RemoveCategoryt(int id)
        {
            EventCategory category = _categoryRepo.GetById(id);
            if (CategoryExistsId(category))
            {
                _categoryRepo.DeleteCategory(category);
            }
        }
        /// <summary>
        /// Sends eventCategory object to data layer to update at DB
        /// </summary>
        /// <param name="category">EventCategory object to update at DB</param>
        public void EditCategory(EventCategory category)
        {
            if (CategoryExistsId(category))
            {
                _categoryRepo.UpdateCategory(category);
            }
        }
        /// <summary>
        /// sends a request to data layer to consult all event categories
        /// </summary>
        /// <returns>Returns a eventCategory object list</returns>
        public List<EventCategory> GetAll()
        {
            return _categoryRepo.GetAll();
        }
        /// <summary>
        /// Validate if categoryEvent exists at DB searching by name
        /// </summary>
        /// <param name="name">EventCategory object to consult if exist</param>
        /// <returns>Returns true or false to request if exists or not</returns>
        private bool CategoryExists(EventCategory category)
        {
            var categorybLA = _categoryRepo.GetByName(category.Name);
            return categorybLA != null;
        }
        /// <summary>
        /// Validate if categoryEvent exists at DB searching by id
        /// </summary>
        /// <param name="category">EventCategory object to consult if exist</param>
        /// <returns>Returns true or false to request if exists or not</returns>
        private bool CategoryExistsId(EventCategory category)
        {
            var categorybLA = _categoryRepo.GetById(category.Id);
            return categorybLA != null;
        }
        /// <summary>
        /// Sends request to data layer to consult a eventCategory
        /// </summary>
        /// <param name="id">Id of eventCategory to consult</param>
        /// <returns>Returns an EventCategory object</returns>
        public EventCategory GetCategory(int id)
        {
            EventCategory category = _categoryRepo.GetById(id);

            return category;
        }
        #endregion
    }
}
