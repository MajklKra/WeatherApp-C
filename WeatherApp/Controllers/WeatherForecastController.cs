using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WeatherApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private WeatherDbContext _dbContext;
        public WeatherForecastController(WeatherDbContext weatherDbContext)
        {
            _dbContext = weatherDbContext;
        }


        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return _dbContext.WeatherForecasts.ToList();
        }

        [HttpGet("city")]
        public ActionResult<WeatherForecast> GetByCity(string city)
        {
            var forecast = _dbContext.WeatherForecasts.FirstOrDefault(x => x.City == city);
            if(forecast == null) return NotFound();

            return Ok(forecast);
        }


        [HttpPost]
        public IActionResult Post(WeatherForecast forecast)
        {
            _dbContext.WeatherForecasts.Add(forecast);
            _dbContext.SaveChanges();

            return Ok(forecast);
        }


        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var weatherForecast = _dbContext.WeatherForecasts.FirstOrDefault(x=>x.Id == id);
            if (weatherForecast == null) return NotFound();

            _dbContext.WeatherForecasts.Remove(weatherForecast);
            _dbContext.SaveChanges();

            return Ok();
        }

        [HttpDelete("{city}")]
        public IActionResult Delete(string city)
        {
            var weatherForecast = _dbContext.WeatherForecasts.FirstOrDefault(x => x.City == city);
            if (weatherForecast == null) return NotFound();

            _dbContext.WeatherForecasts.Remove(weatherForecast);
            _dbContext.SaveChanges();

            return Ok();
        }

    }
}