using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Tables
{
    public class WeatherAlert
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Alert type cannot be longer than 30 characters.")]
        public string AlertType { get; set; }

        [Required(ErrorMessage = "Alert message is required.")]
        [StringLength(200, ErrorMessage = "Alert message cannot be longer than 200 characters.")]
        public string AlertMessage { get; set; }
        public DateTime IssuedAt { get; set; }
        public DateTime? ExpiresAt { get; set; }

        public virtual Location Location { get; set; }

        [ForeignKey("Location")]
        public int LocationId { get; set; }
    }
}
