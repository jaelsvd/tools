using App.Entities;
using Newtonsoft.Json;
using System;

namespace MindAPIs
{
    /// <summary>
    /// This class gets an authentication Response from the API
    /// </summary>
    [Serializable]
    [JsonObject("data")]
    public class AuthenticationResponse
    {
        #region Constructor
        public AuthenticationResponse()
        {
            User = new User();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Token is saved on this variable
        /// </summary>
        [JsonProperty("token")]
        public string Token { get; set; }
        /// <summary>
        /// Collaborator information
        /// </summary>
        [JsonProperty("collaborator")]
        public User User { get; set; }
        #endregion
    }
}
