using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF.Tables;
using DAL.Interface;

namespace DAL.Repos
{
    internal class WeatherRepo : Repo, IRepo<Weather, int, bool>,IWeatherFeatures
    {
        public bool Create(Weather obj)
        {
            db.Weathers.Add(obj);
            return db.SaveChanges() > 0;
        }

       

        public bool Delete(int id)
        {
            var ex = Get(id);
            if (ex == null) return false;
            db.Weathers.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public Weather DisplayCurrentWeather(int id)
        {
            DateTime today = new DateTime(2025, 1, 23);
            var result = (from w in db.Weathers
                          where w.LocationId == id && DbFunctions.TruncateTime(w.Date) == today
                          orderby w.Date descending
                          select w).FirstOrDefault();
            return result;
        }

        public List<Weather> Get()
        {
            return db.Weathers.ToList();
        }

        public Weather Get(int id)
        {
            return db.Weathers.Find(id);
        }

        public List<Weather> GetForecastsForNext7Days(int id)
        {
            DateTime today = DateTime.Now;
            DateTime next7Days = today.AddDays(7);
            var result = (from w in db.Weathers
                          where w.LocationId == id && w.Date >= today && w.Date <= next7Days
                          select w).ToList();

            return result;
        }

        public List<Weather> SearchByLocation(int id)
        {
            var result = (from w in db.Weathers
                          where w.LocationId == id
                          select w).ToList();

            return result;
        }

        public bool Update(Weather obj)
        {
            var ex = Get(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }




    }
}
