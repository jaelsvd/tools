using App.Entities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;

namespace App.ViewModels
{
    /// <summary>
    /// Class model to interact with create policy view
    /// </summary>
    public class PolicyViewModel
    {
        #region Constans
        /// <summary>
        /// Path where the image will be saved
        /// </summary>
        public static readonly string Path = "/Images/PolicyImages/";
        #endregion

        #region Properties
        /// <summary>
        /// Id of policy
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Policy Title
        /// </summary>
        [DisplayName("Título")]
        [Required(ErrorMessage = "El título es requerido")]
        public string Title { get; set; }
        /// <summary>
        /// Policy Body
        /// </summary>
        [DisplayName("Cuerpo")]
        [Required(ErrorMessage = "Es necesario ingresar un contenido")]
        [AllowHtml]
        public string Body { get; set; }
        /// <summary>
        /// Create policy image
        /// </summary>
        [DataType(DataType.Upload)]
        public HttpPostedFileBase ImageUpload { get; set; }
        /// <summary>
        /// Policy object with data
        /// </summary>
        public Policy PolicyModel
        {
            get
            {
                return new Policy { Title = Title, Body = Body, ImagePath = Path };
            }
        }
        /// <summary>
        /// Policy object empty
        /// </summary>
        public Policy PolicyToUpdate { get; set; }
        #endregion
    }
}