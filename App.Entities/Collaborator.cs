using Newtonsoft.Json;
using System;

namespace App.Entities
{
    /// <summary>
    /// This class contains Collaborators properties from API
    /// </summary>
    [Serializable]
    public class Collaborator
    {
        #region Properties
        /// <summary>
        /// Id of collaborator
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }
        /// <summary>
        /// Collaborators CURP (Unique Code)
        /// </summary>
        [JsonProperty("curp")]
        public string Curp { get; set; }
        /// <summary>
        /// Started working date
        /// </summary>
        [JsonProperty("start_date")]
        public DateTime? StartDate { get; set; }
        /// <summary>
        /// Last day of work
        /// </summary>
        [JsonProperty("finish_date")]
        public DateTime? FinishDate { get; set; }
        /// <summary>
        /// Working position
        /// </summary>
        [JsonProperty("position")]
        public string Position { get; set; }
        /// <summary>
        /// Team Name
        /// </summary>
        [JsonProperty("team_name")]
        public string TeamName { get; set; }
        /// <summary>
        /// Names (frist and middle name)
        /// </summary>
        [JsonProperty("names")]
        public string Names { get; set; }
        /// <summary>
        /// Family name
        /// </summary>
        [JsonProperty("last_names")]
        public string LastNames { get; set; }
        /// <summary>
        /// Date of birth
        /// </summary>
        [JsonProperty("birthdate")]
        public string BirthDate { get; set; }
        /// <summary>
        /// Working status
        /// </summary>
        [JsonProperty("workingstatus")]
        public string WorkingStatus { get; set; }
        /// <summary>
        /// Collaborators e-mail address
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }
        /// <summary>
        /// Collaborators Gender
        /// </summary>
        [JsonProperty("gender")]
        public string Gender { get; set; }
        /// <summary>
        /// Collaborators status(Active or Inactive)
        /// </summary>
        [JsonProperty("status")]
        public bool Status { get; set; }

        //Directory Properties
        /// <summary>
        /// Collaborators extension number
        /// </summary>
        [JsonProperty("extension")]
        public int Extension { get; set; }
        /// <summary>
        /// Account
        /// </summary>
        [JsonProperty("account")]
        public string Account { get; set; }
        #endregion
    }
}
