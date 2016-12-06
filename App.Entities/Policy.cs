using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace App.Entities
{ 
    /// <summary>
    /// This class points the properties that Policy must have when being registered by the administrator
    /// </summary>
    public class Policy
    {
        #region Properties   
        /// <summary>
        /// This property is the ID or Primary Key of the Policy Table
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Title is the primary property required to insert Policy
        /// </summary>
        [Required]
        [DisplayName("Título")]
        public string Title { get; set; }
        /// <summary>
        /// Body is the actual text content inside Policy
        /// </summary>
        [Required]
        [DisplayName("Cuerpo")]
        [AllowHtml]
        public string Body { get; set;  }
        /// <summary>
        /// Date shows when the Policy were created
        /// </summary>
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}", ApplyFormatInEditMode=true)]
        public DateTime Date { get; set; }
        /// <summary>
        /// When Policy were last updated, saves de date and time of modification
        /// </summary>
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Update { get; set; }
        /// <summary>
        /// Path where a policy image is saved
        /// </summary>
        public string ImagePath { get; set; }
        /// <summary>
        /// Image name of a policy
        /// </summary>
        public string ImageName { get; set; }
        #endregion

    }
}
