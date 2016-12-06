using Newtonsoft.Json;
using System;
using App.Entities;
using System.Collections.Generic;
using System.Net;
using System.Configuration;

namespace MindAPIs
{
    /// <summary>
    /// Class to serialize Directory
    /// </summary>
    [Serializable]
    public class Directory
    {
        #region Constant
        /// <summary>
        /// Collaborator URL address from API
        /// </summary>
        //string urlDirectory = ConfigurationManager.AppSettings["urlDirectory"].ToString();
        private static readonly string urlDirectory = "http://104.131.157.163/api/collaborators.json";
        #endregion

        #region Constructor
        public Directory()
        {
            User = new User();
        }
        #endregion

        #region Properties
        /// <summary>
        /// User object
        /// </summary>
        [JsonProperty("collaborators")]
        public User User { get; set; }
        #endregion

        #region Public Methods
        /// <summary>
        /// Gets Token from the API    
        /// </summary>
        /// <param name="token">Token is saved</param>
        /// <returns>returns a list of users information</returns>
        public List<User> GetDirectorys(string token)
        {
            List<User> directorys = new List<User>();

            WebClient webClient = new WebClient();

            try
            {
                webClient.Headers["Authorization"] = token;
                var response = webClient.DownloadString(urlDirectory);

                var responseObj = JsonConvert.DeserializeObject<DirectoryResponse>(response);
                directorys = responseObj.Directorys;
            }
            catch (Exception e)
            {

            }

            return directorys;
        }
        #endregion
    }
}