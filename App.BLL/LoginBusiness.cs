using App.Entities;
using MindAPIs;

namespace App.BLL
{
    /// <summary>
    /// This class cont
    /// </summary>
    public class LoginBusiness
    {
        private Login _login;
        #region Constructor
        public LoginBusiness()
        {
            _login = new Login();
        }
        #endregion

        public User getToken(string email, string pass, bool isAdmin)
        {
            return _login.getToken(email, pass, isAdmin);
        }
      
    }

}
