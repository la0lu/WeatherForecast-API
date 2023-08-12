using APICLass.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace APICLass.DTOs
{
    public class AddWeatherForecastDto
    {
        [Required]
        public int TemperatureC { get; set; }

        [Required]
        [StringLength(30, MinimumLength =3, ErrorMessage ="summary must be between 3 and 30 characters")]
        public string? Summary { get; set; }
    }
}
