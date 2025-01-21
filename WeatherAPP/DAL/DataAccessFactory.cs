using DAL.EF.Tables;
using DAL.Interface;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<Location,int, Location> LocationData()
        {
            return new LocationRepo();
        }

        public static IRepo<Weather, int, bool> WeatherData()
        {
            return new WeatherRepo();
        }

        public static IWeatherFeatures WeatherFeatures()
        {
            return new WeatherRepo();
        }


    }
}
