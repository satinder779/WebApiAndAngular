using NUnit.Framework;
using iassetTechnicalTest.Domain;
using FakeItEasy;
using iassetTechnicalTest.Domain.Models;
using System.Xml.Linq;
using System.Linq;

namespace iassetTechnicalTest.Tests
{
    [TestFixture]
    public class GwSoapServiceClientTests
    {
        [Test]
        public void GetCitiesByCountryIsNotNull()
        {
            var sut = ListCitiesByCountry("Australia").AllCities;
            Assert.IsNotNull(sut);
        }

        [Test]
        public void GetCitiesByCountryIsCountZero()
        {
            var sut = ListCitiesByCountry("").AllCities;
            Assert.That(sut.Count == 0);
        }

        [Test]
        public void GetCitiesByCountryIsCountIsNotZero()
        {
            var sut = ListCitiesByCountry("Australia").AllCities;
            Assert.That(sut.Count > 0);
        }

        public CityModel ListCitiesByCountry(string countryName)
        {
            var cityModel = new CityModel();
            var unitOfWork = A.Fake<IUnitOfWork>();
            var xmlCities = XDocument.Parse(unitOfWork.GWSoapServiceClient.GetCitiesByCountry(countryName));

            var allCities = xmlCities.Descendants("Table")
                .Select(x => new Cities {City = (string) x.Element("City"), Country = (string) x.Element("Country")})
                .OrderBy(x => x.City);

            cityModel.AllCities = allCities.ToList();
            return cityModel;
        }

        public WeatherModel GetWeatherByCountry(string cityName, string countryName)
        {
            var unitOfWork = A.Fake<IUnitOfWork>();
            var xmlWeather = XDocument.Parse(unitOfWork.GWSoapServiceClient.GetWeather(cityName, countryName));
            var weatherReport = xmlWeather.Descendants("Table")
                .Select(x => new WeatherModel()
                {
                    Location = (string) x.Element("Location"),
                    Time = (string) x.Element("Time"),
                    Wind = (string) x.Element("Wind"),
                    Visibility = (string) x.Element("Visibility"),
                    SkyConditions = (string) x.Element("SkyConditions"),
                    Temperature = (string) x.Element("Temperature"),
                    DewPoint = (string) x.Element("DewPoint"),
                    RelativeHumidity = (string) x.Element("RelativeHumidity"),
                    Pressure = (string) x.Element("Pressure")
                }).FirstOrDefault();

            return weatherReport;
        }
    }
}