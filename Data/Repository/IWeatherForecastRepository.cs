using APICLass.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace APICLass.Data.Repository
{
    public interface IWeatherForecastRepository
    {
        public bool Add(WeatherForecast wF);


        public bool Delete(WeatherForecast wF);


        public bool Update(WeatherForecast wF);


        public WeatherForecast WeatherForecastGet(int id);


        public List<WeatherForecast> WeatherForecastsListAll();

    }
}