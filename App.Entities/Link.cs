using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Entities
{
    /// <summary>
    /// Links class contains properties of a link in mindhub
    /// <summary>
    public class Link
    {
        #region Properties
        /// <summary>
        /// Id and primary key of a Link
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Name of link
        /// </summary>
        [DisplayName("Descripción")]
        public string Description { get; set; }
        [DisplayName("Nombre")]
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// A link that is frecuently used and needs to be shown in the Dashboard
        /// </summary>
        public bool IsFrequent { get; set; }
        /// <summary>
        /// URL to access a link
        /// </summary>
        [DisplayName("Ingresar URL")]
        [Required]
        public string AccessLink { get; set; }
        /// <summary>
        /// Path where a link image is saved
        /// </summary>
        public string ImagePath { get; set; }
        /// <summary>
        /// Image name of a link
        /// </summary>
        public string ImageName { get; set; }
        #endregion
    }
}
