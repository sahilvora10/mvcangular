
using Microsoft.AspNetCore.Mvc;
using MVCAngular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAngular.Repository
{
    public interface IWeatherRepository
    {

        IEnumerable<Models.WeatherForecast> GetWeatherForecasts();
        Models.WeatherForecast GetWeatherForecastByID(int WeatherId);
        void InsertWeather(Models.WeatherForecast weatherForecast);
        IActionResult DeleteWeather(int WeatherId);
        void UpdateWeather(Models.WeatherForecast weatherForecast);
        void Save(); 
    }
}
