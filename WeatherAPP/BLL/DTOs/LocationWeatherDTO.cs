using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class LocationWeatherDTO : LocationDTO
    {
        public List<WeatherDTO> Weathers { get; set; }
        public LocationWeatherDTO()
        {
            Weathers = new List<WeatherDTO>();
        }
    }
}
