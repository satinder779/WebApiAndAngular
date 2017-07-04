using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using iassetTechnicalTest.Domain;
using iassetTechnicalTest.Domain.Models;
using System;
using System.Xml.Linq;
using NLog;

namespace iassetTechnicalTest.Web.ApiControllers
{
    public class WeatherController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public WeatherController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [ResponseType(typeof (CityModel))]
        [System.Web.Http.HttpGet]
        public CityModel GetCitiesByCountryName(string countryName)
        {
            var cityModel = new CityModel();
            try
            {
                var xmlCities = XDocument.Parse(_unitOfWork.GWSoapServiceClient.GetCitiesByCountry(countryName));

                var allCities = xmlCities.Descendants("Table")
                    .Select(x => new Cities {City = (string) x.Element("City"), Country = (string) x.Element("Country")})
                    .OrderBy(x => x.City);

                cityModel.AllCities = allCities.ToList();
                return cityModel;
            }
            catch (Exception ex)
            {
                cityModel.ErrorMsg = "Error in getting cities ";
                LogManager.GetCurrentClassLogger().Error(ex, "Error in getting cities ", ex);
                return cityModel;
            }
        }


        [ResponseType(typeof (WeatherModel))]
        [System.Web.Http.HttpGet]
        public WeatherModel GetWeatherModelByCity(string countryName, string cityName)
        {
            var weatherReport = new WeatherModel();
            try
            {
                weatherReport.Location = "Sydney";
                weatherReport.Time = "01:01: AM";
                weatherReport.Wind = "test wind";
                weatherReport.Visibility = "none";
                weatherReport.SkyConditions = "clear";
                weatherReport.Temperature = "20 degree";
                weatherReport.DewPoint = "0";
                weatherReport.RelativeHumidity = "0%";
                weatherReport.Pressure = "40%";
                weatherReport.ErrorMsg = "Test Error Message";
                return weatherReport;

                //var xmlWeather = XDocument.Parse(_unitOfWork.GWSoapServiceClient.GetWeather(cityName, countryName));
                //weatherReport = xmlWeather.Descendants("Table")
                //    .Select(x => new WeatherModel
                //    {
                //        Location = (string)x.Element("Location"),
                //        Time = (string)x.Element("Time"),
                //        Wind = (string)x.Element("Wind"),
                //        Visibility = (string)x.Element("Visibility"),
                //        SkyConditions = (string)x.Element("SkyConditions"),
                //        Temperature = (string)x.Element("Temperature"),
                //        DewPoint = (string)x.Element("DewPoint"),
                //        RelativeHumidity = (string)x.Element("RelativeHumidity"),
                //        Pressure = (string)x.Element("Pressure")
                //    }).FirstOrDefault();

                //return weatherReport;
            }
            catch (Exception ex)
            {
                weatherReport.ErrorMsg = "Error in getting weather report ";
                LogManager.GetCurrentClassLogger().Error(ex, "Error in getting  weather report ");
                return weatherReport;
            }
        }
    }
}