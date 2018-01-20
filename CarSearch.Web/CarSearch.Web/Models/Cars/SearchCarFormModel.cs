namespace CarSearch.Web.Models.Cars
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class SearchCarFormModel
    {
        public string Importer { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "String with a minimum length of '3'.")]
        [MaxLength(20, ErrorMessage = "String with a maximum length of '20'.")]
        [Display(Name = "Description")]
        public string SearchString { get; set; }

        public IEnumerable<SelectListItem> Importers { get; set; }
    }
}
