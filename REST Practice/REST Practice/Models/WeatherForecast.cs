using System;

namespace REST_Practice
{
    public class WeatherForecast
    {
        public int Id { get; set; }

        public int NewCasterID { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
    }
}
