using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace App.Entities
{
    /// <summary>
    /// This class points the properties that news must have when being registered or displayed
    /// </summary>
    public class News
    {
        #region Properties
        /// <summary>
        /// This property is the ID or Primary Key of the News Table
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Title is the primary property required to insert news
        /// </summary>
        [Required]
        [DisplayName("Título")]
        public string Title { get; set; }
        /// <summary>
        /// Body is the actual text content inside News
        /// </summary>
        [AllowHtml]
        [DisplayName("Cuerpo")]
        [Required]
        public string Body { get; set; }
        /// <summary>
        /// This property points the level of news importance, is either too important or regular (True or False)
        /// </summary>
        [DisplayName("Importante")]
        public bool IsImportant { get; set; }
        /// <summary>
        /// Date shows when the news were created
        /// </summary>
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",ApplyFormatInEditMode=true)]
        [DisplayName("Fecha de Creación")]
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// When news were last updated, saves de date and time of modification
        /// </summary>
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DisplayName("Fecha de Modificación")]
        public DateTime Update { get; set; }
        /// <summary>
        ///Points Who created this news item
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        /// This property shows who last updated or modified this news item
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        /// Path where a news image is saved
        /// </summary>
        public string ImagePath { get; set; }
        /// <summary>
        /// Image name of a news
        /// </summary>
        public string ImageName { get; set; }
        #endregion
    }
}
