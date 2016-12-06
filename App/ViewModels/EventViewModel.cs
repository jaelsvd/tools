using App.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;

namespace App.ViewModels
{
    public class EventViewModel
    {

        #region Constants
        /// <summary>
        /// Path where image will saved
        /// </summary>
        public static readonly string Path = "/Images/EventsImages/";
        #endregion

        #region Constructors
        public EventViewModel()
        {

        }
        public EventViewModel(IList<EventCategory> categories)
        {
            Categories = categories;
            InitializeDropDown();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Id of event
        /// </summary>
        public int Id { get; set; }
        [DisplayName("Titulo")]
        [Required(ErrorMessage = "El título es requerido")]
        public string Title { get; set; }
        [DisplayName("Cuerpo")]
        [Required(ErrorMessage = "Es necesario ingresar un contenido")]
        [AllowHtml]
        public string Body { get; set; }
        [DisplayName("Categoría")]
        //[Required(ErrorMessage = "Es necesario seleccionar una categoría un contenido")]
        public string CategoryName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime EventDate { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public IList<EventCategory> Categories { get; set; }
        public IList<SelectListItem> CategoriesDropDown { get; set; }
        public Event EventToUpdate { get; set; }
        public Event EventModel
        {
            get
            {
                return new Event { Body = Body, CategoryId = CategoryId, EventDate = EventDate, Title = Title, ImagePath = Path };
            }
        }
        public HttpPostedFileBase ImageUpload { get; set; }
        #endregion

        #region Methods
        public void InitializeDropDown()
        {
            CategoriesDropDown = new List<SelectListItem>();
            foreach (var category in Categories)
            {
                CategoriesDropDown.Add(new SelectListItem { Text = category.Name, Value = category.Id.ToString() });
            }
        }
        #endregion
    }
}