using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Tables
{
    public class Location
    {
        public int Id { get; set; }

        [Required]
        public string Country { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Region { get; set; }
        [Required]
        public string Latitude { get; set; }
        [Required]

        public string Longitude { get; set; }


        public virtual ICollection<Weather> Weathers { get; set; }
        public virtual ICollection<WeatherAlert> WeatherAlerts { get; set; }


        public Location()
        {
            Weathers = new List<Weather>();
            WeatherAlerts = new List<WeatherAlert>();
        }




    }
}
