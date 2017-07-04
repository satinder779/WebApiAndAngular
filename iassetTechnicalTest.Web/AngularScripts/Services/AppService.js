app.service('AppService', function($http) {

    var urlGet = '';

    this.getCitiesByCountryName = function(apiRoute, countryName) {
        urlGet = apiRoute + '/' + countryName + '/';
        return $http.get(urlGet);
    }

    this.getWeatherByCountryNameAndCityName = function(apiRoute, countryName, cityName) {
        debugger;
        urlGet = apiRoute + '/' + countryName + '/' + cityName + '/';
        return $http.get(urlGet);
    }
});