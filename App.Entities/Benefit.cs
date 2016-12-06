using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace App.Entities
{
    /// <summary>
    /// This class containt properties of a benefit of mindhub
    /// </summary>
    public class Benefit
    {
        #region Properties
        /// <summary>
        /// ID and primary key of a benefit
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Title of the benefit
        /// </summary>
        [DisplayName("Título")]
        [Required]
        public string Title { get; set; }
        /// <summary>
        /// Body contains details about of benefit
        /// </summary>
        [AllowHtml]
        [DisplayName("Cuerpo")]
        [Required]
        public string Body { get; set; }
        /// <summary>
        /// Create date of the benefit
        /// </summary>
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DisplayName("Fecha de Creación")]
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// Path where a benefit image is saved
        /// </summary>
        public string ImagePath { get; set; }
        /// <summary>
        /// Image name of a benefit
        /// </summary>
        public string ImageName { get; set; }
        #endregion
    }
}
