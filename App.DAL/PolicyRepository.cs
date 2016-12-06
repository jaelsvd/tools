using App.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace App.DAL
{
    /// <summary>
    /// This class contains methos to interact with the DB
    /// </summary>
    public class PolicyRepository
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
        public PolicyRepository()
        {
            _context = new MindDBContext();
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Insert policy in the DB
        /// </summary>
        /// <param name="policy">Policy object to insert in the DB</param>
        public void InsertPolicy(Policy policy)
        {
            _context.Policy.Add(policy);
            _context.SaveChanges();
        }
        /// <summary>
        /// Update policy in the DB
        /// </summary>
        /// <param name="policy">Policy objecto to update</param>
        public void UpdatePolicy(Policy policy)
        {
            Policy p = _context.Policy.FirstOrDefault(x => x.Id == policy.Id);
            p.Title = policy.Title;
            p.Body = policy.Body;
            p.Update = DateTime.Now;
            p.ImageName = policy.ImageName;
            _context.SaveChanges();
        }
        /// <summary>
        /// Delete Policy
        /// </summary>
        /// <param name="policy">Policy object to delete</param>
        public void DeletePolicy(Policy policy)
        {
            _context.Policy.Remove(policy);
            _context.SaveChanges();

        }
        /// <summary>
        /// Consult all policy at DB
        /// </summary>
        /// <returns>Returns a policy list object</returns>       
        public List<Policy> GetAll()
        {
            return _context.Policy.OrderBy(x => x.Date).ToList();
        }
        /// <summary>
        /// Consults policies filtered by title
        /// </summary>
        /// <param name="title">Title of policies to consult</param>
        /// <returns>Returns a policy item object</returns>
        public Policy GetPolicyByTitle(string title)
        {
            return _context.Policy.FirstOrDefault(x => x.Title == title);
        }
        /// <summary>
        /// Consults policy filtered by Id
        /// </summary>
        /// <param name="id">Id of policy to consult</param>
        /// <returns>Returns a policy item object</returns>
        public Policy GetById(int id)
        {
            return _context.Policy.FirstOrDefault(x => x.Id == id);

        }
        #endregion

    }
}
