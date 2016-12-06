using Newtonsoft.Json;
using System;

namespace App.Entities
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class Breakfast
    {
        #region Constructor
        public Breakfast()
        {
            User = new User();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Type of Food, breakfast or lunch
        /// </summary>
        [JsonProperty("type_of_food")]
        public int TypeOfFood { get; set; }
        /// <summary>
        /// Id
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }
        /// <summary>
        /// Collaborator
        /// </summary>
        [JsonProperty("collaborator")]
        public User User { get; set; }
        /// <summary>
        /// Date of consumption
        /// </summary>
        [JsonProperty("date")]
        public DateTime? Date { get; set; }
        #endregion
    }
}
