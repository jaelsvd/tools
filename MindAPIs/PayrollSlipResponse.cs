using App.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MindAPIs
{
    /// <summary>
    /// Class to serialize payroll slips
    /// </summary>
    [Serializable]
    [JsonObject("data")]
    public class PayrollSlipResponse
    {
        #region Constructor
        /// <summary>
        /// Initialize Receipts list
        /// </summary>
        public PayrollSlipResponse()
        {
            Receipts = new List<Receipt>();
        }
        #endregion

        #region Properties
        [JsonProperty("NombreColaborador")]
        public string CollaboratorName { get; set; }
        [JsonProperty("PuestoColaborador")]
        public string CollaboratorPosition { get; set; }
        [JsonProperty("EquipoColaborador")]
        public string CollaboratorTeam { get; set; }
        [JsonProperty("Recibos")]
        public List<Receipt> Receipts { get; set; }
        #endregion
    }
}
