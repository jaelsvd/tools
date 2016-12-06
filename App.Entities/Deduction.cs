using Newtonsoft.Json;
using System;

namespace App.Entities
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class Deduction
    {
        #region Properties
        /// <summary>
        /// Concept of Deduction
        /// </summary>
        [JsonProperty("Concepto")]
        public string Concept { get; set; }
        /// <summary>
        /// Amount of Deduction
        /// </summary>
        [JsonProperty("Importe")]
        public double Amount { get; set; }
        /// <summary>
        /// Deduction Type
        /// </summary>
        [JsonProperty("TipoPercepcionDeduccion")]
        public string DeductionType { get; set; }
        #endregion
    }
}
