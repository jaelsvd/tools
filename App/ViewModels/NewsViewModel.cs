using App.Entities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;

namespace App.ViewModels
{
    /// <summary>
    /// Class model to interact with create news view
    /// </summary>
    public class NewsViewModel
    {
        #region Constans
        /// <summary>
        /// Path where the image will be saved
        /// </summary>
        public static readonly string Path = "/Images/NewsImages/";
        #endregion
        #region Properties
        /// <summary>
        /// Id of news
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// News Title
        /// </summary>
        [DisplayName("Título")]
        [Required(ErrorMessage = "El título es requerido")]
        public string Title { get; set; }
        /// News Body Text
        /// </summary>
        [AllowHtml]
        [DisplayName("Cuerpo")]
        [Required (ErrorMessage = "Es necesario ingresar un contenido")]
        public string Body { get; set; }
        /// <summary>
        /// Imporrtancy of news
        /// </summary>
        [DisplayName("Importante")]
        public bool IsImportant { get; set; }
        /// <summary>
        /// News created date
        /// </summary>
        [DisplayName("Date")]
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// News modification date
        /// </summary>
        public DateTime Update { get; set; }
        /// <summary>
        /// Whom created news
        /// </summary>
        [DisplayName("Created By")]
        public string CreateBy { get; set; }
        /// <summary>
        /// Whom modified news
        /// </summary>
        [DisplayName("Updeated By")]
        public string UpdateBy { get; set; }
        /// <summary>
        /// Create news image
        /// </summary>
        [DataType(DataType.Upload)]
        public HttpPostedFileBase ImageUpload { get; set; }
        public News NewsToUpdate { get; set; }
        /// <summary>
        /// News object with data
        /// </summary>
        public News NewsModel
        {
            
            get
            {
                return new News { Title = Title, Body = Body, IsImportant = IsImportant, CreateDate = CreateDate, Update = Update, CreateBy = CreateBy, UpdateBy = UpdateBy, ImagePath = Path };
            }
        }        
        #endregion

    }
}