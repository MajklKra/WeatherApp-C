using Microsoft.EntityFrameworkCore;

namespace WeatherApp
{


    public class WeatherDbContext : DbContext
    {
        public DbSet<WeatherForecast> WeatherForecasts { get; set; }
        public WeatherDbContext(DbContextOptions<WeatherDbContext> options) : base(options)
        {

        }
    }
}
