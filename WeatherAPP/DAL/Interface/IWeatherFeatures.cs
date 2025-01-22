using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IWeatherFeatures
    {
        List<Weather>SearchByLocation(int id);
        List<Weather> GetForecastsForNext7Days(int id);
        Weather DisplayCurrentWeather(int id);
        List<Weather> Alert(int id);

    }
}
