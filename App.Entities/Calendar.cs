using System;

namespace App.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class Calendar
    {
        #region Properties
        public readonly string backgroundColor = "#fff";
        public readonly string textColor = "#000";
        public DateTime? start { get; set; }
        public string className { get; set; }
        #endregion
    }
}
