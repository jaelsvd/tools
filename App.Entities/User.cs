using Newtonsoft.Json;
using System;
using System.ComponentModel;


namespace App.Entities
{
    /// <summary>
    /// This class defines Collaborators information
    /// </summary>
    [Serializable]
    public class User
    {
        #region Properties       
        /// <summary>
        /// Id
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }
        /// <summary>
        /// Collaborators CURP, Unique Code
        /// </summary>
        [JsonProperty("curp")]
        public string Curp { get; set; }
        /// <summary>
        /// Started working date
        /// </summary>
        [JsonProperty("start_date")]
        public DateTime? StartDate { get; set; }
        /// <summary>
        /// Last working day
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
        [DisplayName("Nombre de Equipo ")]
        public string TeamName { get; set; }
        /// <summary>
        /// Collaborators Names
        /// </summary>
        [JsonProperty("names")]
        public string Names { get; set; }
        /// <summary>
        /// Collaborators Last Names
        /// </summary>
        [JsonProperty("last_names")]
        [DisplayName("Apellidos")]
        public string LastNames { get; set; }
        /// <summary>
        /// Collaborators Date of Birth
        /// </summary>
        [JsonProperty("birthdate")]
        public DateTime BirthDate { get; set; }
        /// <summary>
        /// Current Working Status
        /// </summary>
        [JsonProperty("workingstatus")]
        public string WorkingStatus { get; set; }
        /// <summary>
        /// Collaborators E-mail
        /// </summary>
        [JsonProperty("email")]
        [DisplayName("Correo")]
        public string Email { get; set; }
        /// <summary>
        /// Collaborators Gender
        /// </summary>
        [JsonProperty("gender")]
        public string Gender { get; set; }
        /// <summary>
        /// Collaborators Status
        /// </summary>
        [JsonProperty("status")]
        public bool Status { get; set; }
        /// <summary>
        /// Collaborators Phone Extention number
        /// </summary>
        [JsonProperty("extension")]
        public int? Extension { get; set;}
        /// <summary>
        /// Is Administrator
        /// </summary>
        [DisplayName("Administrator")]
        public bool isAdmin { get; set; }
        /// <summary>
        /// Token from API
        /// </summary>
        public string Token { get; set; }
        /// <summary>
        /// Collaborators PIN number
        /// </summary>
        public string Pin { get; set; }

        #endregion
    }
}
