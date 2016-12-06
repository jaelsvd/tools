using App.DAL;
using App.Entities;
using System;
using System.Collections.Generic;

namespace App.BLL
{
    /// <summary>
    /// Class to interact with data layer on news module
    /// </summary>
    public class PolicyBusiness
    {
        #region Instance Members
        /// <summary>
        /// Policy repository instance to interact with data layer
        /// </summary>
        private PolicyRepository _policyRepo;
        #endregion
        #region Constructor
        /// <summary>
        /// Initialize Policy, File and PolicyFile repository instances
        /// </summary>
        public PolicyBusiness()
        {
            _policyRepo = new PolicyRepository();
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Sends a policy object to data layer to insert into the DB
        /// </summary>
        /// <param name="policy">Policy object to insert in the DB</param>
        public void AddPolicy(Policy policy)
        {
            if (PolicyExistsId(policy))
            {
                throw new PolicyAlreadyExistException();
            }

            policy.Date = DateTime.Now;
            policy.Update = DateTime.Now;
            _policyRepo.InsertPolicy(policy);
        }
        /// <summary>
        /// Sends policy object to data layer to delete from DB
        /// </summary>
        /// <param name="id">Id of policy to delete from the DB</param>
        public void RemovePolicy(int id)
        {
            Policy policy = _policyRepo.GetById(id);
            if (PolicyExistsId(policy))
            {
                _policyRepo.DeletePolicy(policy);
            }
        }
        /// <summary>
        /// Sends policy objet to data layer to update in the DB
        /// </summary>
        /// <param name="policy">Policy object to update in the DB</param>
        public void EditPolicy(Policy policy)
        {
            if (PolicyExistsId(policy))
            {
                _policyRepo.UpdatePolicy(policy);
            }
        }
        /// <summary>
        /// Sends a request to data layer to consult all news
        /// </summary>
        /// <returns>Policy list object</returns>
        public List<Policy> GetAll()
        {
            return _policyRepo.GetAll();
        }
        /// <summary>
        /// Validate if policy exists in the DB searched by Title
        /// </summary>
        /// <param name="policy">Policy object to consult if exists</param>
        /// <returns>Returns true or false to request if exists or not</returns>
        private bool PolicyExists(Policy policy)
        {
            var policyBLA = _policyRepo.GetPolicyByTitle(policy.Title);
            return policyBLA != null;
        }
        /// <summary>
        /// Validate if policy exists in the DB searched by Id
        /// </summary>
        /// <param name="policy">Policy object to consult if exists</param>
        /// <returns>Returns true or false to request if exists or not</returns>
        private bool PolicyExistsId(Policy policy)
        {
            var policybLA = _policyRepo.GetById(policy.Id);
            return policybLA != null;
        }
        /// <summary>
        /// Sends request to data layer to consult a policy item
        /// </summary>
        /// <param name="id">Id of policy to consult</param>
        /// <returns>A policy object</returns>
        public Policy GetPolicy(int id)
        {
            Policy policy = _policyRepo.GetById(id);
            return policy;
        }
        #endregion
    }
}
  