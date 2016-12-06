using App.Entities;
using MindAPIs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace App.BLL
{
    public class DashboardBusiness
    {
        private Dashboard _dashboard;
        #region Constructor
        public DashboardBusiness()
        {
            _dashboard = new Dashboard();
        }
        #endregion
        /// <summary>
        /// Sends a Calendar list about carwash and breakfast details
        /// </summary>
        /// <param name="token">Token of security</param>
        /// <returns>Return a Calendar list about carwash and breakfast details</returns>
        public List<Calendar> GetCarWashBreak(string token)
        {
            List<Breakfast> Breakfasts = _dashboard.GetBreakfasts(token);
            List<CarWash> CarWashes =  _dashboard.GetCarWashListing(token);
            List<Calendar> Calendar = new List<Calendar>();
            foreach(Breakfast breakfast in Breakfasts)
            {
                Calendar.Add(new Calendar { start = breakfast.Date, className = "fa fa-cutlery" });
            }
            foreach (CarWash carwash in CarWashes)
            {
                Calendar.Add(new Calendar { start = carwash.Date, className = "fa fa-automobile" });
            }

            return Calendar;
        }

        public PayrollSlip GetPayrollSlip(string email, string pin)
        {
            return _dashboard.GetPayrollSlips(email, pin);
        }

        public CarWash GetNextCarWash(string token)
        {
            CarWash carWash = new CarWash();
            if(_dashboard.GetCarWashListing(token).Count > 0)
                carWash = _dashboard.GetCarWashListing(token).FirstOrDefault(x => x.Date > DateTime.Now);
            return carWash;
        }
    }
}
