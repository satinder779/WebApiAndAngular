using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace iassetTechnicalTest.Domain.Models
{
    public class CityModel
    {
        public List<Cities> AllCities { get; set; }

        [Display(Name = "ErrorMsg")]
        public string ErrorMsg { get; set; }
    }

    public class Cities
    {
        [Display(Name = "Country")]
        public string Country { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }
    }
}