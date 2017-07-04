namespace iassetTechnicalTest.Domain.Repositories
{
    public interface IGWSoapServiceClient
    {
        string GetWeather(string cityName, string countryName);

        string GetCitiesByCountry(string countryName);
    }
}