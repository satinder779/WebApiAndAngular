using System.ComponentModel.DataAnnotations;

namespace iassetTechnicalTest.Domain.Models
{
    public class WeatherModel
    {
        [Display(Name = "Location")]
        public string Location { get; set; }

        [Display(Name = "Time")]
        public string Time { get; set; }

        [Display(Name = "Wind")]
        public string Wind { get; set; }

        [Display(Name = "Visibility")]
        public string Visibility { get; set; }

        [Display(Name = "SkyConditions")]
        public string SkyConditions { get; set; }

        [Display(Name = "Temperature")]
        public string Temperature { get; set; }

        [Display(Name = "DewPoint")]
        public string DewPoint { get; set; }

        [Display(Name = "RelativeHumidity")]
        public string RelativeHumidity { get; set; }

        [Display(Name = "Pressure")]
        public string Pressure { get; set; }

        [Display(Name = "ErrorMsg")]
        public string ErrorMsg { get; set; }
    }
}