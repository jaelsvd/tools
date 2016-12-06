using App.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MindAPIs
{
    /// <summary>
    /// Class to serialize Breakfasts
    /// </summary>
    [Serializable]
    [JsonObject("data")]
    public class BreakfastsResponse
    {
        #region Constructor
        public BreakfastsResponse()
        {
            Breakfasts = new List<Breakfast>();
        }
        #endregion

        #region Properties
        [JsonProperty("breakfasts")]
        public List<Breakfast> Breakfasts { get; set; }
        #endregion
    }
}
