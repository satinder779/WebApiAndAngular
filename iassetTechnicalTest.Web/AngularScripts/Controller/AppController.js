
app.controller('WeatherCtrl', [
    '$scope', 'AppService',
    function($scope, WeatherService) {

        // Base Url 
        var baseUrl = '/api/Weather/';
        $scope.btnText = "Search Cities";

        $scope.GetCitiesByCountryName = function() {
            debugger
            var apiRoute = baseUrl + 'GetCitiesByCountryName';
            var cities = WeatherService.getCitiesByCountryName(apiRoute, $scope.Country);
            cities.then(function(response) {
                    debugger
                    $scope.cities = response.data.AllCities;
                    $scope.ErrorMsg = response.data.ErrorMsg;

                },
                function(error) {
                    $scope.ErrorMsg = "opps! something went wrong. Please contact your administrator.";
                    console.log("Error: " + error.ErrorMsg);
                });
        }

        $scope.GetWeatherByCountryNameAndCityName = function() {
            debugger
            var apiRoute = baseUrl + 'GetWeatherModelByCity';
            var weather = WeatherService.getWeatherByCountryNameAndCityName(apiRoute, $scope.dataModel.Country, $scope.dataModel.City);
            weather.then(function(response) {
                    debugger
                    $scope.Location = response.data.Location;
                    $scope.Time = response.data.Time;
                    $scope.Wind = response.data.Wind;
                    $scope.Visibility = response.data.Visibility;
                    $scope.SkyConditions = response.data.SkyConditions;
                    $scope.Temperature = response.data.Temperature;
                    $scope.DewPoint = response.data.DewPoint;
                    $scope.RelativeHumidity = response.data.RelativeHumidity;
                    $scope.Pressure = response.data.Pressure;

                },
                function(error) {
                    $scope.ErrorMsg = "opps! something went wrong. Please contact your administrator.";
                    console.log("Error: " + error);
                });
        }
    }
]);