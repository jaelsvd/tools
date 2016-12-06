using App.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;

namespace App.ViewModels
{
    /// <summary>
    /// Class model to interact with create view
    /// </summary>
    public class BenefitViewModel
    {
        #region Constants
        /// <summary>
        /// Path where image will saved
        /// </summary>
        public static readonly string Path = "/Images/BenefitsImages/";
        #endregion

        #region Properties
        /// <summary>
        /// Id of benefit
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Title of benefit
        /// </summary>
        [DisplayName("Título")]
        [Required(ErrorMessage = "El título es requerido")]
        public string Title { get; set; }
        /// <summary>
        /// Body contains details about of benefit
        /// </summary>
        [AllowHtml]
        [Required(ErrorMessage = "Es necesario ingresar un contenido")]
        [DisplayName("Cuerpo")]
        public string Body { get; set; }
        /// <summary>
        /// Image of the benefit to create
        /// </summary>
        [DataType(DataType.Upload)]
        public HttpPostedFileBase ImageUpload { get; set; }
        public Benefit BenefitToUpdate{ get;set; }
        /// <summary>
        ///Benefit object with data
        /// </summary>
        public Benefit BenefitModel
        {
            get 
            { 
                return new Benefit { Title = Title, Body = Body, ImagePath = Path }; 
            }
        }
        #endregion
    }
}