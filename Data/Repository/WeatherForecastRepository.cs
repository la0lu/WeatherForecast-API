using APICLass.Data.Entities;

namespace APICLass.Data.Repository
{
    public class WeatherForecastRepository : IWeatherForecastRepository
    {
        private readonly WeatherForecastDbContext _context;

        public WeatherForecastRepository(WeatherForecastDbContext context)
        {
            _context = context;
        }

        public bool Add(WeatherForecast wF)
        {
            _context.Add(wF);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(WeatherForecast wF)
        {
            _context.Remove(wF);
            _context.SaveChanges();
            return true;
        }

        public bool Update(WeatherForecast wF)
        {
            _context.Update(wF);
            _context.SaveChanges();

            return true;
        }

        public WeatherForecast WeatherForecastGet(int id)
        {
            var result = _context.WeatherForecasts.FirstOrDefault(x => x.Id == id);

            if (result == null)
                return new WeatherForecast();

            return result;
        }

        public List<WeatherForecast> WeatherForecastsListAll()
        {
            return _context.WeatherForecasts.ToList();
        }

    }
}
