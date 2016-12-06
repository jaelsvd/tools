using App.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MindAPIs
{
    /// <summary>
    /// Class to serialize Car Wash
    /// </summary>
    [Serializable]
    [JsonObject("data")]
    public class CarWashResponse
    {
        #region Constructor
        public CarWashResponse()
        {
            CarWashes = new List<CarWash>();
        }
        #endregion

        #region Properties
        [JsonProperty("carwashes")]
        public List<CarWash> CarWashes { get; set; }
        #endregion
    }
}
