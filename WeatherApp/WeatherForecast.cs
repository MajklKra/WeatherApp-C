namespace WeatherApp
{
    public class WeatherForecast
    {
        public int Id { get; set; }

        public string City { get; set; }
        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    }
}