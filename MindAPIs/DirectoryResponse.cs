using App.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MindAPIs
{
    [Serializable]
    [JsonObject("data")]
    public class DirectoryResponse
    {
        #region Constructor
        public DirectoryResponse()
        {
            Directorys = new List<User>();
        }
        #endregion

        #region Properties
        [JsonProperty("collaborators")]
        public List<User> Directorys { get; set; }
        #endregion
    }
}
