using APICLass.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace APICLass.Data
{
    public class WeatherForecastDbContext : IdentityDbContext<AppUser>
    {
        public WeatherForecastDbContext(DbContextOptions<WeatherForecastDbContext> options) : base(options)
        {
            
        }

        public DbSet<WeatherForecast> WeatherForecasts { get; set;}
    }
}
