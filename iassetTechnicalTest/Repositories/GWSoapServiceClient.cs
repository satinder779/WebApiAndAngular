using System;
using iassetTechnicalTest.Domain.Repositories;
using System.ServiceModel;
using iassetTechnicalTest.WeatherService;
using NLog;
using iassetTechnicalTest.Domain.Helpers;

namespace iassetTechnicalTest.Repositories
{
    internal class GwSoapServiceClient : IGWSoapServiceClient
    {
        private readonly GWServiceAddress _serviceAddress;
        private readonly TimeSpan _operationTimeOut;

        internal GwSoapServiceClient(GWServiceAddress serviceAddress, TimeSpan operationTimeOut)
        {
            _serviceAddress = serviceAddress;
            _operationTimeOut = operationTimeOut;
        }

        public string GetWeather(string cityName, string countryName)
        {
            var serviceClient = new GlobalWeatherSoapClient(
                GWSoapClientHelper.GetCustomBinding(_operationTimeOut),
                new EndpointAddress(_serviceAddress.GlobalWeatherSoapServiceAddress)
                );
            try
            {
                var weatherReport= serviceClient.GetWeather(cityName, countryName);
                serviceClient.Close();
                return weatherReport;
            }
            catch (Exception ex)
            {
                LogManager.GetCurrentClassLogger().Error(ex, "Error in getting weather ", ex);
                serviceClient.Abort();
                return ex.Message;
            }
        }

        public string GetCitiesByCountry(string countryName)
        {
            var serviceClient = new GlobalWeatherSoapClient(
                GWSoapClientHelper.GetCustomBinding(_operationTimeOut),
                new EndpointAddress(_serviceAddress.GlobalWeatherSoapServiceAddress)
                );
            try
            {
                var cities= serviceClient.GetCitiesByCountry(countryName);
                serviceClient.Close();
                return cities;
            }
            catch (Exception ex)
            {
                LogManager.GetCurrentClassLogger().Error(ex, "Error in getting cities ", ex);
                serviceClient.Abort();
                return ex.Message;
            }
        }
    }
}