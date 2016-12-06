using App.Entities;
using System.Collections.Generic;


namespace App.ViewModels
{
    /// <summary>
    /// Class to send data to Admin Dashboard view
    /// </summary>
    public class AdminDashboardViewModel
    {
        #region Constructor
        public AdminDashboardViewModel()
        {
            Event = new List<Event>();
            Benefit = new List<Benefit>();
            Link = new List<Link>();
            News = new List<News>();
            Policy = new List<Policy>();
        }
        #endregion

        #region Properties
        public List<Event> Event { get; set; }
        public List<Benefit> Benefit { get; set; }
        public List<Link> Link { get; set; }
        public List<News> News { get; set; }
        public List<Policy> Policy { get; set; }
        #endregion
    }
}