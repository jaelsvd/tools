using App.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace App.ViewModels
{
    /// <summary>
    /// Class model to interact with create view
    /// </summary>
    public class LinkViewModel
    {
        #region Constants
        /// <summary>
        /// Path where image will saved
        /// </summary>
        public static readonly string Path = "/Images/LinksImages/";
        #endregion

        #region Properties
        /// <summary>
        /// Id of link
        /// </summary>
        public int Id { get; set; }
        [DisplayName("Nombre")]
        [Required(ErrorMessage = "El nombre es requerido")]
        public string Name { get; set; }
        [DisplayName("Descripción")]
        public string Description { get; set; }
        [DisplayName("URL")]
        [Required(ErrorMessage = "El URL es requerido")]
        public string AccessLink { get; set; }
        [DisplayName("Es Frecuente")]
        public bool IsFrequent { get; set; }
        /// <summary>
        /// Image of the link to create
        /// </summary>
        [DataType(DataType.Upload)]
        public HttpPostedFileBase ImageUpload { get; set; }
        #endregion

        public Link LinkModel
        {
            get
            {
                return new Link { Name = Name, Description = Description, AccessLink = AccessLink, IsFrequent = IsFrequent, ImagePath = Path };
            }
        }
        public Link LinkToUpdate { get; set; }
    }
}