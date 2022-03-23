using AutoMapper;
using CryptSwitch.ApiServices;
using CryptSwitch.Builders;
using CryptSwitch.DTO;
using CryptSwitch.Models;
using Microsoft.AspNetCore.Mvc;

namespace CryptSwitch.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IMapper _mapper;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            ApiHelper.InitialiseClient();
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("ExChangeRate")]
        public async Task<IActionResult> ExChangeRate()
        {
            TradingModelBuilder modelBuilder = new TradingModelBuilder();
            var results = await modelBuilder.LoadExchangeRates();

            return Ok(_mapper.Map<ExchangeResultsDTO>(results));
        }
    }
}