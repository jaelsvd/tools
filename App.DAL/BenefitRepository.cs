using App.Entities;
using System.Collections.Generic;
using System.Linq;

namespace App.DAL
{
    /// <summary>
    /// Class contains methods to interact with DB
    /// </summary>
    public class BenefitRepository
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
        public BenefitRepository()
        {
            _context = new MindDBContext();
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Insert a benefit at DB
        /// </summary>
        /// <param name="benefit">Benefit object to insert at DB</param>
        public void InsertBenefit(Benefit benefit)
        {
            _context.Benefits.Add(benefit);
            _context.SaveChanges();

        }
        /// <summary>
        /// Update a benefit at DB
        /// </summary>
        /// <param name="benefit">benefit object to update</param>
        public void UpdateBenefit(Benefit benefit)
        {
            Benefit b = _context.Benefits.FirstOrDefault(x => x.Id == benefit.Id);
            b.Title = benefit.Title;
            b.Body = benefit.Body;
            b.ImageName = benefit.ImageName;
            _context.SaveChanges();
        }
        /// <summary>
        /// Delete a specific benefit 
        /// </summary>
        /// <param name="benefit">benefit object to delete</param>
        public void DeleteBenefit(Benefit benefit)
        {
            _context.Benefits.Remove(benefit);
            _context.SaveChanges();
            
        }
        /// <summary>
        /// Consult all benefits at DB
        /// </summary>
        /// <returns>Returns a object benefits list</returns>
        public List<Benefit> GetAll()
        {
            return _context.Benefits.OrderBy(x => x.CreateDate).ToList();
        }
        /// <summary>
        /// Consults a benefit filtered by title
        /// </summary>
        /// <param name="tittle">Title of benefit to consult</param>
        /// <returns>Returns a benefit object</returns>
        public Benefit GetByTitle(string tittle)
        {
            return _context.Benefits.FirstOrDefault(x => x.Title == tittle);
        }
        /// <summary>
        /// Consults a benefit filtered by Id
        /// </summary>
        /// <param name="id">Id of benefit to consult</param>
        /// <returns>Returns a benefit object</returns>
        public Benefit GetById(int id)
        {
            return _context.Benefits.FirstOrDefault(x => x.Id == id);
        }
        #endregion
    }
}
