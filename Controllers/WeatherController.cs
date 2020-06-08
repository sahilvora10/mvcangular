using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCAngular.Models;
using MVCAngular.Repository;

namespace MVCAngular.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class WeatherController : Controller
    {

        private readonly IWeatherRepository _weatherRepository;

        public WeatherController(IWeatherRepository weatherRepository)
        {
            _weatherRepository = weatherRepository;
        }

        [HttpGet]
        public  IActionResult Get()
        {
            Console.WriteLine("in controller");
            var weather =  _weatherRepository.GetWeatherForecasts();
            if (weather!=null)
            {
                return Ok(weather);
            }
            return NotFound();
            
        }
        
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var weather = _weatherRepository.GetWeatherForecastByID(id);
            if (weather == null)
            {
                return NotFound("No value for corresponding ID");
            }
            return new OkObjectResult(weather);
        }
        
        [HttpPost]
        public IActionResult Post([FromBody] Models.WeatherForecast weather)
        {
            using (var scope = new TransactionScope())
            {
                _weatherRepository.InsertWeather(weather);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = weather.Id }, weather);
            }
        }
        
        [HttpPut]
        public IActionResult Put([FromBody] WeatherForecast weather)
        {
            if (weather != null)
            {
                using (var scope = new TransactionScope())
                {
                    _weatherRepository.UpdateWeather(weather);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            IActionResult result=_weatherRepository.DeleteWeather(id);
            return result;
        }
        


    }
}
