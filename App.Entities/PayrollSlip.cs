
namespace App.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class PayrollSlip
    {
        #region Constructor
        public PayrollSlip()
        {
            Receipts = new Receipt();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Name of collaborator
        /// </summary>
        public string CollaboratorName { get; set; }
        /// <summary>
        /// Position of Collaborator
        /// </summary>
        public string CollaboratorPosition { get; set; }
        /// <summary>
        /// Team of Collaborator
        /// </summary>
        public string CollaboratorTeam { get; set; }

        /// <summary>
        /// Reciepts of Collaborator
        /// </summary>
        public Receipt Receipts { get; set; }
        #endregion
    }
}
