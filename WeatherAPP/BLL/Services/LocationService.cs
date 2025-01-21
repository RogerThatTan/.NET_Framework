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
    public class LocationService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Location, LocationDTO>();
                cfg.CreateMap<LocationDTO, Location>();
                cfg.CreateMap<Weather, WeatherDTO>();
                cfg.CreateMap<WeatherDTO, Weather>();
                cfg.CreateMap<LocationWeatherDTO, Location>();
                cfg.CreateMap<Location,LocationWeatherDTO > ();

            });
            var mapper = new Mapper(config);
            return mapper;
        }

        public static LocationDTO Create(LocationDTO location)
        {
            var data = DataAccessFactory.LocationData();
            return GetMapper().Map<LocationDTO>(data.Create(GetMapper().Map<Location>(location)));
        }

        public static LocationDTO Get(int id)
        {
            var data = DataAccessFactory.LocationData();
            return GetMapper().Map<LocationDTO>(data.Get(id));
        }

        public static List<LocationDTO> Get()
        {
            var data = DataAccessFactory.LocationData();
            return GetMapper().Map<List<LocationDTO>>(data.Get());
        }

        public static LocationDTO Update(LocationDTO location)
        {
            var data = DataAccessFactory.LocationData();

            var updatedLOC = data.Update(GetMapper().Map<Location>(location));

            if (updatedLOC == null)
            {
                throw new Exception("Location not found");
            }
            return GetMapper().Map<LocationDTO>(updatedLOC);
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.LocationData().Delete(id);
        }

        
    }
}