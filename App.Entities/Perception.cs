using Newtonsoft.Json;
using System;

namespace App.Entities
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class Perception
    {
        #region Properties
        /// <summary>
        /// Concept of Perception
        /// </summary>
        [JsonProperty("Concepto")]
        public string Concept { get; set; }
        /// <summary>
        /// Amount of Perception
        /// </summary>
        [JsonProperty("Importe")]
        public double Amount { get; set; }
        /// <summary>
        /// Type of Perception
        /// </summary>
        [JsonProperty("TipoPercepcionDeduccion")]
        public string PerceptionType { get; set; }
        #endregion
    }
}
