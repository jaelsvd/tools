using System.ComponentModel;

namespace App.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    public class LoginViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        [DisplayName("Administrator")]
        public bool isAdmin { get; set; }

    }
}