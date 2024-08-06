using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeatherApp;

namespace WeatherApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneratedWeatherController : ControllerBase
    {
        private readonly WeatherDbContext _context;

        public GeneratedWeatherController(WeatherDbContext context)
        {
            _context = context;
        }

        // GET: api/GeneratedWeather
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WeatherForecast>>> GetWeatherForecasts()
        {
          if (_context.WeatherForecasts == null)
          {
              return NotFound();
          }
            return await _context.WeatherForecasts.ToListAsync();
        }

        // GET: api/GeneratedWeather/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WeatherForecast>> GetWeatherForecast(int id)
        {
          if (_context.WeatherForecasts == null)
          {
              return NotFound();
          }
            var weatherForecast = await _context.WeatherForecasts.FindAsync(id);

            if (weatherForecast == null)
            {
                return NotFound();
            }

            return weatherForecast;
        }

        // PUT: api/GeneratedWeather/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWeatherForecast(int id, WeatherForecast weatherForecast)
        {
            if (id != weatherForecast.Id)
            {
                return BadRequest();
            }

            _context.Entry(weatherForecast).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WeatherForecastExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/GeneratedWeather
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WeatherForecast>> PostWeatherForecast(WeatherForecast weatherForecast)
        {
          if (_context.WeatherForecasts == null)
          {
              return Problem("Entity set 'WeatherDbContext.WeatherForecasts'  is null.");
          }
            _context.WeatherForecasts.Add(weatherForecast);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWeatherForecast", new { id = weatherForecast.Id }, weatherForecast);
        }

        // DELETE: api/GeneratedWeather/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWeatherForecast(int id)
        {
            if (_context.WeatherForecasts == null)
            {
                return NotFound();
            }
            var weatherForecast = await _context.WeatherForecasts.FindAsync(id);
            if (weatherForecast == null)
            {
                return NotFound();
            }

            _context.WeatherForecasts.Remove(weatherForecast);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WeatherForecastExists(int id)
        {
            return (_context.WeatherForecasts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
