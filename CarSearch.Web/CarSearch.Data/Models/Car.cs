namespace CarSearch.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class Car
    {
        public int Id { get; set; }

        [Required]
        [MinLength(CarMakeMinLength)]
        [MaxLength(CarMakeMaxLength)]
        public string Make { get; set; }

        [Range(ManufacturingMinYear, ManufacturingMaxYear)]
        public int Year { get; set; }

        [Range(MinPowerPS, MaxPowerPS)]
        public int Power { get; set; }

        [Required]
        [MinLength(ImporterMinLength)]
        [MaxLength(ImporterMaxLength)]
        public string Importer { get; set; }

        [Required]
        [MinLength(DescriptionMinLength)]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }
    }
}
