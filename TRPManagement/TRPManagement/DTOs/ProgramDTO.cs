using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TRPManagement.EF;

namespace TRPManagement.DTOs
{
    public class ProgramDTO
    {
        public int ProgramId { get; set; }
        public string ProgramName { get; set; }
        public decimal TRPScore { get; set; }
        public int ChannelId { get; set; }
        public System.TimeSpan AirTime { get; set; }

        public virtual Channel Channel { get; set; }
    }
}