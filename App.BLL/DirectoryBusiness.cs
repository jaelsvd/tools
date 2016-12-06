using App.Entities;
using MindAPIs;
using System.Collections.Generic;


namespace App.BLL
{
    /// <summary>
    /// 
    /// </summary>
    public class DirectoryBusiness
    {
        #region Instances
        Directory _directory;
        #endregion

        #region Contructor
        public DirectoryBusiness()
        {
            _directory = new Directory();
        }
        #endregion

        #region Lists
        public List<User> GetDirectorys(string token)
        {
            return _directory.GetDirectorys(token);
        }
        #endregion
    }
}
