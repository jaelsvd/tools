using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace App.Entities
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class Receipt
    {
        #region Constructor
        public Receipt()
        {
            Deductions = new List<Deduction>();
            Perceptions = new List<Perception>();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Starting Date
        /// </summary>
        [JsonProperty("FechaInicio")]
        [DisplayFormat(DataFormatString = "{0:dddd, MMMM d, yyyy}")]
        public DateTime? StartDate { get; set; }
        /// <summary>
        /// End of Receipt Deduction
        /// </summary>
        [JsonProperty("FechaFin")]
        [DisplayFormat(DataFormatString = "{0:dddd, MMMM d, yyyy}")]
        public DateTime? FinishDate { get; set; }
        /// <summary>
        /// Date of Deposit
        /// </summary>
        [JsonProperty("FechaDeposito")]
        [DisplayFormat(DataFormatString = "{0:dddd, MMMM d, yyyy}")]
        public DateTime? DepositDate { get; set; }
        /// <summary>
        /// Perceptions
        /// </summary>
        [JsonProperty("Percepcciones")]
        public List<Perception> Perceptions { get; set; }
        /// <summary>
        /// Deductions
        /// </summary>
        [JsonProperty("Deducciones")]
        public List<Deduction> Deductions { get; set; }
        /// <summary>
        /// Total Perceptions
        /// </summary>
        [JsonProperty("TotalPercepciones")]
        public double PerceptionsTotal { get; set; }
        /// <summary>
        /// Total Deductions
        /// </summary>
        [JsonProperty("TotalDeducciones")]
        public double DeductionsTotal { get; set; }
        /// <summary>
        /// Total Deposit
        /// </summary>
        [JsonProperty("TotalDepositado")]
        public double TotalDeposited { get; set; }
        #endregion
    }
}
