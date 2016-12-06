using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace App.Entities
{
    /// <summary>
    /// Represents a Event to perform.
    /// </summary>
    public class Event
    {
        #region Properties
        /// <summary>
        /// Id of an Event
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Title of an Event
        /// </summary>
        [DisplayName("Título")]
        [Required]
        public string Title { get; set; }
        /// <summary>
        /// Details about Event
        /// </summary>
        [DisplayName("Cuerpo")]
        [Required]
        [AllowHtml]
        public string Body { get; set; }
        /// <summary>
        /// Date of create the new event
        /// </summary>
        [DisplayName("Fecha de Registro")]
        [Required]
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// Id of Event Category
        /// </summary>
        public int CategoryId { get; set; }
        /// <summary>
        /// Date of the Event
        /// </summary>
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DisplayName("Fecha del Evento")]
        public DateTime EventDate { get; set; }
        /// <summary>
        /// Event Category object
        /// </summary>
        public EventCategory Category { get; set; }
        /// <summary>
        /// Path where a event image is saved
        /// </summary>
        public string ImagePath { get; set; }
        /// <summary>
        /// Image name of a event
        /// </summary>
        public string ImageName { get; set; }
        #endregion
    }
}
