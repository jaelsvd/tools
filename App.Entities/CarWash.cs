using Newtonsoft.Json;
using System;

namespace App.Entities
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class CarWash
    {
        #region Properties
        /// <summary>
        /// Id of Carwash
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }
        /// <summary>
        /// Date when carwash is due
        /// </summary>
        [JsonProperty("date")]
        public DateTime? Date { get; set; }
        /// <summary>
        /// Collaborator Id
        /// </summary>
        [JsonProperty("collaborator_id")]
        public int CollaboratorId { get; set; }
        #endregion
    }
}
