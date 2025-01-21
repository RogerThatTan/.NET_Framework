using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Tables
{
    public class Weather
    {
        public int Id { get; set; }
        [Required]
        public double Temperature { get; set; }
        [Required]
        public int Humidity { get; set; }
        [Required]
        public string Condition { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [ForeignKey("Location")]
        public int LocationId { get; set; }
        public virtual Location Location { get; set; }



    }
}
