using APICLass.Data.Entities;
using APICLass.Data.Repository;
using APICLass.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace APICLass.Controllers
{
    [Authorize(AuthenticationSchemes ="Bearer")]
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherForecastRepository _repo;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastRepository weatherForecastRepository)
        {
            _logger = logger;
            _repo = weatherForecastRepository;

        }


        [HttpPost("add")]
        public IActionResult PostNewWeatherForecast([FromBody] AddWeatherForecastDto model)
        {
            if (ModelState.IsValid)
            {
                if(model.Summary == "string" ||  model.Summary == "")
                    return BadRequest("Invalid input!");

                var forecastToAdd = new WeatherForecast 
                {
                    Date = DateTime.Now,
                    TemperatureC = Random.Shared.Next(20, 55),
                    Summary = model.Summary
                };
                
                if (_repo.Add(forecastToAdd))
                    return Ok("Record added Successfully");
                return BadRequest("Record failed to add");
            }

            return BadRequest(ModelState);

        }

        [AllowAnonymous]
        [HttpGet("get-all")]
        public IActionResult GetAll()
        {
            var forecasts = _repo.WeatherForecastsListAll();

            if(forecasts == null)
                return NotFound("No record found");

            var result = forecasts.Select(x => new ReturnWeatherForecastDto
            {
                Id = x.Id,
                Date = x.Date,
                TemperatureC = x.TemperatureC,
                Summary = x.Summary,
                TemperatureF = x.TemperatureF
            });

            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet("single/{id}")]
        public IActionResult Get(int id)
        {
            var forecast = _repo.WeatherForecastGet(id);

            if (forecast != null)
            {
                var result = new ReturnWeatherForecastDto
                {
                    Id = forecast.Id,
                    Date = forecast.Date,
                    TemperatureC = forecast.TemperatureC,
                    Summary = forecast.Summary,
                    TemperatureF = forecast.TemperatureF
                };

                return Ok(result);
            }

            return NotFound($"No result found for record with id: {id}");
        }


        [HttpPut("Update/{id}")]
        public IActionResult UpdateWeatherForecast(int id, [FromBody]UpdateWeatherForecastDto model)
        {
            var forecast = _repo.WeatherForecastGet(id);

            if (forecast != null)
            {
              forecast.TemperatureC = model.TemperatureC;
              forecast.Summary = model.Summary;

                if (_repo.Update(forecast))
                {
                    return Ok("Updated Sucessfully");
                }
                return BadRequest("Update Failed");
            }

            return BadRequest($"MUpdate Failed: Could not get Weather Forecast with id {id}.");
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult DeleteWeatherForecast(int id)
        {
            var forecast = _repo.WeatherForecastGet(id);

            if (forecast != null)
            {   
                if (_repo.Delete(forecast))
                {
                    return Ok("Deleted Sucessfully");
                }
                return BadRequest("Delete Failed");
            }

            return BadRequest($"Delete Failed: Could not get Weather Forecast with id {id}.");
        }
    }
}


//JWT is made up of 3 parts: _payload, _encryption technonoogy, and _signature