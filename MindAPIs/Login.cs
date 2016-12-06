using App.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.Configuration;

namespace MindAPIs
{
    /// <summary>
    /// This class manages The Login API
    /// </summary>
    public class Login
    {
        #region Constants
        /// <summary>
        /// Administrator URL address of API
        /// </summary>
        private static readonly string urlAdmin = "http://104.131.157.163/api/users/sign_in.json";
        /// <summary>
        /// Collaborator URL address of API
        /// </summary>
        private static readonly string urlCollaborator = "http://104.131.157.163/api/users/sign_in_collaborator.json";
        #endregion

        #region Public Methods
        /// <summary>
        /// Request a token from the API
        /// </summary>
        /// <param name="email">gets and email address</param>
        /// <param name="password">gets a password</param>
        /// <param name="isAdmin">identifies if is administrator</param>
        /// <returns>Returns a user</returns>
        public User getToken(string email,string password, bool isAdmin)
        {
            User user = new User();
            WebClient webClient = new WebClient();
            try
            {
                NameValueCollection values = new NameValueCollection();
                values["email"] = email;
                var response = new byte[] { };

                if (isAdmin)
                {
                    values["password"] = password;

                    response = webClient.UploadValues(urlAdmin, "POST", values);
                }
                else
                {
                    values["pin"] = password;

                    response = webClient.UploadValues(urlCollaborator, "POST", values);
                }

                var responseString = Encoding.Default.GetString(response);
                var responseObj= JsonConvert.DeserializeObject<AuthenticationResponse>(responseString);

                user = responseObj.User;
                user.Token = responseObj.Token;
                user.isAdmin = isAdmin;
                user.Pin = password;              

            }
            catch (Exception e)
            {

            }

            return user;
        }
        #endregion

    }
}
