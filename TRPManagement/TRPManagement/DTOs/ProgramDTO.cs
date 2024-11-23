using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using TRPManagement.EF;

namespace TRPManagement.DTOs
{
    public class ProgramDTO
    {
        public int ProgramId { get; set; }

        [Required]
        [StringLength(150,ErrorMessage = "Maximum length of 150 characters")]
        public string ProgramName { get; set; }

        [Required]
        [Range(0.0,10.0, ErrorMessage = "TRP Score must be between 0.0 and 10.0.")]
        public decimal TRPScore { get; set; }

        [Required(ErrorMessage="Channel Name or ID Required")]
        public int ChannelId { get; set; }

        [Required(ErrorMessage = "AirTime is required.")]
        [RegularExpression(@"^([0-1]?[0-9]|2[0-3]):([0-5][0-9]):([0-5][0-9])$", ErrorMessage = "AirTime must be in the format HH:mm:ss.")]
        public System.TimeSpan AirTime { get; set; }

        public virtual Channel Channel { get; set; }

    }
}