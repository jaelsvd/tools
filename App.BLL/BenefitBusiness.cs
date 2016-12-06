using App.DAL;
using App.Entities;
using System;
using System.Collections.Generic;

namespace App.BLL
{
    /// <summary>
    /// Class to interact with data layer on benefit module
    /// </summary>
    public class BenefitBusiness
    {
        #region Private Instance Members
        /// <summary>
        /// Benefit repository instance to interact with data layer
        /// </summary>
        private BenefitRepository _benefitRepo;
        #endregion

        #region Constructors
        /// <summary>
        /// Initialize benefit repository instance
        /// </summary>
        public BenefitBusiness()
        {
            _benefitRepo = new BenefitRepository();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Sends benefit object to data layer to insert at DB
        /// </summary>
        /// <param name="benefit">Benefit object to insert at DB</param>
        public void AddBenefit(Benefit benefit)
        {
            if (BenefitExists(benefit))
            {
                throw new BenefitAlreadyExistException();
            }
            else
            {
                //insert benefit
                benefit.CreateDate = DateTime.Now;
                _benefitRepo.InsertBenefit(benefit);
            }
        }
        /// <summary>
        /// Sends benefit object to data layer to delete from DB
        /// </summary>
        /// <param name="id">Id of benefit to delete from DB</param>
        public void RemoveBenefit(int id)
        {
            Benefit benefit = _benefitRepo.GetById(id);
            if(BenefitExistsId(benefit))
            {
                _benefitRepo.DeleteBenefit(benefit);
            }
        }
        /// <summary>
        /// Sends benefit object to data layer to update at DB
        /// </summary>
        /// <param name="benefit">benefit object to update at DB</param>
        public void EditBenefit(Benefit benefit)
        {
            if (BenefitExistsId(benefit))
            {
                _benefitRepo.UpdateBenefit(benefit);
            }
        }
        /// <summary>
        /// sends a request to data layer to consult all benefits
        /// </summary>
        /// <returns>Returns a benefit object list</returns>
        public List<Benefit> GetAll()
        {
            return _benefitRepo.GetAll();
        }
        /// <summary>
        /// Validate if benefit exists at DB searching by title
        /// </summary>
        /// <param name="benefit">Benefit object to consult if exist</param>
        /// <returns>Returns true or false to request if exists or not</returns>
        private bool BenefitExists(Benefit benefit)
        {
            var benefitbLA = _benefitRepo.GetByTitle(benefit.Title);
            return benefitbLA != null;
        }
        /// <summary>
        /// Validate if benefit exists at DB searching by id
        /// </summary>
        /// <param name="benefit">Benefit object to consult if exist</param>
        /// <returns>Returns true or false to request if exists or not</returns>
        private bool BenefitExistsId(Benefit benefit)
        {
            var benefitbLA = _benefitRepo.GetById(benefit.Id);
            return benefitbLA != null;
        }
        /// <summary>
        /// Sends request to data layer to consult a benefit
        /// </summary>
        /// <param name="id">Id of benefit to consult</param>
        /// <returns></returns>
        public Benefit GetBenefit(int id)
        {
            Benefit benefit = _benefitRepo.GetById(id); 

            return benefit;
        }
        #endregion
    }
}
