using App.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace App.ViewModels
{
    /// <summary>
    /// Class to send data to dashboard view
    /// </summary>
    public class DashboardViewModel
    {
        #region Constructors
        public DashboardViewModel()
        {
            PayrollSlip = new PayrollSlip();
            Calendar = new List<Calendar>();
            News = new List<News>();
            //EventFiles = new List<EventFile>();
            Events = new List<Event>();
            Links = new List<Link>();
        }
        #endregion
        #region Properties
        public PayrollSlip PayrollSlip { get; set; }
        public List<Calendar> Calendar { get; set; }
        public List<News> News { get; set; }
        //public List<Event> Events { get; set; }
        public List<Event> Events { get; set; }
        public List<Link> Links { get; set; }
        [DisplayFormat(DataFormatString = "{0:dddd d MMMM}", ApplyFormatInEditMode = true)]
        public DateTime? NextCarWash { get; set; }
        #endregion
    }
}