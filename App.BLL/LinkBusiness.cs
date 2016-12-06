using App.DAL;
using App.Entities;
using System.Collections.Generic;

namespace App.BLL
{
    /// <summary>
    /// Class to interact with the data layer on link module
    /// </summary>
    public class LinkBusiness
    {
        #region Instance Member
        /// <summary>
        /// Link repository instance to interact with data layer
        /// </summary>
        private LinkRepository _linksRepo;
        #endregion

        #region Constructors
        /// <summary>
        /// Initialize link repository instance
        /// </summary>
        public LinkBusiness()
        {
            _linksRepo = new LinkRepository();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Sends link object to data layer to insert in the DB
        /// </summary>
        /// <param name="link">Link object to insert in the DB</param>
        public void AddLink(Link link)
        {
            if (LinkExistsId(link))
            {
                throw new LinkAlreadyExistException();
            }
            else
            {
                _linksRepo.InsertLink(link);
            }
        }
        /// <summary>
        /// Sends link object to data layer to delete from DB
        /// </summary>
        /// <param name="id">Id of link to delte from the DB</param>
        public void RemoveLink(int id)
        {
            Link link = _linksRepo.GetById(id);
            if (LinkExistsId(link))
            {
                _linksRepo.DeleteLink(link);

            }
        }
        /// <summary>
        /// Sends link object to data layer to update in the DB
        /// </summary>
        /// <param name="link">Link object to update in the DB</param>
        public void EditLink(Link link)
        {
            if (LinkExistsId(link))
            {
                _linksRepo.UpdateLink(link);
            }
        }
        /// <summary>
        /// Sends a request to a data layer to consult all benefits
        /// </summary>
        /// <returns>Returns a benefit object list</returns>
        public List<Link> GetAll()
        {
            return _linksRepo.GetAll();
        }
        /// <summary>
        /// Validate if link exists in the DB searched by the Id
        /// </summary>
        /// <param name="link">Link object to consult if exists</param>
        /// <returns>Returns true or false to request if exists or not</returns>
        private bool LinkExistsId(Link link)
        {
            var linksbLA = _linksRepo.GetById(link.Id);
            return linksbLA != null;
        }      
        /// <summary>
        /// Sends request to data layer to consult a link
        /// </summary>
        /// <param name="id">Id of link to consult</param>
        /// <returns>link object</returns>
        public Link GetLink(int id)
        {
            Link link = _linksRepo.GetById(id);
            return link;
        }

        public List<Link> GetFrequentLinks()
        {
            List<Link> links = _linksRepo.GetAllFrequent();
            return links;
        }
        #endregion
    }
}
