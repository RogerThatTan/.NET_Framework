using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class WeatherService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Location, LocationDTO>();
                cfg.CreateMap<LocationDTO, Location>();
                cfg.CreateMap<Weather, WeatherDTO>();
                cfg.CreateMap<WeatherDTO, Weather>();
                cfg.CreateMap<Weather, WeatherLocationDTO>();
                cfg.CreateMap<WeatherLocationDTO, Weather>();

            });
            var mapper = new Mapper(config);
            return mapper;
        }

        public static WeatherDTO Create(WeatherDTO weather)
        {
            var data = DataAccessFactory.WeatherData();
            return GetMapper().Map<WeatherDTO>(data.Create(GetMapper().Map<Weather>(weather)));
        }

        public static WeatherDTO Get(int id)
        {
            var data = DataAccessFactory.WeatherData();
            return GetMapper().Map<WeatherDTO>(data.Get(id));
        }

        public static List<WeatherDTO> Get()
        {
            var data = DataAccessFactory.WeatherData();
            return GetMapper().Map<List<WeatherDTO>>(data.Get());
        }

        public static bool Update(WeatherLocationDTO weather)
        {
            var data = GetMapper().Map<Weather>(weather);

            return DataAccessFactory.WeatherData().Update(data);
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.WeatherData().Delete(id);
        }
        public static List<WeatherDTO> SearchByLocation(int locationId)
        {
            var data = DataAccessFactory.WeatherFeatures().SearchByLocation(locationId);
            return GetMapper().Map<List<WeatherDTO>>(data);
        }

        public static List<WeatherDTO> GetForecastsForNext7Days(int locationId)
        {
            var data = DataAccessFactory.WeatherFeatures().GetForecastsForNext7Days(locationId);
            return GetMapper().Map<List<WeatherDTO>>(data);
        }

        public static WeatherDTO CurrentWeather(int locationId)
        {
            var data = DataAccessFactory.WeatherFeatures().DisplayCurrentWeather(locationId);
            return GetMapper().Map<WeatherDTO>(data);
        }





    }
}
