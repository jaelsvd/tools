using App.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace MindAPIs
{
    public class Dashboard
    {
        #region Constants
        private static readonly string urlBreakfasts = "http://104.131.157.163/api/breakfasts.json";
        private static readonly string urlCarWash = "http://104.131.157.163/api/carwashes.json";
        private static readonly string urlPayroll = "http://arcnomina-staging.azurewebsites.net/payrollapi/GetPayrollSlipsn";
        #endregion

        #region Methods
        /// <summary>
        /// Get breakfast data of a collaborator
        /// </summary>
        /// <param name="token">token to security at api data</param>
        /// <returns>Returns a breakfast object list</returns>
        public List<Breakfast> GetBreakfasts(string token)
        {
            List<Breakfast> breakfasts = new List<Breakfast>();

            WebClient webClient = new WebClient();
            try
            {
                webClient.Headers["Authorization"] = token;
                var response = webClient.DownloadString(urlBreakfasts);
                var responseObj = JsonConvert.DeserializeObject<BreakfastsResponse>(response);
                breakfasts = responseObj.Breakfasts;

            }
            catch (Exception e)
            {

            }

            return breakfasts;
        }
        /// <summary>
        /// Get carwash data of a collaborator
        /// </summary>
        /// <param name="token">token to security at api data</param>
        /// <returns>Returns a carwash object list</returns>
        public List<CarWash> GetCarWashListing(string token)
        {
            List<CarWash> carwashes = new List<CarWash>();

            WebClient webClient = new WebClient();
            try
            {
                webClient.Headers["Authorization"] = token;
                var response = webClient.DownloadString(urlCarWash);
                var responseObj = JsonConvert.DeserializeObject<CarWashResponse>(response);
                if(responseObj != null)
                    carwashes = responseObj.CarWashes;

            }
            catch (Exception e)
            {

            }

            return carwashes;
        }
        /// <summary>
        /// Get payroll slip data of a collaborator
        /// </summary>
        /// <param name="token">token to security at api data</param>
        /// <returns>Returns a payrollslip object list</returns>
        public PayrollSlip GetPayrollSlips(string email, string pin)
        {
            PayrollSlip payrollSlip = new PayrollSlip();

            WebClient webClient = new WebClient();
            try
            {
                webClient.Headers["userName"] = email;
                webClient.Headers["pin"] = pin;
                var response = webClient.DownloadString(urlPayroll);
                var responseObj = JsonConvert.DeserializeObject<PayrollSlipResponse>(response);
                payrollSlip.CollaboratorName = responseObj.CollaboratorName;
                payrollSlip.CollaboratorPosition = responseObj.CollaboratorPosition;
                payrollSlip.CollaboratorTeam = responseObj.CollaboratorTeam;
                payrollSlip.Receipts = responseObj.Receipts.FirstOrDefault();

            }
            catch (Exception e)
            {

            }

            return payrollSlip;
        }
        #endregion
    }
}
